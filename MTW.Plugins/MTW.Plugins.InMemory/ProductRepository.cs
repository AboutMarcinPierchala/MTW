using MTW.CoreBusiness;
using MTW.UseCases.PluginInterfaces;

namespace MTW.Plugins.InMemory
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products;

        public ProductRepository()
        {
            _products = new()
            {
                new Product{ProductId = 1, ProductName="Basic Bike", Price = 2500, Quantity=5},
                new Product{ProductId = 2, ProductName="Full XC Bike", Price = 5000, Quantity=5},
                new Product{ProductId = 3, ProductName="Full Downhill Bike", Price = 7500, Quantity=5}
            };
        }

        public Task AddProductAsync(Product product)
        {
            if (_products.Any(i => i.ProductName.Equals(product.ProductName, StringComparison.OrdinalIgnoreCase)))
            {
                //Product.Quantity += 1;
                return Task.CompletedTask;
            }
            var maxId = _products.Max(i => i.ProductId);
            product.ProductId = maxId + 1;
            _products.Add(product);
            return Task.CompletedTask;
        }

        public Task DeleteProductByIdAsync(int id)
        {
            var invToDel = _products.FirstOrDefault(i => i.ProductId == id);
            if (invToDel is not null)
            {
                _products.Remove(invToDel);
            }
            return Task.CompletedTask;
        }

        public Task EditProductAsync(int invId, Product product)
        {
            if (_products.Any(i => i.ProductName.Equals(product.ProductName, StringComparison.OrdinalIgnoreCase)
                && i.ProductId != product.ProductId))
            {
                return Task.CompletedTask;
            }
            var invToEdit = _products.FirstOrDefault(i => i.ProductId == invId);
            if (invToEdit != null)
            {
                invToEdit.ProductName = product.ProductName;
                invToEdit.Price = product.Price;
                invToEdit.Quantity = product.Quantity;
            }

            return Task.FromResult(invToEdit);
        }

        public async Task<IEnumerable<Product>> GetProductsByNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return await Task.FromResult(_products);
            }
            return _products.Where(x => x.ProductName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public Product? GetProductById(int id)
        {
            var product = _products.FirstOrDefault(i => i.ProductId == id);
            return product;
        }
    }
}
