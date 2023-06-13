using Moq;
using RectangleLibrary1;
using Rectangles.DataAccess.Repository.IRepository;
using Rectangles.Models;
using Rectangles.ViewModels;

namespace Rectangle.Test
{
    public class RectangleServiceTests
    {       

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