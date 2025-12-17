using user;
using user.Models;

namespace userTests.UserQueryTests;

public class SumUserAgeTests
{
    private readonly UserQueryService _userService = new();

    [Fact]
    public void SumUserAge_ShouldReturnZero_WhenEmptyUserListProvided()
    {
        // Arrange
        var users = new List<User>();
        
        // Act
        var result = _userService.SumUserAge(users);
        
        // Assert
        Assert.Equal(0, result);
    }
    
    [Fact]
    public void SumUserAge_ShouldReturnCount_WhenUserListProvided()
    {
        // Arrange
        var users = new List<User>
        {
            new() { Id = Guid.NewGuid(), Name = "Ivan", Age = 18 },
            new() { Id = Guid.NewGuid(), Name = "Petr", Age = 19 },
            new() { Id = Guid.NewGuid(), Name = "Sanek", Age = 20 }
        };
        
        // Act
        var result = _userService.SumUserAge(users);
        
        // Assert
        Assert.Equal(18+19+20, result);
    }
}