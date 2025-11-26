using user;

namespace userTests.UserQueryTests;

public class ReverseUserIdsTests
{
    private readonly UserQueryService _userService = new();

    [Fact]
    public void ReverseUserIds_ShouldReturnEmpty_WhenNullUserIdsProvided()
    {
        // Arrange
        ICollection<int>? usersIds = null;
        
        // Act
        var result = _userService.ReverseUserIds(usersIds);

        // Assert
        Assert.Empty(result);
    }
    
    [Fact]
    public void ReverseUserIds_ShouldReturnEmpty_WhenEmptyUserIdsProvided()
    {
        // Arrange
        ICollection<int> usersIds = [];
        
        // Act
        var result = _userService.ReverseUserIds(usersIds);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void ReverseUserIds_ShouldReturnReversedIds_WhenIdsProvided()
    {
        // Arrange
        var usersIds = new List<int> { 1, 2, 3 };
        
        // Act
        var result = _userService.ReverseUserIds(usersIds);
        
        // Assert
        Assert.Equal(new List<int> { 3, 2, 1 }, result);
    }
    
}