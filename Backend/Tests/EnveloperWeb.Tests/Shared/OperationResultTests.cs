using EnveloperWeb.Application.Wrappers;
using Xunit;

namespace EnveloperWeb.Tests.Shared
{
    public class OperationResultTests
    {
        [Fact]
        public void Success_ShouldSetIsSuccessToTrue_AndStoreData()
        {
            // Arrange
            var expectedData = "TestData";

            // Act
            var result = OperationResult<string>.Success(expectedData);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(expectedData, result.Data);
            Assert.Empty(result.Errors);
        }

        [Fact]
        public void Failure_ShouldSetIsSuccessToFalse_AndStoreErrors()
        {
            // Arrange
            var expectedErrors = new[] { "Error1", "Error2" };

            // Act
            var result = OperationResult<string>.Failure(expectedErrors);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Null(result.Data);
            Assert.Equal(expectedErrors, result.Errors);
        }
    }
}
