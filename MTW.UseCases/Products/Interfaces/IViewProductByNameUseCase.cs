using MTW.CoreBusiness;

namespace MTW.UseCases.Products.Interfaces
{
    public interface IViewProductByNameUseCase
    {
        Task<IEnumerable<Product>> ExecuteAsync(string name = "");
    }
}