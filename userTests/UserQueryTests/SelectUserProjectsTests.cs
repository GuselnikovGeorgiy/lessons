using user;
using user.Models;

namespace userTests.UserQueryTests;

public class SelectUserProjectsTests
{
    private readonly UserQueryService _userService = new();

    [Fact]
    public void SelectUserProjects_ShouldReturnEmpty_WhenNullProvided()
    {
        // Arrange
        ICollection<User>? users = null;
        
        // Act
        var result = _userService.SelectUserProjects(users, 42);
        
        // Assert
        Assert.Empty(result);
    }
    
    [Fact]
    public void SelectUserProjects_ShouldReturnEmpty_WhenEmptyUsersListProvided()
    {
        // Arrange
        var users = new List<User>();
        
        // Act
        var result = _userService.SelectUserProjects(users, 42);
        
        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void SelectUserProjects_ShouldReturnEmpty_WhenUsersWithoutProjectsProvided()
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
        
        // Act
        var result = _userService.SelectUserProjects(users, age);
        
        // Assert
        Assert.Empty(result);
    }
    
    [Fact]
    public void SelectUserProjects_ShouldReturnUsersProjects_WhenUsersWithProjectsProvided()
    {
        // Arrange
        var age = 20;
        
        var users = new List<User>
        {
            new() { Id = Guid.NewGuid(), Name = "Ivan", Age = 18 },
            new()
            {
                Id = Guid.NewGuid(), Name = "Petr", Age = 19,
                Projects = new List<Project>
                {
                    new Project { Id = Guid.NewGuid(), Name = "abc" },
                    new Project { Id = Guid.NewGuid(), Name = "qwe" }
                }
            },
            new() { Id = Guid.NewGuid(), Name = "Sanek", Age = 20 },
            new() { Id = Guid.NewGuid(), Name = "Vlad", Age = 21 },
            new()
            {
                Id = Guid.NewGuid(), Name = "Misha", Age = 22,
                Projects = new List<Project> 
                { 
                    new Project { Id = Guid.NewGuid(), Name = "cde" },
                    new Project { Id = Guid.NewGuid(), Name = "qwe" },
                    new Project { Id = Guid.NewGuid(), Name = "abc" },
                }
            },
            new() { Id = Guid.NewGuid(), Name = "Gena", Age = 23 },
            new()
            {
                Id = Guid.NewGuid(), Name = "Alex", Age = 24,
                Projects = new List<Project>
                {
                    new Project { Id = Guid.NewGuid(), Name = "zxc" } 
                }
            }
        };
        
        // Act
        var result = _userService.SelectUserProjects(users, age);
        
        // Assert
        Assert.Equal(4, result.Count);
    }
    
    [Fact]
    public void SelectUserProjects_ShouldReturnUsersProjects_WhenNegativeAgeProvided()
    {
        // Arrange
        var age = -20;
        
        var users = new List<User>
        {
            new() { Id = Guid.NewGuid(), Name = "Ivan", Age = 18 },
            new()
            {
                Id = Guid.NewGuid(), Name = "Petr", Age = 19,
                Projects = new List<Project>
                {
                    new Project { Id = Guid.NewGuid(), Name = "abc" },
                    new Project { Id = Guid.NewGuid(), Name = "qwe" }
                }
            },
            new() { Id = Guid.NewGuid(), Name = "Sanek", Age = 20 },
            new() { Id = Guid.NewGuid(), Name = "Vlad", Age = 21 },
            new()
            {
                Id = Guid.NewGuid(), Name = "Misha", Age = 22,
                Projects = new List<Project> 
                { 
                    new Project { Id = Guid.NewGuid(), Name = "cde" },
                    new Project { Id = Guid.NewGuid(), Name = "qwe" },
                    new Project { Id = Guid.NewGuid(), Name = "abc" },
                }
            },
            new() { Id = Guid.NewGuid(), Name = "Gena", Age = 23 },
            new()
            {
                Id = Guid.NewGuid(), Name = "Alex", Age = 24,
                Projects = new List<Project>
                {
                    new Project { Id = Guid.NewGuid(), Name = "zxc" } 
                }
            }
        };
        
        // Act
        var result = _userService.SelectUserProjects(users, age);
        
        // Assert
        Assert.Equal(6, result.Count);
    }
}