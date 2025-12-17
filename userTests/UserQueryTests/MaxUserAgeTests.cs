using user;
using user.Models;

namespace userTests.UserQueryTests;

public class MaxUserAgeTests
{
    private readonly UserQueryService _userService = new();

    [Fact]
    public void MaxUserAge_ShouldReturnZero_WhenEmptyUserListProvided()
    {
        // Arrange
        var users = new List<User>();
        
        // Act
        var result = _userService.MaxUserAge(users);
        
        // Assert
        Assert.Equal(0, result);
    }
    
    [Fact]
    public void MaxUserAge_ShouldReturnMaxAge_WhenUserListProvided()
    {
        // Arrange
        var users = new List<User>
        {
            new() { Id = Guid.NewGuid(), Name = "Ivan", Age = 18 },
            new() { Id = Guid.NewGuid(), Name = "Petr", Age = 19 },
            new() { Id = Guid.NewGuid(), Name = "Sanek", Age = 20 }
        };
        
        // Act
        var result = _userService.MaxUserAge(users);
        
        // Assert
        Assert.Equal(20, result);
    }
}