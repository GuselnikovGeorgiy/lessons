using System.Collections.ObjectModel;
using user;
using user.Models;

namespace userTests.UserQueryTests;

public class IsUserAdultTests
{
    private readonly UserQueryService _userService = new();

    [Fact]
    public void AnyAdultUsers_ShouldReturnFalse_WhenNullCollectionProvided()
    {
        // Arrange
        Collection<User>? users = null;
        
        // Act
        var result = _userService.AnyAdultUser(users);
        
        // Assert
        Assert.False(result);
    }   
    
    [Fact]
    public void AnyAdultUsers_ShouldReturnFalse_WhenEmptyCollectionProvided()
    {
        // Arrange
        Collection<User> users = [];
        
        // Act
        var result = _userService.AnyAdultUser(users);
        
        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyAdultUsers_ShouldReturnTrue_WhenAtLeastOneAdultProvided()
    {
        // Arrange
        var users = new Collection<User>
        {
            new() { Id = Guid.NewGuid(), Name = "Sanek", Age = 16 },
            new() { Id = Guid.NewGuid(), Name = "Vlad", Age = 17 },
            new() { Id = Guid.NewGuid(), Name = "Misha", Age = 18 }
        };
        
        // Act
        var result = _userService.AnyAdultUser(users);
        
        // Assert
        Assert.True(result);
    }

    [Fact] public void AllAdultUsers_ShouldReturnTrue_WhenAllProvidedUsersAreAdults()
    {
        // Arrange
        var users = new Collection<User>
        {
            new() { Id = Guid.NewGuid(), Name = "Sanek", Age = 18 },
            new() { Id = Guid.NewGuid(), Name = "Vlad", Age = 19 },
            new() { Id = Guid.NewGuid(), Name = "Misha", Age = 18 }
        };
        
        // Act
        var result = _userService.AllAdultUsers(users);
        
        // Assert
        Assert.True(result);
    }
    
    [Fact] public void ContainsAdultUsers_ShouldReturnTrue_WhenUserAgeIs18()
    {
        // Arrange
        var users = new Collection<User>
        {
            new() { Id = Guid.NewGuid(), Name = "Sanek", Age = 17 },
            new() { Id = Guid.NewGuid(), Name = "Vlad", Age = 19 },
            new() { Id = Guid.NewGuid(), Name = "Misha", Age = 18 }
        };
        
        // Act
        var result = _userService.ContainsAdultUser(users);
        
        // Assert
        Assert.True(result);
    }
}