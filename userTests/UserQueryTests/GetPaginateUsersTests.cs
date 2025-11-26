using user;
using user.Models;

namespace userTests.UserQueryTests;

public class GetPaginateUsersTests
{
    private readonly UserQueryService _userService = new();
    
    [Fact]
    public void GetPaginateUsers_ShouldReturnEmpty_WhenNullUsersProvided()
    {
        // Arrange
        IList<User>? users = null;
        
        // Act
        var paginate = _userService.GetPaginateUsers(users, 0, 10);
        var result = paginate.CurrentUsersPage;
        var resultCount = paginate.TotalCount;
        
        // Assert
        Assert.Empty(result);
        Assert.Equal(0, resultCount);
    }
    
    [Fact]
    public void GetPaginateUsers_ShouldReturnEmpty_WhenEmptyUsersProvided()
    {
        // Arrange
        IList<User> users = [];
        
        // Act
        var paginate = _userService.GetPaginateUsers(users, 0, 10);
        var result = paginate.CurrentUsersPage;
        var resultCount = paginate.TotalCount;
        
        // Assert
        Assert.Empty(result);
        Assert.Equal(0, resultCount);
    }
    
    [Fact]
    public void GetPaginateUsers_ShouldReturnEmpty_WhenZeroTakesProvided()
    {
        // Arrange
        var users = new List<User>
        {
            new() { Id = Guid.NewGuid(), Name = "Ivan", Age = 18 },
            new() { Id = Guid.NewGuid(), Name = "Petr", Age = 19 },
            new() { Id = Guid.NewGuid(), Name = "Sanek", Age = 20 },
            new() { Id = Guid.NewGuid(), Name = "Vlad", Age = 21 },
            new() { Id = Guid.NewGuid(), Name = "Misha", Age = 22 }
        };
        
        // Act
        var paginate = _userService.GetPaginateUsers(users, 0, 0);
        var result = paginate.CurrentUsersPage;
        
        // Assert
        Assert.Empty(result);
    }
    
    [Fact]
    public void GetPaginateUsers_ShouldReturnEmpty_WhenSkipMoreThanUsersCountProvided()
    {
        // Arrange
        var users = new List<User>
        {
            new() { Id = Guid.NewGuid(), Name = "Ivan", Age = 18 },
            new() { Id = Guid.NewGuid(), Name = "Petr", Age = 19 },
            new() { Id = Guid.NewGuid(), Name = "Sanek", Age = 20 },
            new() { Id = Guid.NewGuid(), Name = "Vlad", Age = 21 },
            new() { Id = Guid.NewGuid(), Name = "Misha", Age = 22 }
        };
        
        // Act
        var paginate = _userService.GetPaginateUsers(users, 6, 10);
        var result = paginate.CurrentUsersPage;
        
        // Assert
        Assert.Empty(result);
    }
    
    [Fact]
    public void GetPaginateUsers_ShouldReturnUsers_WhenCorrectArgsProvided()
    {
        // Arrange
        var users = new List<User>
        {
            new() { Id = Guid.NewGuid(), Name = "Ivan", Age = 18 },
            new() { Id = Guid.NewGuid(), Name = "Petr", Age = 19 },
            new() { Id = Guid.NewGuid(), Name = "Sanek", Age = 20 },
            new() { Id = Guid.NewGuid(), Name = "Vlad", Age = 21 },
            new() { Id = Guid.NewGuid(), Name = "Misha", Age = 22 }
        };
        
        // Act
        var paginate = _userService.GetPaginateUsers(users, 2, 10);
        var result = paginate.CurrentUsersPage;
        
        // Assert
        Assert.NotEmpty(result);
        Assert.Equal(3, result.Count);
        Assert.Equal(new List<User> { users[2], users[3], users[4] }, result);
    }
}