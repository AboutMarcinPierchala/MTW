using MTW.CoreBusiness;
using MTW.UseCases.Inventories.Interfaces;
using MTW.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTW.UseCases.Inventories
{
    public class ViewInventoriesByNameUseCases : IViewInventoriesByNameUseCases
    {
        private readonly IInventoryRepository _inventoryRepository;

        public ViewInventoriesByNameUseCases(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        public async Task<IEnumerable<Inventory>> ExecuteAsync(string name = "")
        {
            return await _inventoryRepository.GetInventoriesByNameAsync(name);
        }
    }
}
