using MTW.CoreBusiness;

namespace MTW.UseCases.Products.Interfaces
{
    public interface IEditProductUseCase
    {
        Task ExecuteAsync(int id, Product product);
    }
}