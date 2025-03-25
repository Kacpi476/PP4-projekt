using EShop.Domain.Models;
using EShop.Domain.Repositories;

namespace EShop.Domain.Seeders;

public class EShopSeeder : IEShopSeeder
{
    private readonly DataContext _context;

    public EShopSeeder(DataContext context)
    {
        _context = context;
    }

    public async Task Seed()
    {
        if (!_context.Products.Any())
        {
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "jablko" },
                new Product { Id = 2, Name = "gruszka" },
                new Product { Id = 3, Name = "pomarancz" }
            };
            _context.Products.AddRange(products);
            _context.SaveChanges();
        }
    }
}
