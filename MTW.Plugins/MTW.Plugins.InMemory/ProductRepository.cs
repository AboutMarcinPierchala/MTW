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
            //if(product.ProductInventories is not null &&
            //    product.ProductInventories.Count > 0)
            //{
            //    product.Price += product.ProductInventories.Sum(i => i.Inventory.Quantity * i.Inventory.Price);
            //}            
            _products.Add(product);
            return Task.CompletedTask;
        }

        public Task DeleteProductByIdAsync(int id)
        {
            var prodToDel = _products.FirstOrDefault(i => i.ProductId == id);
            if (prodToDel is not null)
            {
                _products.Remove(prodToDel);
            }
            return Task.CompletedTask;
        }

        public Task EditProductAsync(int prodId, Product product)
        {
            if (_products.Any(i => i.ProductName.Equals(product.ProductName, StringComparison.OrdinalIgnoreCase)
                && i.ProductId != product.ProductId))
            {
                return Task.CompletedTask;
            }
            var prodToEdit = _products.FirstOrDefault(i => i.ProductId == prodId);
            if (prodToEdit != null)
            {
                prodToEdit.ProductName = product.ProductName;
                prodToEdit.Price = product.Price;// + product.ProductInventories.Sum(i => i.Inventory.Quantity * i.Inventory.Price);
                prodToEdit.Quantity = product.Quantity;
            }

            return Task.FromResult(prodToEdit);
        }

        public async Task<IEnumerable<Product>> GetProductsByNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return await Task.FromResult(_products);
            }
            return _products.Where(x => x.ProductName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<Product> GetProductByIdAsync(int prodId)
        {
            var prod = _products.FirstOrDefault(x => x.ProductId == prodId);
            var newProd = new Product();
            if(prod is not null)
            {
                newProd.ProductId = prod.ProductId;
                newProd.ProductName = prod.ProductName;
                newProd.Price = prod.Price;
                newProd.Quantity = prod.Quantity;
                newProd.ProductInventories = new List<ProductInventory>();
                if(prod.ProductInventories is not null)
                {
                    foreach(var prodInv in prod.ProductInventories)
                    {
                        var newProdInv = new ProductInventory()
                        {
                            InventoryId = prodInv.InventoryId,
                            ProductId = prodInv.ProductId,
                            Product = prod,
                            Inventory = new Inventory(),
                            InventoryQuantity = prodInv.InventoryQuantity
                        };
                        if(prodInv.Inventory is not null)
                        {
                            newProdInv.Inventory.InventoryId = prodInv.Inventory.InventoryId;
                            newProdInv.Inventory.InventoryName = prodInv.Inventory.InventoryName;
                            newProdInv.Inventory.Price = prodInv.Inventory.Price;
                            newProdInv.Inventory.Quantity = prodInv.Inventory.Quantity;
                        }
                        newProd.ProductInventories.Add(newProdInv);
                    }
                }
            }
            return await Task.FromResult(newProd);
        }
    }
}
