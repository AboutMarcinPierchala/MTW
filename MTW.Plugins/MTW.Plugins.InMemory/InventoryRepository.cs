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

        public Task AddInventoryAsync(Inventory inventory)
        {
            if(_inventories.Any(i=>i.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
            {
                //inventory.Quantity += 1;
                return Task.CompletedTask;
            }
            var maxId = _inventories.Max(i => i.InventoryId);
            inventory.InventoryId = maxId+1;
            _inventories.Add(inventory);
            return Task.CompletedTask;
        }

        public Task DeleteRepositoryByIdAsync(int id)
        {
            var invToDel = _inventories.FirstOrDefault(i => i.InventoryId == id);
            if(invToDel is not null)
            {
                _inventories.Remove(invToDel);
            }
            return Task.CompletedTask;
        }

        public Task EditInventoryAsync(int invId, Inventory inventory)
        {
            if (_inventories.Any(i => i.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)
                && i.InventoryId != inventory.InventoryId))
            {
                return Task.CompletedTask;
            }
            var invToEdit = _inventories.FirstOrDefault(i => i.InventoryId == invId);
            if (invToEdit != null)
            {
                invToEdit.InventoryName = inventory.InventoryName;
                invToEdit.Price = inventory.Price;
                invToEdit.Quantity = inventory.Quantity;
            }

            return Task.FromResult(invToEdit);
        }

        public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return await Task.FromResult(_inventories);
            }
            return _inventories.Where(x=>x.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public Inventory? GetInventoryById(int id)
        {
            var inventory = _inventories.FirstOrDefault(i=> i.InventoryId==id);
                return inventory;            
        }
    }
}
