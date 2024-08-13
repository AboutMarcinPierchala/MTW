using MTW.CoreBusiness;

namespace MTW.UseCases.Inventories.Interfaces
{
    public interface IEditInventoryUseCase
    {
        Task ExecuteAsync(int id, Inventory inventory);
    }
}