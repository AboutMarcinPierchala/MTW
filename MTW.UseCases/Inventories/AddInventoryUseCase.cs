﻿using MTW.CoreBusiness;
using MTW.UseCases.Inventories.Interfaces;
using MTW.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTW.UseCases.Inventories
{
    public class AddInventoryUseCase : IAddInventoryUseCase
    {
        private readonly IInventoryRepository _inventoryRepository;

        public AddInventoryUseCase(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        public async Task ExecuteAsync(Inventory inventory)
        {
            await _inventoryRepository.AddInventoryAsync(inventory);
        }
    }
}
