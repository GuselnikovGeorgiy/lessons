using nums;

namespace numsTests;

public class AreSequenceEqualTests
{
    private readonly Nums _numsService = new();

    [Fact]
    public void AreSequenceEqual_ShouldReturnTrue_WhenSequencesExistAndEqual()
    {
        // Arrange
        var list1 = Enumerable.Range(0, 100).ToList();
        var list2 = Enumerable.Range(0, 100).ToList();
        
        // Act
        var result = _numsService.AreSequenceEqual(list1, list2);
        
        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void AreSequenceEqual_ShouldReturnFalse_WhenSequencesExistAndNotEqual()
    {
        // Arrange
        var list1 = Enumerable.Range(0, 100).ToList();
        var list2 = Enumerable.Range(0, 90).ToList();
        
        // Act
        var result = _numsService.AreSequenceEqual(list1, list2);
        
        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AreSequenceEqual_ShouldReturnFalse_WhenSingleSequenceIsEmpty()
    {
        // Arrange
        var list1 = Enumerable.Range(0, 100).ToList();
        var list2 = new List<int>();
        
        // Act
        var result = _numsService.AreSequenceEqual(list1, list2);
        
        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void AreSequenceEqual_ShouldReturnTrue_WhenBothSequenceAreEmpty()
    {
        // Arrange
        var list1 = new List<int>();
        var list2 = new List<int>();
        
        // Act
        var result = _numsService.AreSequenceEqual(list1, list2);
        
        // Assert
        Assert.True(result);
    }
}