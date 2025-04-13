using Application.Interfaces;
using Core.Entities;
using Moq;
using WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

public class UserControllerTests
{
    [Fact]
    public async Task Post_ShouldReturnBadRequest_WhenUserNameTooLong()
    {
        // Arrange
        var mockService = new Mock<IUserService>();
        var controller = new UsersController(mockService.Object);
        var longUser = new User { UserName = new string('x', 21) };

        // Act
        var result = await controller.Post(longUser);

        // Assert
        var badRequest = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("UserName must be 20 characters or fewer.", badRequest.Value);
    }
}