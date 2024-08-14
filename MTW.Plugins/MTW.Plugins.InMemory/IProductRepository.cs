using MTW.CoreBusiness;

namespace MTW.Plugins.InMemory
{
    public interface IProductRepository
    {
        Task AddProductAsync(Product product);
        Task DeleteProductByIdAsync(int id);
        Task EditProductAsync(int invId, Product product);
        Product? GetProductById(int id);
        Task<IEnumerable<Product>> GetProductsByNameAsync(string name);
    }
}