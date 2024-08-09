using MTW.CoreBusiness;

namespace MTW.UseCases.Inventories.Interfaces
{
    public interface IViewInventoriesByNameUseCases
    {
        Task<IEnumerable<Inventory>> ExecuteAsync(string name = "");
    }
}