namespace numsTests;

public class GetLastOddNumberTests
{
    private readonly Nums _nums = new();
    
    [Fact]
    public void GetLastOddNumber_ShouldReturnOddNumbers_WhenMixedNumbersProvided()
    {
        // Arrange
        var numbers = new List<int> { 2, 4, 5, 6, 7, 8 };
        var expected = 7;

        // Act
        var result = _nums.GetLastOddNumber(numbers);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetLastOddNumber_ShouldReturnNull_WhenOnlyEvenNumbersProvided()
    {
        // Arrange
        var numbers = new List<int> { 2, 4, 6, 8, 10 };

        // Act
        var result = _nums.GetLastOddNumber(numbers);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetLastOddNumber_ShouldReturnCorrectAnswer_WhenNegativeNumbersProvided()
    {
        // Arrange
        var numbers = new List<int> { -5, -4, -3, -2, -1, 0, 1, 2, 3, 4 };
        var expected = 3;

        // Act
        var result = _nums.GetLastOddNumber(numbers);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetLastOddNumber_ShouldReturnNull_WhenEmptyCollectionProvided()
    {
        // Arrange
        var numbers = new List<int>();

        // Act
        var result = _nums.GetLastOddNumber(numbers);
        
        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetLastOddNumber_ShouldReturnNull_WhenNullProvided()
    {
        // Arrange
        List<int>? numbers = null;

        // Act
        var result = _nums.GetLastOddNumber(numbers);

        // Assert
        Assert.Null(result);
    }
}