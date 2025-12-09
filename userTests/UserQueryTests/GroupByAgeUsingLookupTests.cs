using user;
using user.Models;

namespace userTests.UserQueryTests;

public class GroupByAgeUsingLookupTests
{

    private readonly UserQueryService _userQueryService = new();

    [Fact]
    public void GroupByAgeUsingLookup_ShouldReturnEmpty_WhenEmptyUsersProvided()
    {
        // Arrange
        var users = new List<User>();

        // Act
        var result = _userQueryService.GroupByAgeUsingLookup(users);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GroupByAgeUsingLookup_ShouldGroupUsersWithSameAge_WhenUsersWithSameAgesProvided()
    {
        // Arrange
        var users = new List<User>
        {
            new() { Id = Guid.NewGuid(), Name = "Sanek", Age = 18 },
            new() { Id = Guid.NewGuid(), Name = "Vlad", Age = 19 },
            new() { Id = Guid.NewGuid(), Name = "Misha", Age = 18 }
        };
    
        // Act
        var result = _userQueryService.GroupByAgeUsingLookup(users);
    
        // Assert
        var age18Group = result[18].ToList();
        Assert.Equal(2, age18Group.Count);
    }
    
    [Fact]
    public void GroupByAgeUsingLookup_ShouldGroupUsersWithSameAge_WhenUsersWithSameAgesProvided2()
    {
        // Arrange
        var users = new List<User>
        {
            new() { Id = Guid.NewGuid(), Name = "Sanek", Age = 18 },
            new() { Id = Guid.NewGuid(), Name = "Vlad", Age = 19 },
            new() { Id = Guid.NewGuid(), Name = "Misha", Age = 18 }
        };
    
        // Act
        var result = _userQueryService.GroupByAgeUsingLookup(users);
    
        // Assert
        var age19Group = result[19].ToList();
        Assert.Single(age19Group);
    }
}
