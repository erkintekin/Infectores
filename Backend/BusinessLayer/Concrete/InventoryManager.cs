using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using Backend.BusinessLayer.Abstract;
using Backend.DataAccessLayer.Abstract;
using Backend.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Backend.BusinessLayer.Concrete
{
    public class InventoryManager : IInventoryService
    {
        private readonly IRepository<InventoryItem> _inventoryRepository;

        public InventoryManager(IRepository<InventoryItem> inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public async Task<List<InventoryItem>> GetAllInventoryItems(int inventoryId) => await _inventoryRepository.List.Where(i => i.InventoryID == inventoryId).ToListAsync() ?? throw new KeyNotFoundException($"Inventory with ID {inventoryId} not found.");
        public async Task AddItemInventory(InventoryItem inventoryItem) => await _inventoryRepository.Create(inventoryItem);
        public async Task RemoveItemInventory(int inventoryId, int itemId)
        {
            var item = await _inventoryRepository.List.FirstOrDefaultAsync(i => i.InventoryID == inventoryId && i.ItemID == itemId);

            if (item != null)
            {
                _inventoryRepository.Delete(item); // Note: Look this call for await availability.
            }
        }

    }
}