using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.EntityLayer.Concrete;
using Backend.DTOs;

namespace Backend.BusinessLayer.Abstract
{
    public interface IItemService
    {
        Task<ItemDTO> CreateItemAsync(ItemCreateDTO itemDto);
        Task<List<ItemDTO>> GetAllItemsAsync();
        Task<ItemDTO> GetItemByIdAsync(int id);
        Task<List<ItemDTO>> GetInventoryItemsAsync(int inventoryId);
        Task<ItemDTO> UpdateItemAsync(int id, ItemUpdateDTO itemDto);
        Task<bool> DeleteItemAsync(int id);
    }
}