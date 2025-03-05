using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.EntityLayer.Concrete;
using Backend.DTOs;

namespace Backend.BusinessLayer.Abstract
{
    public interface IInventoryService
    {
        Task<List<InventoryItemDTO>> GetAllInventoryItemsAsync(int inventoryId);
        Task<bool> AddItemToInventoryAsync(int inventoryId, int itemId, int quantity);
        Task<bool> RemoveItemFromInventoryAsync(int inventoryId, int itemId);
    }

}