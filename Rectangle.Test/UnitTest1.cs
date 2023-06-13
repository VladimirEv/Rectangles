using Moq;
using Moq.AutoMock;
using RectangleLibrary1;
using Rectangles.DataAccess.Repository.IRepository;
using Rectangles.Models;
using Rectangles.ViewModels;

[TestFixture]
public class RectangleServiceTests
{
    [Test]
    public async Task GetAllRectanglesMethod_ReturnsListOfRectangles()
    {
        // Arrange
        var rectangleRepoMock = new Mock<IRectangleRepository>();
        var pointRepoMock = new Mock<IPointRepository>();
        var colorBodyRepoMock = new Mock<IColorBodyRepository>();
        var colorLineRepoMock = new Mock<IColorLineRepository>();

        var service = new RectangleService();

        var rectangleRepoList = new List<Rectangle>
        {
            new Rectangle { Id = 1, NumberRectangle = 1, NameRectangle = "Rectangle 1", BotLeftId = 1, TopRightId = 2, ColorLineRectangleId = 1, ColorBodyRectangleId = 1},
            new Rectangle { Id = 2, NumberRectangle = 2, NameRectangle = "Rectangle 2", BotLeftId = 3, TopRightId = 4, ColorLineRectangleId = 2, ColorBodyRectangleId = 2}
        };

        var pointRepoList = new List<Point>
        {
            new Point { Id = 1, XValue = 150.0, YValue = 150.0},
            new Point { Id = 2, XValue = 200.0, YValue = 350.0},
            new Point { Id = 3, XValue = 250.0, YValue = 350.0},
            new Point { Id = 4, XValue = 400.0, YValue = 550.0}
        };

        var intRepoList = new List<Point>
        {
            new Point { Id = 1, XValue = 150.0, YValue = 150.0},
            new Point { Id = 2, XValue = 200.0, YValue = 350.0},
            new Point { Id = 3, XValue = 250.0, YValue = 350.0},
            new Point { Id = 4, XValue = 400.0, YValue = 550.0}
        };

        var colorBodyRepoList = new List<ColorBody>
        {
            new ColorBody { Id = 1, ColorBodyValue = "Turquoise"},
            new ColorBody { Id = 2, ColorBodyValue = "Purple"}
        };

        var colorLineRepoList = new List<ColorLine>
        {
            new ColorLine { Id = 1, ColorLineValue = "Black"},
            new ColorLine { Id = 2, ColorLineValue = "Black"}
        };

        var rectangleRepoMockObject = rectangleRepoMock.Object;
       

        rectangleRepoMock.Setup(r => r.GetAllAsync(null, null, null, true)).ReturnsAsync(rectangleRepoList);

        pointRepoMock.Setup(p => p.GetAllAsync(null, null, null, true)).ReturnsAsync(pointRepoList);

        colorBodyRepoMock.Setup(c => c.GetAllAsync(null, null, null, true)).ReturnsAsync(colorBodyRepoList);

        colorLineRepoMock.Setup(k => k.GetAllAsync(null, null, null, true)).ReturnsAsync(colorLineRepoList);

        // Act
        var result = await service.GetAllRectanglesMethod(rectangleRepoMock.Object,
                                                          pointRepoMock.Object,
                                                          colorBodyRepoMock.Object,
                                                          colorLineRepoMock.Object);

        // Assert
        Assert.IsInstanceOf<List<RectangleViewModel>>(result);
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual(1, result[0].Id);
        Assert.AreEqual("Rectangle 1", result[0].NameRectangle);
        Assert.AreEqual(0, result[0].BotLeftPointX);
        Assert.AreEqual(0, result[0].BotLeftPointY);
        Assert.AreEqual(0, result[0].TopRightPointX);
        Assert.AreEqual(0, result[0].TopRightPointY);
        Assert.AreEqual("Red", result[0].ColorBodyRectangle);
        Assert.AreEqual("Blue", result[0].ColorLineRectangle);
        Assert.AreEqual(2, result[1].Id);
        Assert.AreEqual("Rectangle 2", result[1].NameRectangle);
        Assert.AreEqual(0, result[1].BotLeftPointX);
        Assert.AreEqual(0, result[1].BotLeftPointY);
        Assert.AreEqual(0, result[1].TopRightPointX);
        Assert.AreEqual(0, result[1].TopRightPointY);
        Assert.AreEqual("Red", result[1].ColorBodyRectangle);
        Assert.AreEqual("Blue", result[1].ColorLineRectangle);
    }

    [Test]
    public async Task AddRectanglesMethod_AddsRectangle()
    {
        // Arrange
        var rectangleRepoMock = new Mock<IRectangleRepository>();
        var pointRepoMock = new Mock<IPointRepository>();
        var colorBodyRepoMock = new Mock<IColorBodyRepository>();
        var colorLineRepoMock = new Mock<IColorLineRepository>();

        var service = new RectangleService();

        var rectangleViewModel = new RectangleViewModel
        {
            NumberRectangle = 1,
            NameRectangle = "New Rectangle",
            BotLeftPointX = 0,
            BotLeftPointY = 0,
            TopRightPointX = 0,
            TopRightPointY = 0,
            ColorBodyRectangle = "Red",
            ColorLineRectangle = "Blue"
        };


        rectangleRepoMock.Setup(r => r.SaveAsync()).Returns((Task<int>)Task.CompletedTask);
        pointRepoMock.Setup(p => p.SaveAsync()).Returns((Task<int>)Task.CompletedTask);
        colorBodyRepoMock.Setup(c => c.SaveAsync()).Returns((Task<int>)Task.CompletedTask);
        colorLineRepoMock.Setup(c => c.SaveAsync()).Returns((Task<int>)Task.CompletedTask);

        // Act
        await service.AddRectanglesMethod(rectangleViewModel,
            rectangleRepoMock.Object, pointRepoMock.Object, colorBodyRepoMock.Object, colorLineRepoMock.Object);

        // Assert
        rectangleRepoMock.Verify(r => r.AddAsync(It.IsAny<Rectangle>()), Times.Once);
        rectangleRepoMock.Verify(r => r.SaveAsync(), Times.Once);
        pointRepoMock.Verify(p => p.SaveAsync(), Times.Once);
        colorBodyRepoMock.Verify(c => c.SaveAsync(), Times.Once);
        colorLineRepoMock.Verify(c => c.SaveAsync(), Times.Once);
    }

    [Test]
    public async Task GetCountOfRectanglesMethod_ReturnsCountOfRectangles()
    {
        // Arrange
        var rectangleRepoMock = new Mock<IRectangleRepository>();
        var service = new RectangleService();

        var rectangleRepoList = new List<Rectangle>
        {
            new Rectangle { Id = 1, NumberRectangle = 1 },
            new Rectangle { Id = 2, NumberRectangle = 2 }
        };

        rectangleRepoMock.Setup(r => r.GetAllAsync(null, null, null, true)).ReturnsAsync(rectangleRepoList);

        // Act
        var result = await service.GetCountOfRectanglesMethod(rectangleRepoMock.Object);

        // Assert
        Assert.AreEqual(3, result);
    }
}