using Rectangles.DataAccess.Repository.IRepository;
using Rectangles.ViewModels;

namespace RectangleLibrary1.IRectangleGetProperty
{
    public interface IRectangleServiceChangingCoordinatesColorRec
    {
        Task<List<RectangleViewModel>> GetRectColorChangeCoordinateMethod(IRectangleRepository _rectangleRepo,
                                                                          IPointRepository _pointRepo,
                                                                          IColorBodyRepository _colorBodyRepo,
                                                                          IColorLineRepository _colorLineRepo);

        Task<List<RectangleViewModel>> GetRectColorPurpleTurquoiseMethod(IRectangleRepository _rectangleRepo,
                                                                                       IPointRepository _pointRepo,
                                                                                       IColorBodyRepository _colorBodyRepo,
                                                                                       IColorLineRepository _colorLineRepo);
    }
}
