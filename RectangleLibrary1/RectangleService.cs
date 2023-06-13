using RectangleLibrary1.IRectangleGetProperty;
using Rectangles.DataAccess.Repository.IRepository;
using Rectangles.Models;
using Rectangles.ViewModels;

namespace RectangleLibrary1
{
    public class RectangleService : IRectangleService
    {


        private IRectangleRepository object1;
        private IPointRepository object2;
        private IColorBodyRepository object3;
        private IColorLineRepository object4;

        public RectangleService(IRectangleRepository object1, IPointRepository object2, IColorBodyRepository object3, IColorLineRepository object4)
        {
            this.object1 = object1;
            this.object2 = object2;
            this.object3 = object3;
            this.object4 = object4;
        }

        public RectangleService()
        {

        }

        public async Task<List<RectangleViewModel>> GetAllRectanglesMethod(IRectangleRepository _rectangleRepo,
                                                                           IPointRepository _pointRepo,
                                                                           IColorBodyRepository _colorBodyRepo,
                                                                           IColorLineRepository _colorLineRepo)
        {
            var rectangleViewModelList = new List<RectangleViewModel>();


            var rectangleRepoList = await _rectangleRepo.GetAllAsync();            

            foreach (var item in rectangleRepoList)
            {
                var botLeftPointValue = await _pointRepo.FirstOrDefaultAsync(e => e.Id == item.BotLeftId);
                var topRightPointValue = await _pointRepo.FirstOrDefaultAsync(e => e.Id == item.TopRightId);
                var colorBodyValue = await _colorBodyRepo.FirstOrDefaultAsync(e => e.Id == item.ColorBodyRectangleId);
                var colorLineValue = await _colorLineRepo.FirstOrDefaultAsync(e => e.Id == item.ColorLineRectangleId);

                rectangleViewModelList.Add(new RectangleViewModel()
                {
                    Id = item.Id,
                    NumberRectangle = item.NumberRectangle,
                    NameRectangle = item.NameRectangle,
                    BotLeftPointX = botLeftPointValue.XValue,
                    BotLeftPointY = botLeftPointValue.YValue,
                    TopRightPointX = topRightPointValue.XValue,
                    TopRightPointY = topRightPointValue.YValue,
                    ColorBodyRectangle = colorBodyValue.ColorBodyValue,
                    ColorLineRectangle = colorLineValue.ColorLineValue
                });
            }
            return rectangleViewModelList;
        }


        public async Task AddRectanglesMethod(RectangleViewModel rectangleViewModel, 
                                                                  IRectangleRepository _rectangleRepo,
                                                                  IPointRepository _pointRepo,
                                                                  IColorBodyRepository _colorBodyRepo,
                                                                  IColorLineRepository _colorLineRepo)
        {
            var countRectangles = await GetCountOfRectanglesMethod(_rectangleRepo);

           
                if (countRectangles > 5)
                {
                    await _rectangleRepo.AddAsync(new Rectangle
                    {
                        NumberRectangle = rectangleViewModel.NumberRectangle,
                        NameRectangle = "main rectangle N" + " " + rectangleViewModel.NameRectangle,
                        BotLeftPoint = new Point(rectangleViewModel.BotLeftPointX, rectangleViewModel.BotLeftPointY),
                        TopRightPoint = new Point(rectangleViewModel.TopRightPointX, rectangleViewModel.TopRightPointY),
                        ColorLineRectangle = new ColorLine(rectangleViewModel.ColorLineRectangle),
                        ColorBodyRectangle = new ColorBody(rectangleViewModel.ColorBodyRectangle)
                    });
                }
                else
                {
                    await _rectangleRepo.AddAsync(new Rectangle
                    {
                        NumberRectangle = rectangleViewModel.NumberRectangle,
                        NameRectangle = "rectangle" + " " + rectangleViewModel.NameRectangle,
                        BotLeftPoint = new Point(rectangleViewModel.BotLeftPointX, rectangleViewModel.BotLeftPointY),
                        TopRightPoint = new Point(rectangleViewModel.TopRightPointX, rectangleViewModel.TopRightPointY),
                        ColorLineRectangle = new ColorLine(rectangleViewModel.ColorLineRectangle),
                        ColorBodyRectangle = new ColorBody(rectangleViewModel.ColorBodyRectangle)
                    });
                }
                await _rectangleRepo.SaveAsync();
                await _pointRepo.SaveAsync();
                await _colorBodyRepo.SaveAsync();
                await _colorLineRepo.SaveAsync();            
        }


        public async Task<int> GetCountOfRectanglesMethod(IRectangleRepository _rectangleRepo)
        {
            var countRectangles = 0;

            var rectangleRepoList = await _rectangleRepo.GetAllAsync();

            foreach (var item in rectangleRepoList)
            {
                countRectangles++;
            }
            return countRectangles;
        }

    }
}