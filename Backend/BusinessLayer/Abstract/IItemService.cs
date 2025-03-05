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
        Task<ItemDTO> CreateItemAsync(ItemDTO itemDto);
        Task<List<ItemDTO>> GetAllItemsAsync();
        Task<ItemDTO> GetItemByIdAsync(int itemId);
        Task<bool> UpdateItemAsync(ItemDTO itemDto);
        Task<bool> DeleteItemAsync(int itemId);
    }
}