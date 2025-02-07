using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.EntityLayer.Concrete;

namespace Backend.BusinessLayer.Abstract
{
    public interface IItemService
    {
        Task<Item> CreateItem(Item item);
        Task<List<Item>> GetAllItems();
        Task<Item> GetItemById(int itemId);
        Task<bool> UpdateItem(Item item);
        Task<bool> DeleteItem(int itemId);
    }
}