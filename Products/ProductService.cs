using Products.Models;

namespace Products;

public class ProductService
{
    public List<(Product, Product?)> CompareProducts(
        ICollection<Product> currentProducts,
        ICollection<Product> previousProducts)
    {
        
        return currentProducts
            .Zip(previousProducts,
                (current, previous) => (current, (Product?)previous))
            .ToList();
    }

    public List<ProductRecord> GetPaginatedProducts(List<ProductRecord> products, int skip, int take)
    {
        if (products.Count == 0 || take <= 0)
            return [];
        
        var skipValue = Math.Max(skip, 0);

        if (skipValue > products.Count)
            return [];
        
        var takeValue = Math.Min(take, products.Count - skipValue);
        
        return products[skipValue..(skipValue + takeValue)];
    }
    
    public void DemonstrateRangeUsage()
    {
        var products = new List<ProductRecord>
        {
            new(1, "Product_1", 100),
            new(2, "Product_2", 110),
            new(3, "Product_3", 120),
            new(4, "Product_4", 130),
            new(5, "Product_5", 140)
        };
    
        // Использование Range для получения среза коллекции
        var middleProducts = products[1..4]; // Продукты с индексами 1, 2, 3
        var lastTwoProducts = products[^2..]; // Последние два продукта
        var firstThreeProducts = products[..3]; // Первые три продукта
    }
}