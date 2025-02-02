using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.EntityLayer.Concrete;

namespace Backend.BusinessLayer.Abstract
{
    public interface IInventoryService
    {
        Task<List<InventoryItem>> GetAllInventoryItems(int inventoryId);
        Task<bool> AddItemToInventory(int inventoryId, int itemId, int quantity);
        Task<bool> RemoveItemFromInventory(int inventoryId, int itemId);
    }

}