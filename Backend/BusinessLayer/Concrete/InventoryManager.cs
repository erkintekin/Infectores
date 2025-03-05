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
        private readonly IRepository<Inventory> _inventoryRepository;
        private readonly IRepository<InventoryItem> _inventoryItemRepository;
        private readonly IMapper _mapper;

        public InventoryManager(
            IRepository<Inventory> inventoryRepository,
            IRepository<InventoryItem> inventoryItemRepository,
            IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _inventoryItemRepository = inventoryItemRepository;
            _mapper = mapper;
        }

        public async Task<List<InventoryItemDTO>> GetAllInventoryItemsAsync(int inventoryId)
        {
            var items = await _inventoryItemRepository.GetAllAsync(
                i => i.InventoryID == inventoryId,
                includeProperties: "Item,Item.ItemType");

            return _mapper.Map<List<InventoryItemDTO>>(items);
        }

        public async Task<bool> AddItemToInventoryAsync(int inventoryId, int itemId, int quantity)
        {
            var existingItem = await _inventoryItemRepository.GetFirstOrDefaultAsync(
                ii => ii.InventoryID == inventoryId && ii.ItemID == itemId);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
                await _inventoryItemRepository.UpdateAsync(existingItem);
            }
            else
            {
                var inventoryItem = new InventoryItem
                {
                    InventoryID = inventoryId,
                    ItemID = itemId,
                    Quantity = quantity
                };
                await _inventoryItemRepository.AddAsync(inventoryItem);
            }

            await _inventoryItemRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveItemFromInventoryAsync(int inventoryId, int itemId)
        {
            var inventoryItem = await _inventoryItemRepository.GetFirstOrDefaultAsync(
                ii => ii.InventoryID == inventoryId && ii.ItemID == itemId)
                ?? throw new KeyNotFoundException("Inventory item not found.");

            await _inventoryItemRepository.DeleteAsync(inventoryItem);
            await _inventoryItemRepository.SaveChangesAsync();
            return true;
        }
    }
}