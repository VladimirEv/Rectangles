using Microsoft.AspNetCore.Mvc;
using RectangleLibrary1.IRectangleGetProperty;
using Rectangles.DataAccess.Repository.IRepository;
using Rectangles.ViewModels;

namespace Rectangles.MVC.Controllers
{
    public class MainController : Controller
    {
            private readonly IRectangleRepository _rectangleRepo;
            private readonly IPointRepository _pointRepo;
            private readonly IColorBodyRepository _colorBodyRepo;
            private readonly IColorLineRepository _colorLineRepo;
            private readonly IRectangleService _rectangleService;


            public MainController(IRectangleRepository rectangleRepo,
                                  IPointRepository pointRepo,
                                  IColorBodyRepository colorBodyRepo,
                                  IColorLineRepository colorLineRepo,
                                  IRectangleService rectangleService)
            {
                _rectangleRepo = rectangleRepo;
                _pointRepo = pointRepo;
                _colorBodyRepo = colorBodyRepo;
                _colorLineRepo = colorLineRepo;
                _rectangleService = rectangleService;
            }



            [HttpGet]
            public async Task<IActionResult> Index()
            {
                return View(await _rectangleService.GetAllRectanglesMethod(_rectangleRepo, _pointRepo,
                                                                           _colorBodyRepo, _colorLineRepo));
            }



            [HttpGet]
            public IActionResult AddRectangle()
            {
                return View();
            }
            
            [HttpPost]
            [IgnoreAntiforgeryToken]
            public async Task<IActionResult> AddRectangle(RectangleViewModel rectangleViewModel)
            {
                if (ModelState.IsValid)
                {
                    await _rectangleService.AddRectanglesMethod(rectangleViewModel, _rectangleRepo, _pointRepo, _colorBodyRepo, _colorLineRepo);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(rectangleViewModel);
                }
            }



            [HttpGet]
            public async Task<IActionResult> Edit(int? id)
            {
                RectangleViewModel rectangleViewModel = new RectangleViewModel();
                if (id == null)
                {
                    return View(rectangleViewModel);
                }
                else
                {
                    var rectangleViewModelValues = await _rectangleRepo.FindAsync(id.GetValueOrDefault());

                    var botLeftPointValue = await _pointRepo.FirstOrDefaultAsync(e => e.Id == rectangleViewModelValues.BotLeftId);
                    var topRightPointValue = await _pointRepo.FirstOrDefaultAsync(e => e.Id == rectangleViewModelValues.TopRightId);
                    var colorBodyValue = await _colorBodyRepo.FirstOrDefaultAsync(e => e.Id == rectangleViewModelValues.ColorBodyRectangleId);
                    var colorLineValue = await _colorLineRepo.FirstOrDefaultAsync(e => e.Id == rectangleViewModelValues.ColorLineRectangleId);


                    rectangleViewModel.NumberRectangle = rectangleViewModelValues.NumberRectangle;
                    rectangleViewModel.NameRectangle = rectangleViewModelValues.NameRectangle;
                    rectangleViewModel.BotLeftPointX = botLeftPointValue.XValue;
                    rectangleViewModel.BotLeftPointY = botLeftPointValue.YValue;
                    rectangleViewModel.TopRightPointX = topRightPointValue.XValue;
                    rectangleViewModel.TopRightPointY = topRightPointValue.YValue;
                    rectangleViewModel.ColorBodyRectangle = colorBodyValue.ColorBodyValue;
                    rectangleViewModel.ColorLineRectangle = colorLineValue.ColorLineValue;

                    if (rectangleViewModel == null)
                    {
                        return NotFound();
                    }
                    return View(rectangleViewModel);
                }
            }

            [HttpPost]
            [IgnoreAntiforgeryToken]
            public async Task<IActionResult> Edit(RectangleViewModel rectangleViewModel)
            {
                var rectangleViewModelValues = await _rectangleRepo.FindAsync(rectangleViewModel.Id);

                var botLeftPointValue = await _pointRepo.FirstOrDefaultAsync(e => e.Id == rectangleViewModelValues.BotLeftId);
                var topRightPointValue = await _pointRepo.FirstOrDefaultAsync(e => e.Id == rectangleViewModelValues.TopRightId);
                var colorBodyValue = await _colorBodyRepo.FirstOrDefaultAsync(e => e.Id == rectangleViewModelValues.ColorBodyRectangleId);
                var colorLineValue = await _colorLineRepo.FirstOrDefaultAsync(e => e.Id == rectangleViewModelValues.ColorLineRectangleId);

                rectangleViewModelValues.Id = rectangleViewModel.Id;
                rectangleViewModelValues.NumberRectangle = rectangleViewModel.NumberRectangle;
                rectangleViewModelValues.NameRectangle = rectangleViewModel.NameRectangle;

                botLeftPointValue.XValue = rectangleViewModel.BotLeftPointX;
                botLeftPointValue.YValue = rectangleViewModel.BotLeftPointY;

                topRightPointValue.XValue = rectangleViewModel.TopRightPointX;
                topRightPointValue.YValue = rectangleViewModel.TopRightPointY;

                colorBodyValue.ColorBodyValue = rectangleViewModel.ColorBodyRectangle;

                colorLineValue.ColorLineValue = rectangleViewModel.ColorLineRectangle;

                if (ModelState.IsValid)
                {
                    _rectangleRepo.Update(rectangleViewModelValues);
                    _pointRepo.Update(botLeftPointValue);
                    _pointRepo.Update(topRightPointValue);
                    _colorBodyRepo.Update(colorBodyValue);
                    _colorLineRepo.Update(colorLineValue);

                    await _rectangleRepo.SaveAsync();
                    await _pointRepo.SaveAsync();
                    await _colorBodyRepo.SaveAsync();
                    await _colorLineRepo.SaveAsync();

                    return RedirectToAction("Index");
                }
                return View(rectangleViewModel);
            }



            [HttpGet]
            public async Task<IActionResult> Delete(int? id)
            {
                RectangleViewModel rectangleViewModel = new RectangleViewModel();
                if (id == null)
                {
                    return View(rectangleViewModel);
                }
                else
                {
                    var rectangleViewModelValues = await _rectangleRepo.FindAsync(id.GetValueOrDefault());

                    var botLeftPointValue = await _pointRepo.FirstOrDefaultAsync(e => e.Id == rectangleViewModelValues.BotLeftId);
                    var topRightPointValue = await _pointRepo.FirstOrDefaultAsync(e => e.Id == rectangleViewModelValues.TopRightId);
                    var colorBodyValue = await _colorBodyRepo.FirstOrDefaultAsync(e => e.Id == rectangleViewModelValues.ColorBodyRectangleId);
                    var colorLineValue = await _colorLineRepo.FirstOrDefaultAsync(e => e.Id == rectangleViewModelValues.ColorLineRectangleId);

                    rectangleViewModel.Id = rectangleViewModelValues.Id;
                    rectangleViewModel.NumberRectangle = rectangleViewModelValues.NumberRectangle;
                    rectangleViewModel.NameRectangle = rectangleViewModelValues.NameRectangle;
                    rectangleViewModel.BotLeftPointX = botLeftPointValue.XValue;
                    rectangleViewModel.BotLeftPointY = botLeftPointValue.YValue;
                    rectangleViewModel.TopRightPointX = topRightPointValue.XValue;
                    rectangleViewModel.TopRightPointY = topRightPointValue.YValue;
                    rectangleViewModel.ColorBodyRectangle = colorBodyValue.ColorBodyValue;
                    rectangleViewModel.ColorLineRectangle = colorLineValue.ColorLineValue;

                    if (rectangleViewModel == null)
                    {
                        return NotFound();
                    }
                    return View(rectangleViewModel);
                }
            }

            [HttpPost]
            [IgnoreAntiforgeryToken]
            public async Task<IActionResult> Delete(RectangleViewModel rectangleViewModel)
            {
                var rectangleViewModelValues = await _rectangleRepo.FindAsync(rectangleViewModel.Id);
                var botLeftPointValue = await _pointRepo.FirstOrDefaultAsync(e => e.Id == rectangleViewModelValues.BotLeftId);
                var topRightPointValue = await _pointRepo.FirstOrDefaultAsync(e => e.Id == rectangleViewModelValues.TopRightId);
                var colorBodyValue = await _colorBodyRepo.FirstOrDefaultAsync(e => e.Id == rectangleViewModelValues.ColorBodyRectangleId);
                var colorLineValue = await _colorLineRepo.FirstOrDefaultAsync(e => e.Id == rectangleViewModelValues.ColorLineRectangleId);

                if (ModelState.IsValid)
                {
                    _rectangleRepo.Remove(rectangleViewModelValues);
                    _pointRepo.Remove(topRightPointValue);
                    _pointRepo.Remove(botLeftPointValue);
                    _colorBodyRepo.Remove(colorBodyValue);
                    _colorLineRepo.Remove(colorLineValue);

                    await _rectangleRepo.SaveAsync();
                    await _pointRepo.SaveAsync();
                    await _colorBodyRepo.SaveAsync();
                    await _colorBodyRepo.SaveAsync();

                    return RedirectToAction("Index");
                }
                return View(rectangleViewModel);
            }

    }
}

