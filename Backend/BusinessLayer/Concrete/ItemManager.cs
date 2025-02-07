using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.BusinessLayer.Abstract;
using Backend.DataAccessLayer.Abstract;
using Backend.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Backend.BusinessLayer.Concrete
{
    public class ItemManager : IItemService
    {
        private readonly IRepository<Item> _itemRepository;

        public ItemManager(IRepository<Item> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<Item> CreateItem(Item item)
        {
            var isExists = await _itemRepository.List.AnyAsync(i => i.Name == item.Name);

            if (isExists)
            {
                throw new InvalidOperationException($"An item with the name `{item.Name}` already exists");
            }

            await _itemRepository.Create(item);
            return item;
        }

        public async Task<List<Item>> GetAllItems() => await _itemRepository.List.ToListAsync() ?? throw new KeyNotFoundException($"There is not any Items here! Please add one at least!");

        public async Task<Item> GetItemById(int itemId)
        {
            var item = await _itemRepository.List.FirstOrDefaultAsync(i => i.ItemID == itemId);

            if (item == null)
            {
                throw new KeyNotFoundException($"Sorry, there is no item with Item ID: `{itemId}`");

            }
            return item;
        }

        public async Task<bool> UpdateItem(Item item)
        {
            _ = await _itemRepository.List.FirstOrDefaultAsync(i => i.ItemID == item.ItemID) ?? throw new KeyNotFoundException($"Sorry, there is no Item with Item ID: `{item.ItemID}`"); // I tried to coalesce and simplify the expression "_" means unnamed "var" variable
            await _itemRepository.Update(item);
            return true;
        }

        public async Task<bool> DeleteItem(int itemId)
        {
            var existingItem = await _itemRepository.List.FirstOrDefaultAsync(i => i.ItemID == itemId) ?? throw new KeyNotFoundException($"Sorry, there is no Item with Item ID: `{itemId}`");

            await _itemRepository.Delete(existingItem);
            return true;
        }
    }
}