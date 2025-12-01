using nums;

namespace numsTests;

public class CastIntToLongTests
{
    private readonly Nums _nums = new();

    [Fact]
    public void CastIntToLong_ShouldReturnLongCollection_WhenIntCollectionProvided()
    {
        // Arrange
        var intNums = new List<int> { 1, 2, 3, 4, 5 };
        var expected = new List<long> {1L, 2L, 3L, 4L, 5L};

        // Act
        var result = _nums.CastIntToLong(intNums);

        // Assert
        Assert.Equal(expected, result);
    }
}