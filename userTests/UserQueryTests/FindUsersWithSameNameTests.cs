using user;
using user.Models;

namespace userTests.UserQueryTests;

public class FindUsersWithSameNameTests
{
    private readonly UserQueryService _userService = new();

    [Fact]
    public void FindUsersWithSameName_ShouldReturnUsersWithSameName_WhenUsersWithSameNameExists()
    {
        // Arrange
        var firstGroup = new List<User>
        {
            new() { Id = Guid.NewGuid(), Name = "Vlad", Age = 22 },
            new() { Id = Guid.NewGuid(), Name = "Leha", Age = 22 }
        }; 
        
        var secondGroup = new List<User>
        {
            new() { Id = Guid.NewGuid(), Name = "Vlad", Age = 22 },
            new() { Id = Guid.NewGuid(), Name = "Petya", Age = 22 }
        };

        var expected = new List<User>
        {
            firstGroup[0]
        };

        // Act
        var result = _userService.FindUsersWithSameName(firstGroup, secondGroup);

        // Assert
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void FindUsersWithSameName_ShouldReturnEmpty_WhenEmptyGroupProvided()
    {
        // Arrange
        var firstGroup = new List<User>
        {
            new() { Id = Guid.NewGuid(), Name = "Vlad", Age = 22 },
            new() { Id = Guid.NewGuid(), Name = "Leha", Age = 22 }
        }; 
        
        var secondGroup = new List<User>();
        
        // Act
        var result = _userService.FindUsersWithSameName(firstGroup, secondGroup);

        // Assert
        Assert.Empty(result);
    }
    
    [Fact]
    public void FindUsersWithSameName_ShouldReturnEmpty_WhenBothGroupsAreEmpty()
    {
        // Arrange
        var firstGroup = new List<User>();
        
        var secondGroup = new List<User>();
        
        // Act
        var result = _userService.FindUsersWithSameName(firstGroup, secondGroup);

        // Assert
        Assert.Empty(result);
    }
    
    [Fact]
    public void FindUsersWithSameName_ShouldReturnEmpty_WhenGroupsDoNotHaveSameNames()
    {
        // Arrange
        var firstGroup = new List<User>
        {
            new() { Id = Guid.NewGuid(), Name = "Vlad", Age = 22 },
            new() { Id = Guid.NewGuid(), Name = "Leha", Age = 22 }
        }; 
        
        var secondGroup = new List<User>
        {
            new() { Id = Guid.NewGuid(), Name = "Sasha", Age = 22 },
            new() { Id = Guid.NewGuid(), Name = "Petya", Age = 22 }
        };

        // Act
        var result = _userService.FindUsersWithSameName(firstGroup, secondGroup);

        // Assert
        Assert.Empty(result);
    }
}