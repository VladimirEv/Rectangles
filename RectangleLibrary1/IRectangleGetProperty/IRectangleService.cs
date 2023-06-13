using Rectangles.DataAccess.Repository.IRepository;
using Rectangles.ViewModels;

namespace RectangleLibrary1.IRectangleGetProperty
{
    public interface IRectangleService
    {
        Task<List<RectangleViewModel>> GetAllRectanglesMethod(IRectangleRepository rectangleRepo,
                                                              IPointRepository pointRepo,
                                                              IColorBodyRepository colorBodyRepo,
                                                              IColorLineRepository colorLineRepo);

        Task<int> GetCountOfRectanglesMethod(IRectangleRepository rectangleRepo);

        Task AddRectanglesMethod(RectangleViewModel rectangleViewModel, 
                                 IRectangleRepository rectangleRepo,
                                 IPointRepository pointRepo,
                                 IColorBodyRepository colorBodyRepo,
                                 IColorLineRepository colorLineRepo);
    }
}
