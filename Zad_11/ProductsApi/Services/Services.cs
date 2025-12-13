using ProductsApi.Models;

namespace ProductsApi.Services
{
    public class ProductService
    {
        private readonly List<Product> _products = new()
        {
            new Product { Id = 1, Name = "Laptop", Price = 3500 },
            new Product { Id = 2, Name = "Smartphone", Price = 2500 }
        };

        public IEnumerable<Product> GetAll() => _products;
        public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

        public void Add(Product product)
        {
            product.Id = _products.Max(p => p.Id) + 1;
            _products.Add(product);
        }

        public void Update(int id, Product product)
        {
            var existing = GetById(id);
            if (existing is null) return;
            existing.Name = product.Name;
            existing.Price = product.Price;
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            if (product is not null) _products.Remove(product);
        }
    }
}
