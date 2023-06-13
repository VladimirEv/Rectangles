using RectangleLibrary1.IRectangleGetProperty;
using Rectangles.DataAccess.Repository.IRepository;
using Rectangles.ViewModels;

namespace RectangleLibrary1
{
    public class RectangleServiceChangingCoordinates : IRectangleServiceChangingCoordinates
    {
        private readonly IRectangleServiceHelp _rectangleServiceHelp;
        private readonly IRectangleService _rectangleService;

        public RectangleServiceChangingCoordinates(IRectangleServiceHelp rectangleServiceHelp, 
                                                   IRectangleService rectangleService)
        {
            _rectangleServiceHelp = rectangleServiceHelp;
            _rectangleService = rectangleService;
        }

        public async Task<List<RectangleViewModel>> GetAllRectanglesChangeCoordinateMethod(IRectangleRepository _rectangleRepo,
                                                                                           IPointRepository _pointRepo,
                                                                                           IColorBodyRepository _colorBodyRepo,
                                                                                           IColorLineRepository _colorLineRepo)
        {
            var allRectangles = await _rectangleService.GetAllRectanglesMethod(_rectangleRepo, _pointRepo, _colorBodyRepo, _colorLineRepo);

            double[] botLeftPointXmin = new double[allRectangles.Count() - 1];
            double[] botLeftPointYmin = new double[allRectangles.Count() - 1];
            double[] topRightPointXmax = new double[allRectangles.Count() - 1];
            double[] topRightPointYmax = new double[allRectangles.Count() - 1];

            for (int i = 0; i < allRectangles.Count() - 1; i++)
            {
                botLeftPointXmin[i] = allRectangles[i].BotLeftPointX;
                botLeftPointYmin[i] = allRectangles[i].BotLeftPointY;
                topRightPointXmax[i] = allRectangles[i].TopRightPointX;
                topRightPointYmax[i] = allRectangles[i].TopRightPointY;
            }

            var botLeftPointXminValue = botLeftPointXmin.Min();
            var botLeftPointYminValue = botLeftPointYmin.Min();
            var topRightPointXmaxValue = topRightPointXmax.Max();
            var topRightPointYmaxValue = topRightPointYmax.Max();

            for (int i = allRectangles.Count() - 1; i < allRectangles.Count(); i++)
            {
                allRectangles[i].BotLeftPointX = botLeftPointXminValue;
                allRectangles[i].BotLeftPointY = botLeftPointYminValue;
                allRectangles[i].TopRightPointX = topRightPointXmaxValue;
                allRectangles[i].TopRightPointY = topRightPointYmaxValue;
            }

            return allRectangles;
        }


        public async Task<List<RectangleViewModel>> GetRectanglesWithNeedDotsMethod(IRectangleRepository _rectangleRepo,
                                                                                    IPointRepository _pointRepo,
                                                                                    IColorBodyRepository _colorBodyRepo,
                                                                                    IColorLineRepository _colorLineRepo)
        {
            var allRectangles = await _rectangleService.GetAllRectanglesMethod(_rectangleRepo, _pointRepo, _colorBodyRepo, _colorLineRepo);

            double[] botLeftPointXmin = new double[allRectangles.Count() - 1];
            double[] botLeftPointYmin = new double[allRectangles.Count() - 1];
            double[] topRightPointXmax = new double[allRectangles.Count() - 1];
            double[] topRightPointYmax = new double[allRectangles.Count() - 1];

            var mainRectBotLeftX = 0.0;
            var mainRectBotRightY = 0.0;
            var mainRectTopRighttX = 0.0;
            var mainRectTopRighttY = 0.0;

            for (int i = allRectangles.Count() - 1; i < allRectangles.Count(); i++)
            {
                mainRectBotLeftX = allRectangles[i].BotLeftPointX;
                mainRectBotRightY = allRectangles[i].BotLeftPointY;
                mainRectTopRighttX = allRectangles[i].TopRightPointX;
                mainRectTopRighttY = allRectangles[i].TopRightPointY;
            }


            for (int i = 0; i < allRectangles.Count() - 1; i++)
            {
                if (allRectangles[i].BotLeftPointX >= mainRectBotLeftX && allRectangles[i].BotLeftPointX <= mainRectTopRighttX)
                { botLeftPointXmin[i] = allRectangles[i].BotLeftPointX; }
                else { botLeftPointXmin[i] = 0.0; }

                if (allRectangles[i].BotLeftPointY >= mainRectBotRightY && allRectangles[i].BotLeftPointY <= mainRectTopRighttY)
                { botLeftPointYmin[i] = allRectangles[i].BotLeftPointY; }
                else { botLeftPointYmin[i] = 0.0; }

                if (allRectangles[i].TopRightPointX <= mainRectTopRighttX && allRectangles[i].TopRightPointX >= mainRectBotLeftX)
                { topRightPointXmax[i] = allRectangles[i].TopRightPointX; }
                else { topRightPointXmax[i] = 0.0; }

                if (allRectangles[i].TopRightPointY <= mainRectTopRighttY && allRectangles[i].TopRightPointY >= mainRectBotRightY)
                { topRightPointYmax[i] = allRectangles[i].TopRightPointY; }
                else { topRightPointYmax[i] = 0.0; }

            }


            var botLeftPointXminValue = _rectangleServiceHelp.UpdateArrayDelZero(botLeftPointXmin, mainRectBotLeftX).Min();
            var botLeftPointYminValue = _rectangleServiceHelp.UpdateArrayDelZero(botLeftPointYmin, mainRectBotRightY).Min();
            var topRightPointXmaxValue = _rectangleServiceHelp.UpdateArrayDelZero(topRightPointXmax, mainRectTopRighttX).Max();
            var topRightPointYmaxValue = _rectangleServiceHelp.UpdateArrayDelZero(topRightPointYmax, mainRectTopRighttY).Max();


            for (int i = allRectangles.Count() - 1; i < allRectangles.Count(); i++)
            {
               allRectangles[i].BotLeftPointX = botLeftPointXminValue; 

               allRectangles[i].BotLeftPointY = botLeftPointYminValue;

                allRectangles[i].TopRightPointX = topRightPointXmaxValue; 
              
               allRectangles[i].TopRightPointY = topRightPointYmaxValue;
            }

            return allRectangles;
        }
    }
}