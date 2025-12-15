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
}