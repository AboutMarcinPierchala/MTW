using MTW.CoreBusiness;
using MTW.UseCases.PluginInterfaces;

namespace MTW.Plugins.InMemory
{
    public class InventoryRepository : IInventoryRepository
    {
        private List<Inventory> _inventories;

        public InventoryRepository()
        {
            _inventories = new()
            {
                new Inventory{InventoryId = 1, InventoryName="Basic Frame", Price = 250, Quantity=5},
                new Inventory{InventoryId = 2, InventoryName="Full XC Frame", Price = 500, Quantity=5},
                new Inventory{InventoryId = 3, InventoryName="Full Downhill Frame", Price = 750, Quantity=5}
            };
        }
        public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return await Task.FromResult(_inventories);
            }
            return _inventories.Where(x=>x.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
