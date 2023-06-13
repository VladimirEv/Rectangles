using Microsoft.AspNetCore.Mvc;
using RectangleLibrary1.IRectangleGetProperty;
using Rectangles.DataAccess.Repository.IRepository;
using Rectangles.ViewModels;

namespace Rectangles.Controllers
{
    public class RectangleFind1Controller : Controller
    {       
        private readonly IRectangleRepository _rectangleRepo;
        private readonly IPointRepository _pointRepo;
        private readonly IColorBodyRepository _colorBodyRepo;
        private readonly IColorLineRepository _colorLineRepo;
        private readonly IRectangleServiceChangingCoordinates _rectangleServiceChangingCoordinates;
        private readonly IRectangleService _rectangleService;
        private readonly IRectangleServiceChangingCoordinatesColorRec _rectangleServiceChangingCoordinatesColorRec;


        public RectangleFind1Controller(IRectangleRepository rectangleRepo, 
                                        IPointRepository pointRepo,
                                        IColorBodyRepository colorBodyRepo,
                                        IColorLineRepository colorLineRepo,
                                        IRectangleServiceChangingCoordinates rectangleServiceChangingCoordinates,
                                        IRectangleService rectangleService,
                                        IRectangleServiceChangingCoordinatesColorRec rectangleServiceChangingCoordinatesColorRec)
        {
            _rectangleRepo = rectangleRepo;
            _pointRepo = pointRepo;
            _colorBodyRepo = colorBodyRepo;
            _colorLineRepo = colorLineRepo;
            _rectangleServiceChangingCoordinates = rectangleServiceChangingCoordinates;
            _rectangleService = rectangleService;
            _rectangleServiceChangingCoordinatesColorRec = rectangleServiceChangingCoordinatesColorRec;
        }



        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _rectangleService.GetAllRectanglesMethod(_rectangleRepo, _pointRepo,
                                                                       _colorBodyRepo, _colorLineRepo));
        }



        [HttpGet]
        public async Task<IActionResult> IndexChange()
        {
            return View(await _rectangleServiceChangingCoordinates.GetAllRectanglesChangeCoordinateMethod(_rectangleRepo, _pointRepo,
                                                                                                          _colorBodyRepo, _colorLineRepo));
        }



        [HttpGet]
        public async Task<IActionResult> IndexChangeWithNeedDots()
        {
            return View(await _rectangleServiceChangingCoordinates.GetRectanglesWithNeedDotsMethod(_rectangleRepo, _pointRepo,
                                                                                                   _colorBodyRepo, _colorLineRepo));
        }



        [HttpGet]
        public async Task<IActionResult> IndexColor()
        {
            return View(await _rectangleService.GetAllRectanglesMethod(_rectangleRepo, _pointRepo,
                                                                       _colorBodyRepo, _colorLineRepo));
        }



        [HttpGet]
        public async Task<IActionResult> IndexGetColorPink()
        {
            return View(await _rectangleServiceChangingCoordinatesColorRec.GetRectColorChangeCoordinateMethod(_rectangleRepo, 
                                                                                                              _pointRepo,
                                                                                                              _colorBodyRepo, 
                                                                                                              _colorLineRepo));
        }



        [HttpGet]
        public async Task<IActionResult> IndexGetColorPurpleTurquoise()
        {
            return View(await _rectangleServiceChangingCoordinatesColorRec.GetRectColorPurpleTurquoiseMethod(_rectangleRepo,
                                                                                                             _pointRepo,
                                                                                                             _colorBodyRepo,
                                                                                                             _colorLineRepo));
        }
    }
}