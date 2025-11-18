using nums;

namespace numsTests;

public class GetElementAtOrDefaultTests
{
    private readonly Nums _nums = new();
    
    [Fact]
    public void GetElementAtOrDefault_ShouldReturnElement_WhenIndexInRange()
    {
        // Arrange
        var numbers = new List<int> { 4, 5, 6, 8, 10 };
        var index = 1;
        var expected = 5;

        // Act
        var result = _nums.GetElementAtOrDefault(numbers, index);

        // Assert
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetElementAtOrDefault_ShouldReturnDefault_WhenIndexOutOfRange()
    {
        // Arrange
        var numbers = new List<int> { 4, 5, 6, 8, 10 };
        var index = 6;

        // Act
        var result = _nums.GetElementAtOrDefault(numbers, index);

        // Assert
        Assert.Equal(0, result);
    }
    
    [Fact]
    public void GetElementAtOrDefault_ShouldReturnDefault_WhenIndexIsNegative()
    {
        // Arrange
        var numbers = new List<int> { 4, 5, 6, 8, 10 };
        var index = -1;

        // Act
        var result = _nums.GetElementAtOrDefault(numbers, index);

        // Assert
        Assert.Equal(0, result);
    }
    

    [Fact]
    public void GetElementAtOrDefault_ShouldReturnDefault_WhenEmptyCollectionProvided()
    {
        // Arrange
        var numbers = new List<int>();
        var index = 0;
    
        // Act
        var result = _nums.GetElementAtOrDefault(numbers, index);
        
        // Assert
        Assert.Equal(0, result);
    }
    
    [Fact]
    public void GetElementAtOrDefault_ShouldReturnNull_WhenCollectionEqualsNullProvided()
    {
        // Arrange
        List<int>? numbers = null;
        var index = 0;
    
        // Act
        var result = _nums.GetElementAtOrDefault(numbers, index);
    
        // Assert
        Assert.Null(result);
    }
}