using System;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace TestProject
{
    public class RandomAnswersControllerTests
    {
        [Fact]
        public async Task GetYesNoAnswer_ReturnsOkWithAnswer()
        {
            // Arrange
            var mockService = new Mock<IRandomAnswerService>();
            var mockLogger = new Mock<ILogger<RandomAnswersController>>();

            // Настраиваем mock сервиса, чтобы он возвращал "Yes"
            mockService.Setup(x => x.GetRandomYesNoAsync()).ReturnsAsync("Yes");

            var controller = new RandomAnswersController(mockService.Object, mockLogger.Object);

            // Act
            var result = await controller.GetYesNoAnswer() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);      // Проверяем что статус = 200 (OK)
            Assert.Equal("Yes", result.Value);         // Проверяем что возвращаемое значение = "Yes"
        }

        [Fact]
        public async Task GetYesNoAnswer_ReturnsInternalServerError_WhenExceptionThrown()
        {
            // Arrange
            var mockService = new Mock<IRandomAnswerService>();
            var mockLogger = new Mock<ILogger<RandomAnswersController>>();

            // Настраиваем mock сервиса, чтобы он выбрасывал исключение
            mockService.Setup(x => x.GetRandomYesNoAsync()).ThrowsAsync(new Exception("Test exception"));

            var controller = new RandomAnswersController(mockService.Object, mockLogger.Object);

            // Act
            var result = await controller.GetYesNoAnswer() as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(500, result.StatusCode);                    // Проверяем что статус = 500 (Internal Server Error)
            Assert.Equal("Internal server error", result.Value);     // Проверяем что возвращаемое сообщение об ошибке
        }
    }
}