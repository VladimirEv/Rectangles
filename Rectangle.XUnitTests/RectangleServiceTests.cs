using Moq;
using RectangleLibrary1;
using Rectangles.DataAccess.Repository.IRepository;
using Rectangles.Models;
using Rectangles.ViewModels;
using System.Linq;
using System.Linq.Expressions;

namespace Rectangle.Test
{
    public class RectangleServiceTests
    {
        [Fact]
        public async Task GetAllRectanglesMethod_ShouldReturnAllRectangles()
        {
            // Arrange
            var rectangleRepoMock = new Mock<IRectangleRepository>();
            var pointRepoMock = new Mock<IPointRepository>();
            var colorBodyRepoMock = new Mock<IColorBodyRepository>();
            var colorLineRepoMock = new Mock<IColorLineRepository>();

            var rectangleService = new RectangleService(rectangleRepoMock.Object, pointRepoMock.Object, colorBodyRepoMock.Object, colorLineRepoMock.Object);

            var rectangleList = new List<Rectangles.Models.Rectangle>
        {
            new Rectangles.Models.Rectangle { Id = 1, NumberRectangle = 1, NameRectangle = "Rectangle 1" ,
                                              BotLeftId = 1, BotLeftPoint = new Point(){Id = 1, XValue = 0, YValue = 0},
                                              TopRightId = 2, TopRightPoint = new Point(){Id = 2, XValue = 10, YValue = 10},
                                              ColorBodyRectangleId = 1, ColorBodyRectangle = new ColorBody(){Id = 1, ColorBodyValue = "Red"},
                                              ColorLineRectangleId = 1, ColorLineRectangle = new ColorLine(){Id = 1,ColorLineValue = "Black"}
            },
            new Rectangles.Models.Rectangle { Id = 2, NumberRectangle = 2, NameRectangle = "Rectangle 2",
                                              BotLeftId = 3, BotLeftPoint = new Point(){Id = 3, XValue = 20, YValue =20},
                                              TopRightId = 4, TopRightPoint = new Point(){Id = 4, XValue = 30, YValue = 30},
                                              ColorBodyRectangleId = 2, ColorBodyRectangle = new ColorBody(){Id = 2, ColorBodyValue = "Blue"},
                                              ColorLineRectangleId = 2, ColorLineRectangle = new ColorLine(){Id = 2,ColorLineValue = "White"}
            }
        };
            var pointList = new List<Point>
        {
            new Point { Id = 1, XValue = 0, YValue = 0 },
            new Point { Id = 2, XValue = 10, YValue = 10 },
            new Point { Id = 3, XValue = 20, YValue = 20 },
            new Point { Id = 4, XValue = 30, YValue = 30 }
        };
            var colorBodyList = new List<ColorBody>
        {
            new ColorBody { Id = 1, ColorBodyValue = "Red" },
            new ColorBody { Id = 2, ColorBodyValue = "Blue" }
        };
            var colorLineList = new List<ColorLine>
        {
            new ColorLine { Id = 1, ColorLineValue = "Black" },
            new ColorLine { Id = 2, ColorLineValue = "White" }
        };

            colorLineRepoMock.Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<Expression<Func<ColorLine, bool>>>(), null, true))
                .ReturnsAsync((Expression<Func<ColorLine, bool>> predicate, string includeProperties, bool isTracking) => colorLineList.FirstOrDefault(predicate.Compile()));

            rectangleRepoMock.Setup(repo => repo.GetAllAsync(null, null, null, true)).ReturnsAsync(rectangleList);

            pointRepoMock.Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<Expression<Func<Point, bool>>>(), null, true))
                .ReturnsAsync((Expression<Func<Point, bool>> predicate, string includeProperties, bool isTracking) => pointList.FirstOrDefault(predicate.Compile()));

            colorBodyRepoMock.Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<Expression<Func<ColorBody, bool>>>(), null, true))
                .ReturnsAsync((Expression<Func<ColorBody, bool>> predicate, string includeProperties, bool isTracking) => colorBodyList.FirstOrDefault(predicate.Compile()));



            // Act
            var result = await rectangleService.GetAllRectanglesMethod(rectangleRepoMock.Object, pointRepoMock.Object, colorBodyRepoMock.Object, colorLineRepoMock.Object);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal(1, result[0].Id);
            Assert.Equal("Rectangle 1", result[0].NameRectangle);
            Assert.Equal(0, result[0].BotLeftPointX);
            Assert.Equal(0, result[0].BotLeftPointY);
            Assert.Equal(10, result[0].TopRightPointX);
            Assert.Equal(10, result[0].TopRightPointY);
            Assert.Equal("Red", result[0].ColorBodyRectangle);
            Assert.Equal("Black", result[0].ColorLineRectangle);

            Assert.Equal(2, result[1].Id);
            Assert.Equal("Rectangle 2", result[1].NameRectangle);
            Assert.Equal(20, result[1].BotLeftPointX);
            Assert.Equal(20, result[1].BotLeftPointY);
            Assert.Equal(30, result[1].TopRightPointX);
            Assert.Equal(30, result[1].TopRightPointY);
            Assert.Equal("Blue", result[1].ColorBodyRectangle);
            Assert.Equal("White", result[1].ColorLineRectangle);
        }


        [Fact]
        public async Task GetCountOfRectanglesMethod_ReturnsCountOfRectangles()
        {
            // Arrange
            //создали мок-объект rectangleRepoMock с помощью фреймворка Moq для интерфейса IRectangleRepository.
            //Это позволяет вам настраивать поведение его для тестирования класса RectangleService.
            var rectangleRepoMock = new Mock<IRectangleRepository>(); 

            var rectangleService = new RectangleService(
                rectangleRepoMock.Object, 
                null,
                null,
                null
            );

            var rectangleRepoList = new List<Rectangles.Models.Rectangle>
            {
                new Rectangles.Models.Rectangle(),
                new Rectangles.Models.Rectangle(),
                new Rectangles.Models.Rectangle()
            };

            rectangleRepoMock.Setup(mock => mock.GetAllAsync(null, null, null, true)).ReturnsAsync(rectangleRepoList);

            // Act
            var result = await rectangleService.GetCountOfRectanglesMethod(rectangleRepoMock.Object);

            // Assert
            Assert.Equal(3, result);
        }
    }
}