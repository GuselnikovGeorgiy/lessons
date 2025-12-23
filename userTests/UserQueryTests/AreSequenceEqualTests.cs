using user;
using user.Models;

namespace userTests.UserQueryTests;

public class AreSequenceEqualTests
{
    private readonly UserQueryService _userQueryService = new();

    [Fact]
    public void AreSequenceEqual_ShouldReturnTrue_WhenSequencesExistAndEqual()
    {
        // Arrange
        var id1 = Guid.NewGuid();
        var id2 = Guid.NewGuid();
        
        var list1 = new List<User>
        {
            new() { Id = id1, Name = "Ivan", Age = 18 },
            new() { Id = id2, Name = "Petr", Age = 19 },
        };
        
        var list2 = new List<User>
        {
            new() { Id = id1, Name = "Ivan", Age = 18 },
            new() { Id = id2, Name = "Petr", Age = 19 },
        };
        
        // Act
        var result = _userQueryService.AreSequencesEqual(list1, list2);
        
        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void AreSequenceEqual_ShouldReturnFalse_WhenSequencesExistAndNotEqual()
    {
        // Arrange
        var id1 = Guid.NewGuid();
        var id2 = Guid.NewGuid();
        
        var list1 = new List<User>
        {
            new() { Id = id1, Name = "Ivan", Age = 18 },
            new() { Id = id2, Name = "Petr", Age = 19 },
        };
        
        var list2 = new List<User>
        {
            new() { Id = id1, Name = "Ivan", Age = 20 },
            new() { Id = id2, Name = "Petr", Age = 19 },
        };
        
        // Act
        var result = _userQueryService.AreSequencesEqual(list1, list2);
        
        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AreSequenceEqual_ShouldReturnFalse_WhenSingleSequenceIsEmpty()
    {
        // Arrange
        var list1 = new List<User>
        {
            new() { Id = Guid.NewGuid(), Name = "Ivan", Age = 18 },
            new() { Id = Guid.NewGuid(), Name = "Petr", Age = 19 },
        };
        var list2 = new List<User>();
        
        // Act
        var result = _userQueryService.AreSequencesEqual(list1, list2);
        
        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void AreSequenceEqual_ShouldReturnTrue_WhenBothSequenceAreEmpty()
    {
        // Arrange
        var list1 = new List<User>();
        var list2 = new List<User>();
        
        // Act
        var result = _userQueryService.AreSequencesEqual(list1, list2);
        
        // Assert
        Assert.True(result);
    }
}