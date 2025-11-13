namespace numsTests;

public class GetPositiveNumbersTests
{
    private readonly Nums _nums = new();

    [Fact]
    public void GetPositiveNumbers_ShouldReturnPositive_WhenMixedNumbersProvided()
    {
        // Arrange
        var numbers = new List<int> { -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        var expected = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        // Act
        var result = _nums.GetPositiveNumbers(numbers);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetPositiveNumbers_ShouldReturnEmpty_WhenNegativeOrZeroProvided()
    {
        // Arrange
        var numbers = new List<int> { -4, -3, -2, -1, 0 };
        var expected = new List<int>();

        // Act
        var result = _nums.GetPositiveNumbers(numbers);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetPositiveNumbers_ShouldReturnEmpty_WhenEmptyCollectionProvided()
    {
        // Arrange
        var numbers = new List<int>();
        var expected = new List<int>();

        // Act
        var result = _nums.GetPositiveNumbers(numbers);

        // Assert
        Assert.Empty(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetPositiveNumbers_ShouldReturnEmpty_WhenNullProvided()
    {
        // Arrange
        List<int>? numbers = null;
        var expected = new List<int>();

        // Act
        var result = _nums.GetPositiveNumbers(numbers);

        // Assert
        Assert.Empty(result);
        Assert.Equal(expected, result);
    }
}