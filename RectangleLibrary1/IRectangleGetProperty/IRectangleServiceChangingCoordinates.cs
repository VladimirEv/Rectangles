using Rectangles.DataAccess.Repository.IRepository;
using Rectangles.ViewModels;

namespace RectangleLibrary1.IRectangleGetProperty
{
    public interface IRectangleServiceChangingCoordinates
    {

        Task<List<RectangleViewModel>> GetAllRectanglesChangeCoordinateMethod(IRectangleRepository rectangleRepo,
                                                                              IPointRepository pointRepo,
                                                                              IColorBodyRepository colorBodyRepo,
                                                                              IColorLineRepository colorLineRepo);


        Task<List<RectangleViewModel>> GetRectanglesWithNeedDotsMethod(IRectangleRepository rectangleRepo,
                                                                       IPointRepository pointRepo,
                                                                       IColorBodyRepository colorBodyRepo,
                                                                       IColorLineRepository colorLineRepo);

    }
}
