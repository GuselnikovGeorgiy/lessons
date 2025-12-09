using user;
using user.Models;

namespace userTests.UserQueryTests;

public class GroupByAgeUsingDictionaryTests
{
    private readonly UserQueryService _userQueryService = new();

    [Fact]
    public void GroupByAgeUsingDictionary_ShouldReturnEmpty_WhenEmptyUsersProvided()
    {
        // Arrange
        var users = new List<User>();

        // Act
        var result = _userQueryService.GroupByAgeUsingDictionary(users);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GroupByAgeUsingDictionary_ShouldAddSingleUser_WhenUsersWithSameAgesProvided()
    {
        // Arrange
        var users = new List<User>
        {
            new() { Id = Guid.NewGuid(), Name = "Sanek", Age = 18 },
            new() { Id = Guid.NewGuid(), Name = "Vlad", Age = 19 },
            new() { Id = Guid.NewGuid(), Name = "Misha", Age = 18 }
        };

        var expected = new Dictionary<int, User>
        {
            { users[0].Age, users[0] },
            { users[1].Age, users[1] },
        };

        // Act
        var result = _userQueryService.GroupByAgeUsingDictionary(users);
        
        // Assert
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GroupByAgeUsingDictionary_ShouldReturnDictionary_WhenUsersWithUniqueAgesProvided()
    {
        // Arrange
        var users = new List<User>
        {
            new() { Id = Guid.NewGuid(), Name = "Sanek", Age = 17 },
            new() { Id = Guid.NewGuid(), Name = "Vlad", Age = 19 },
            new() { Id = Guid.NewGuid(), Name = "Misha", Age = 18 }
        };

        var expected = new Dictionary<int, User>
        {
            { users[0].Age, users[0] },
            { users[1].Age, users[1] },
            { users[2].Age, users[2] }
        };

        // Act
        var result = _userQueryService.GroupByAgeUsingDictionary(users);
        
        // Assert
        Assert.Equal(expected, result);
    }
}