using user;
using user.Models;

namespace userTests.UserQueryTests;

public class MinUserAgeTests
{
    private readonly UserQueryService _userService = new();

    [Fact]
    public void MinUserAge_ShouldReturnZero_WhenEmptyUserListProvided()
    {
        // Arrange
        var users = new List<User>();
        
        // Act
        var result = _userService.MinUserAge(users);
        
        // Assert
        Assert.Equal(0, result);
    }
    
    [Fact]
    public void MinUserAge_ShouldReturnMinAge_WhenUserListProvided()
    {
        // Arrange
        var users = new List<User>
        {
            new() { Id = Guid.NewGuid(), Name = "Ivan", Age = 18 },
            new() { Id = Guid.NewGuid(), Name = "Petr", Age = 19 },
            new() { Id = Guid.NewGuid(), Name = "Sanek", Age = 20 }
        };
        
        // Act
        var result = _userService.MinUserAge(users);
        
        // Assert
        Assert.Equal(18, result);
    }
}