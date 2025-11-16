namespace numsTests;

public class GetFirstOddNumberTests
{
    private readonly Nums _nums = new();
    
    [Fact]
    public void GetFirstOddNumber_ShouldReturnOddNumbers_WhenMixedNumbersProvided()
    {
        // Arrange
        var numbers = new List<int> { 2, 4, 5, 6, 7, 8, 9 };
        var expected = 5;

        // Act
        var result = _nums.GetFirstOddNumber(numbers);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetFirstOddNumber_ShouldReturnNull_WhenOnlyEvenNumbersProvided()
    {
        // Arrange
        var numbers = new List<int> { 2, 4, 6, 8, 10 };

        // Act
        var result = _nums.GetFirstOddNumber(numbers);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetFirstOddNumber_ShouldReturnCorrectAnswer_WhenNegativeNumbersProvided()
    {
        // Arrange
        var numbers = new List<int> { -6, -5, -4, -3, -2, -1, 0, 1, 2, 3 };
        var expected = -5;

        // Act
        var result = _nums.GetFirstOddNumber(numbers);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetFirstOddNumber_ShouldReturnNull_WhenEmptyCollectionProvided()
    {
        // Arrange
        var numbers = new List<int>();

        // Act
        var result = _nums.GetFirstOddNumber(numbers);
        
        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetFirstOddNumber_ShouldReturnNull_WhenNullProvided()
    {
        // Arrange
        List<int>? numbers = null;

        // Act
        var result = _nums.GetFirstOddNumber(numbers);

        // Assert
        Assert.Null(result);
    }
}