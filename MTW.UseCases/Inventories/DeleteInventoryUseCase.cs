﻿using MTW.UseCases.Inventories.Interfaces;
using MTW.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTW.UseCases.Inventories
{
    public class DeleteInventoryUseCase : IDeleteInventoryUseCase
    {
        private readonly IInventoryRepository _inventoryRepository;

        public DeleteInventoryUseCase(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public async Task ExecuteAsync(int id)
        {
            await _inventoryRepository.DeleteInventoryByIdAsync(id);
        }
    }
}
