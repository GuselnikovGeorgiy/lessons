using nums;

namespace numsTests;

public class GetSumTests
{
    private readonly Nums  _numsService = new();

    [Fact]
    public void GetSum_ShouldReturnZero_WhenEmptyArrayProvided()
    {
        // Arrange
        var array = Array.Empty<int>();
        
        // Act
        var result = _numsService.GetSum(array);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void GetSum_ShouldReturnSum_WhenValidArrayProvided()
    {
        // Arrange
        var array = new[] { 1, 2, 3 };
        
        // Act
        var result = _numsService.GetSum(array);
        
        // Assert
        Assert.Equal(6, result);
    }
}