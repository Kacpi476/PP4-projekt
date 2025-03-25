using EShop.Domain.Models;

namespace EShop.Application;

public interface IProductService
{
    List<Product> GetAllProducts();
    Product GetProductById(int id);
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(int id);
}