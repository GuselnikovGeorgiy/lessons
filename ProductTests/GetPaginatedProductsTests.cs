using Products;
using Products.Models;

namespace ProductTests;

public class GetPaginatedProductsTests
{
    private readonly ProductService _productService = new();

    [Fact]
    public void GetPaginatedProducts_ShouldReturnEmpty_WhenEmptyListProvided()
    {
        // Arrange
        var products = new List<ProductRecord>();

        // Act
        var result = _productService.GetPaginatedProducts(products, 0, 1);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GetPaginatedProducts_ShouldReturnRange_WhenProductListProvided()
    {
        // Arrange
        var products = new List<ProductRecord>
        {
            new(1, "Product_1", 100),
            new(2, "Product_2", 110),
            new(3, "Product_3", 120),
            new(4, "Product_4", 130),
            new(5, "Product_5", 140)
        };

        var expected = new List<ProductRecord> { products[0] }; 
        
        // Act
        var result = _productService.GetPaginatedProducts(products, 0, 1);
        
        // Assert
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetPaginatedProducts_ShouldReturnEmpty_WhenSkipGreaterThanListCountProvided()
    {
        // Arrange
        var products = new List<ProductRecord>
        {
            new(1, "Product_1", 100),
            new(2, "Product_2", 110),
            new(3, "Product_3", 120),
            new(4, "Product_4", 130),
            new(5, "Product_5", 140)
        };
        
        // Act
        var result = _productService.GetPaginatedProducts(products, 100, 1);
        
        // Assert
        Assert.Empty(result);
    }
    
    [Fact]
    public void GetPaginatedProducts_ShouldReturnEmpty_WhenNonPositiveTakeProvided()
    {
        // Arrange
        var products = new List<ProductRecord>
        {
            new(1, "Product_1", 100),
            new(2, "Product_2", 110),
            new(3, "Product_3", 120),
            new(4, "Product_4", 130),
            new(5, "Product_5", 140)
        };
        
        // Act
        var result = _productService.GetPaginatedProducts(products, 0, -1);
        
        // Assert
        Assert.Empty(result);
    }
    
    [Fact]
    public void GetPaginatedProducts_ShouldReturnRange_WhenNegativeSkipProvided()
    {
        // Arrange
        var products = new List<ProductRecord>
        {
            new(1, "Product_1", 100),
            new(2, "Product_2", 110),
        };

        var expected = new List<ProductRecord> { products[0], products[1] }; 
        
        // Act
        var result = _productService.GetPaginatedProducts(products, -1, 2);
        
        // Assert
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetPaginatedProducts_ShouldReturnRange_WhenTakeGreaterThanListCountProvided()
    {
        // Arrange
        var products = new List<ProductRecord>
        {
            new(1, "Product_1", 100),
            new(2, "Product_2", 110),
            new(3, "Product_3", 120),
            new(4, "Product_4", 130),
            new(5, "Product_5", 140)
        };

        var expected = new List<ProductRecord> { products[3], products[4] }; 
        
        // Act
        var result = _productService.GetPaginatedProducts(products, 3, 100);
        
        // Assert
        Assert.Equal(expected, result);
    }
}