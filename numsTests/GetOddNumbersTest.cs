namespace numsTests;

public class GetOddNumbersTest
{
    private readonly Nums _nums = new();

    [Fact]
    public void GetOddNumbers_ShouldReturnOddNumbers_WhenMixedNumbersProvided()
    {
        // Arrange
        var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        var expected = new List<int> { 1, 3, 5, 7, 9 };

        // Act
        var result = _nums.GetOddNumbers(numbers);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetOddNumbers_ShouldReturnEmpty_WhenOnlyEvenNumbersProvided()
    {
        // Arrange
        var numbers = new List<int> { 2, 4, 6, 8, 10 };
        var expected = new List<int>();

        // Act
        var result = _nums.GetOddNumbers(numbers);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetOddNumbers_ShouldReturnCorrectAnswer_WhenNegativeNumbersProvided()
    {
        // Arrange
        var numbers = new List<int> { -5, -4, -3, -2, -1, 0, 1, 2, 3 };
        var expected = new List<int> { -5, -3, -1, 1, 3 };

        // Act
        var result = _nums.GetOddNumbers(numbers);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetOddNumbers_ShouldReturnEmpty_WhenEmptyCollectionProvided()
    {
        // Arrange
        var numbers = new List<int>();
        var expected = new List<int>();

        // Act
        var result = _nums.GetOddNumbers(numbers);

        // Assert
        Assert.Empty(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetOddNumbers_ShouldReturnEmpty_WhenNullProvided()
    {
        // Arrange
        List<int> numbers = null;
        var expected = new List<int>();

        // Act
        var result = _nums.GetOddNumbers(numbers);

        // Assert
        Assert.Empty(result);
        Assert.Equal(expected, result);
    }
}