using user;
using user.Models;

namespace userTests.UserQueryTests;

public class UniqueUsersUsingClassEquatable
{
    private readonly UserQueryService _userQueryService = new();

    [Fact]
    public void UniqueUsersUsingClassEquatable_ShouldReturnEmpty_WhenEmptyUsersProvided()
    {
        // Arrange
        var users = new List<UserClassEquatable>();
        
        // Act
        var result = _userQueryService.UniqueUsersUsingClassEquatable(users);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void UniqueUsersUsingClassEquatable_ShouldReturnUniqueUsers_WhenMultipleUsersProvided()
    {
        // Arrange
        var guid1 = Guid.NewGuid();
        var guid2 = Guid.NewGuid();
        var guid3 = Guid.NewGuid();
        
        var users = new List<UserClassEquatable>
        {
            new() { Id = guid1, Name = "Ivan", Age = 19 },
            new() { Id = guid2, Name = "Sanek", Age = 20 },
            new() { Id = guid3, Name = "Vlad", Age = 21 },
            new() { Id = guid2, Name = "Sanek", Age = 20 },
            new() { Id = guid1, Name = "Ivan", Age = 19 }
        };

        var expected = new HashSet<UserClassEquatable> { users[0], users[1], users[2] };

        // Act
        var result = _userQueryService.UniqueUsersUsingClassEquatable(users);

        // Assert
        Assert.Equal(expected, result);
    }
}