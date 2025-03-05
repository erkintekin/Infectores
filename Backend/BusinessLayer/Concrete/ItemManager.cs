using System;
using System.Collections.Generic;
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
    public class ItemManager : IItemService
    {
        private readonly IRepository<Item> _itemRepository;
        private readonly IRepository<InventoryItem> _inventoryItemRepository;
        private readonly IMapper _mapper;

        public ItemManager(
            IRepository<Item> itemRepository,
            IRepository<InventoryItem> inventoryItemRepository,
            IMapper mapper)
        {
            _itemRepository = itemRepository;
            _inventoryItemRepository = inventoryItemRepository;
            _mapper = mapper;
        }

        public async Task<ItemDTO> CreateItemAsync(ItemCreateDTO itemDto)
        {
            var exists = await _itemRepository.AnyAsync(i => i.Name.ToLower() == itemDto.Name.ToLower());
            if (exists)
            {
                throw new InvalidOperationException($"Item with name '{itemDto.Name}' already exists.");
            }

            var item = _mapper.Map<Item>(itemDto);
            await _itemRepository.AddAsync(item);
            await _itemRepository.SaveChangesAsync();

            return await GetItemByIdAsync(item.ItemID);
        }

        public async Task<List<ItemDTO>> GetAllItemsAsync()
        {
            var items = await _itemRepository.GetAllAsync();
            return _mapper.Map<List<ItemDTO>>(items);
        }

        public async Task<ItemDTO> GetItemByIdAsync(int id)
        {
            var item = await _itemRepository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException($"Item with ID {id} not found.");
            return _mapper.Map<ItemDTO>(item);
        }

        public async Task<List<ItemDTO>> GetInventoryItemsAsync(int inventoryId)
        {
            var items = await _inventoryItemRepository.GetAllAsync(
                ii => ii.InventoryID == inventoryId,
                includeProperties: "Item,Item.ItemType");

            return _mapper.Map<List<ItemDTO>>(items.Select(ii => ii.Item));
        }

        public async Task<ItemDTO> UpdateItemAsync(int id, ItemUpdateDTO itemDto)
        {
            var item = await _itemRepository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException($"Item with ID {id} not found.");

            if (itemDto.Name != item.Name)
            {
                var exists = await _itemRepository.AnyAsync(i => i.Name.ToLower() == itemDto.Name.ToLower());
                if (exists)
                {
                    throw new InvalidOperationException($"Item with name '{itemDto.Name}' already exists.");
                }
            }

            _mapper.Map(itemDto, item);
            await _itemRepository.UpdateAsync(item);
            await _itemRepository.SaveChangesAsync();

            return await GetItemByIdAsync(id);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var item = await _itemRepository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException($"Item with ID {id} not found.");

            await _itemRepository.DeleteAsync(item);
            await _itemRepository.SaveChangesAsync();
            return true;
        }
    }
}