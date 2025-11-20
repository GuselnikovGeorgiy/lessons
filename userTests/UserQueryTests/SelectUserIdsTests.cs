using user;
using user.Models;

namespace userTests.UserQueryTests;

public class SelectUserIdsTests
{
    private readonly UserQueryService _userService = new();
    
    [Fact]
    public void SelectUserIds_ShouldReturnEmpty_WhenNullProvided()
    {
        // Arrange
        ICollection<User>? users = null;

        // Act
        var result = _userService.SelectUserIds(users, 42);

        // Assert
        Assert.Empty(result);
    }
    
    [Fact]
    public void SelectUserIds_ShouldReturnEmpty_WhenEmptyUsersListProvided()
    {
        // Arrange
        ICollection<User> users = new List<User>();
        
        // Act
        var result = _userService.SelectUserIds(users, 42);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void SelectUserIds_ShouldReturnUserIds_WhenCorrectArgsProvided()
    {
        // Arrange
        var age = 20;
        
        var users = new List<User>
        {
            new() { Id = Guid.NewGuid(), Name = "Ivan", Age = 18 },
            new() { Id = Guid.NewGuid(), Name = "Petr", Age = 19 },
            new() { Id = Guid.NewGuid(), Name = "Sanek", Age = 20 },
            new() { Id = Guid.NewGuid(), Name = "Vlad", Age = 21 },
            new() { Id = Guid.NewGuid(), Name = "Misha", Age = 22 }
        };
        
        var expectingUserIds = new List<Guid> { users[3].Id, users[4].Id };
        
        // Act
        var result = _userService.SelectUserIds(users, age);
        
        // Assert
        Assert.Equal(expectingUserIds, result);
    }

    [Fact]
    public void SelectUserIds_ShouldReturnAllIds_WhenNegativeInput()
    {
        // Arrange
        var age = -42;
        
        var users = new List<User>
        {
            new() { Id = Guid.NewGuid(), Name = "Ivan", Age = 18 },
            new() { Id = Guid.NewGuid(), Name = "Petr", Age = 19 },
            new() { Id = Guid.NewGuid(), Name = "Sanek", Age = 20 },
            new() { Id = Guid.NewGuid(), Name = "Vlad", Age = 21 },
            new() { Id = Guid.NewGuid(), Name = "Misha", Age = 22 }
        };
        
        var expectingUserIds = users.Select(user => user.Id).ToList();
        
        // Act
        var result = _userService.SelectUserIds(users, age);
        
        // Assert
        Assert.Equal(expectingUserIds, result);
    }
}