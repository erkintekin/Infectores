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
        private readonly IMapper _mapper;

        public ItemManager(IRepository<Item> itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<ItemDTO> CreateItemAsync(ItemDTO itemDto)
        {
            var isExists = await _itemRepository.List.AnyAsync(i => i.Name == itemDto.Name);
            if (isExists)
            {
                throw new InvalidOperationException($"An item with the name `{itemDto.Name}` already exists");
            }

            var item = _mapper.Map<Item>(itemDto);
            await _itemRepository.Create(item);
            return _mapper.Map<ItemDTO>(item);
        }

        public async Task<List<ItemDTO>> GetAllItemsAsync()
        {
            var items = await _itemRepository.List.ToListAsync()
                ?? throw new KeyNotFoundException("There are no Items here! Please add one at least!");
            return _mapper.Map<List<ItemDTO>>(items);
        }

        public async Task<ItemDTO> GetItemByIdAsync(int itemId)
        {
            var item = await _itemRepository.List.FirstOrDefaultAsync(i => i.ItemID == itemId)
                ?? throw new KeyNotFoundException($"Sorry, there is no item with Item ID: `{itemId}`");
            return _mapper.Map<ItemDTO>(item);
        }

        public async Task<bool> UpdateItemAsync(ItemDTO itemDto)
        {
            var item = _mapper.Map<Item>(itemDto);
            _ = await _itemRepository.List.FirstOrDefaultAsync(i => i.ItemID == item.ItemID)
                ?? throw new KeyNotFoundException($"Sorry, there is no Item with Item ID: `{item.ItemID}`"); // I tried to coalesce and simplify the expression "_" means unnamed "var" variable

            await _itemRepository.Update(item);
            return true;
        }

        public async Task<bool> DeleteItemAsync(int itemId)
        {
            var item = await _itemRepository.List.FirstOrDefaultAsync(i => i.ItemID == itemId)
                ?? throw new KeyNotFoundException($"Sorry, there is no Item with Item ID: `{itemId}`");

            await _itemRepository.Delete(item);
            return true;
        }
    }
}