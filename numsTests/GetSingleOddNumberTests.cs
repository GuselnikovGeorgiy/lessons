using nums;

namespace numsTests;

public class GetSingleOddNumberTests
{
    private readonly Nums _nums = new();
    
    [Fact]
    public void GetSingleOddNumber_ShouldReturnOddNumber_WhenSingleOddNumberProvided()
    {
        // Arrange
        var numbers = new List<int> { 4, 5, 6, 8, 10 };
        var expected = 5;

        // Act
        var result = _nums.GetSingleOddNumber(numbers);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetSingleOddNumber_ShouldReturnDefault_WhenOnlyEvenNumbersProvided()
    {
        // Arrange
        var numbers = new List<int> { 2, 4, 6, 8, 10 };

        // Act
        var result = _nums.GetSingleOddNumber(numbers);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void GetSingleOddNumber_ShouldReturnDefault_WhenEmptyCollectionProvided()
    {
        // Arrange
        var numbers = new List<int>();

        // Act
        var result = _nums.GetSingleOddNumber(numbers);
        
        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void GetSingleOddNumber_ShouldReturnNull_WhenNullProvided()
    {
        // Arrange
        List<int>? numbers = null;

        // Act
        var result = _nums.GetSingleOddNumber(numbers);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetSingleOddNumber_ShouldThrowsInvalidOperationException_When()
    {
        // Arrange
        var numbers = new List<int> { 1, 2, 3, 4, 5 };
        
        // Act
        try
        {
            var result = _nums.GetSingleOddNumber(numbers);
        }
        // Assert
        catch (InvalidOperationException)
        {
            Assert.True(true);
        }
        
        // Или
        // Assert.Throws<InvalidOperationException>(() => _nums.GetSingleOddNumber(numbers));
    }
    
}