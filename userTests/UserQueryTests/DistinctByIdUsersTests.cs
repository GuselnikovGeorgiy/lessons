using user;
using user.Models;

namespace userTests.UserQueryTests;

public class DistinctByIdUsersTests
{
    private readonly UserQueryService _userService = new();

    [Fact]
    public void DistinctByIdUsers_ShouldReturnDistinct_WhenUsersWithSameIdsProvided()
    {
        // Arrange
        var id = Guid.NewGuid();
        
        var users = new List<User>
        {
            new() { Id = id, Age = 20, Name = "Zhorik"},
            new() { Id = id, Age = 22, Name =  "Zhorik"},
        };
        
        var expected = new List<User>
        {
            new() { Id = id, Age = 20, Name = "Zhorik"},
        };

        // Act
        var result = _userService.DistinctByIdUsers(users);

        // Assert
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void DistinctByIdUsers_ShouldReturnEmpty_WhenEmptyProvided()
    {
        // Arrange
        var users = new List<User>();
            
        // Act
        var result = _userService.DistinctByIdUsers(users);

        // Assert
        Assert.Empty(result);
    }
}