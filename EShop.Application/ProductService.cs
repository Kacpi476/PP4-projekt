using EShop.Domain.Models;
using EShop.Domain.Repositories;

namespace EShop.Application;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public List<Product> GetAllProducts() => _productRepository.GetAllProducts();
    
    public Product? GetProductById(int id) => _productRepository.GetProductById(id);

    public void AddProduct(Product product)
    {
        if(string.IsNullOrWhiteSpace(product.Name))
            throw new ArgumentException("Product name is required");
        _productRepository.AddProduct(product);
    }

    public void UpdateProduct(Product product)
    {
        _productRepository.UpdateProduct(product);
    }

    public void DeleteProduct(int id)
    {
        _productRepository.DeleteProduct(id);
    }
}