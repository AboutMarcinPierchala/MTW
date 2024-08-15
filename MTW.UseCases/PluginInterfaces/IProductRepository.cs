using MTW.CoreBusiness;

namespace MTW.UseCases.PluginInterfaces
{
    public interface IProductRepository
    {
        Task AddProductAsync(Product product);
        Task DeleteProductByIdAsync(int id);
        Task EditProductAsync(int invId, Product product);
        Task<IEnumerable<Product>> GetProductsByNameAsync(string name);
    }
}