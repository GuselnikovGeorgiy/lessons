using user;
using user.Models;

namespace userTests.UserQueryTests;

public class DescendingAgeUsersTests
{
    private readonly UserQueryService _userService = new();
    
    [Fact]
    public void DescendingAgeUsers_ShouldReturnEmpty_WhenNullProvided()
    {
        // Arrange
        ICollection<User>? users = null;

        // Act
        var result = _userService.DescendingAgeUsers(users, 42);

        // Assert
        Assert.Empty(result);
    }
    
    [Fact]
    public void DescendingAgeUsers_ShouldReturnEmpty_WhenEmptyUsersListProvided()
    {
        // Arrange
        ICollection<User> users = new List<User>();

        // Act
        var result = _userService.DescendingAgeUsers(users, 42);

        // Assert
        Assert.Empty(result);
    }
    
    [Fact]
    public void DescendingAgeUsers_ShouldReturnUsers_WhenCorrectArgsProvided()
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
        
        var expectingUsers = new List<User> {  users[4], users[3] };

        // Act
        var result = _userService.DescendingAgeUsers(users, age);

        // Assert
        Assert.Equal(expectingUsers, result);
    }
    
    [Fact]
    public void DescendingAgeUsers_ShouldReturnUsers_WhenNegativeAgeProvided()
    {
        // Arrange
        var age = -20;
        
        var users = new List<User>
        {
            new() { Id = Guid.NewGuid(), Name = "Ivan", Age = 18 },
            new() { Id = Guid.NewGuid(), Name = "Petr", Age = 19 },
            new() { Id = Guid.NewGuid(), Name = "Sanek", Age = 20 },
            new() { Id = Guid.NewGuid(), Name = "Vlad", Age = 21 },
            new() { Id = Guid.NewGuid(), Name = "Misha", Age = 22 }
        };
        
        var expectingUsers =  users.AsEnumerable().Reverse().ToList();


        // Act
        var result = _userService.DescendingAgeUsers(users, age);

        // Assert
        Assert.Equal(expectingUsers, result);
    }
}