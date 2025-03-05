using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Backend.BusinessLayer.Abstract;
using Backend.DataAccessLayer.Abstract;
using Backend.DTOs;
using Backend.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Backend.BusinessLayer.Concrete
{
    public class InventoryManager : IInventoryService
    {
        private readonly IRepository<InventoryItem> _inventoryRepository;
        private readonly IMapper _mapper;

        public InventoryManager(IRepository<InventoryItem> inventoryRepository, IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }

        public async Task<List<InventoryItemDTO>> GetAllInventoryItemsAsync(int inventoryId)
        {
            var items = await _inventoryRepository.List
                .Where(i => i.InventoryID == inventoryId)
                .ToListAsync() ?? throw new KeyNotFoundException($"Inventory with ID {inventoryId} not found.");
            return _mapper.Map<List<InventoryItemDTO>>(items);
        }

        public async Task<bool> AddItemToInventoryAsync(int inventoryId, int itemId, int quantity)
        {
            var inventoryItem = new InventoryItem
            {
                InventoryID = inventoryId,
                ItemID = itemId,
                Quantity = quantity
            };
            await _inventoryRepository.Create(inventoryItem);
            return true;
        }

        public async Task<bool> RemoveItemFromInventoryAsync(int inventoryId, int itemId)
        {
            var item = await _inventoryRepository.List
                .FirstOrDefaultAsync(i => i.InventoryID == inventoryId && i.ItemID == itemId);

            if (item == null)
                return false;

            await _inventoryRepository.Delete(item);
            return true;
        }
    }
}