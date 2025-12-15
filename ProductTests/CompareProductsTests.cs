using Products;
using Products.Models;

namespace ProductTests;

public class CompareProductsTests
{
    private readonly ProductService _productService = new();
    
    private static readonly Product Product1 = new() { Id = 1, Name = "A", Price = 1m };

    private static readonly Product Product2 = new() { Id = 2, Name = "B", Price = 2m };

    private static readonly Product Product3 = new() { Id = 3, Name = "C", Price = 3m };
    
    [Fact]
    public void CompareProducts_ShouldReturnEmpty_WhenEmptyCollectionsProvided()
    {
        // Arrange
        var current = new List<Product>();
        var previous = new List<Product>();

        // Act
        var result = _productService.CompareProducts(current, previous);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void CompareProducts_ShouldReturnPairsOfProducts_WhenCollectionsWithSameLengthProvided()
    {
        // Arrange
        var current = new List<Product> { Product1, Product2 };
        var previous = new List<Product> { Product2, Product3 };

        // Act
        var result = _productService.CompareProducts(current, previous);

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal(Product1, result[0].Item1);
        Assert.Equal(Product2, result[0].Item2);
        Assert.Equal(Product2, result[1].Item1);
        Assert.Equal(Product3, result[1].Item2);
    }

    [Fact]
    public void CompareProducts_ShouldReturnPairsOfProductsWithNull_WhenCollectionsWithDifferLengthProvided()
    {
        // Arrange
        var current = new List<Product> { Product1, Product2, Product3 };
        var previous = new List<Product> { Product1 };

        // Act
        var result = _productService.CompareProducts(current, previous);

        // Assert
        Assert.Single(result);
        Assert.Equal(Product1, result[0].Item1);
        Assert.Equal(Product1, result[0].Item2);
    }

    [Fact]
    public void CompareProducts_ShouldReturnPairsOfProductsWithNull_WhenCollectionsWithDifferLengthProvided2()
    {
        // Arrange
        var current = new List<Product> { Product1 };
        var previous = new List<Product> { Product1, Product2, Product3 };

        // Act
        var result = _productService.CompareProducts(current, previous);

        // Assert
        Assert.Single(result);
        Assert.Equal(Product1, result[0].Item1);
        Assert.Equal(Product1, result[0].Item2);
    }
}