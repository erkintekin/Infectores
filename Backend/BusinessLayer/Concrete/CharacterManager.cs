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
    public class CharacterManager : ICharacterService
    {
        private readonly IRepository<Character> _characterRepository;
        private readonly IRepository<Inventory> _inventoryRepository;
        private readonly IMapper _mapper;

        public CharacterManager(
            IRepository<Character> characterRepository,
            IRepository<Inventory> inventoryRepository,
            IMapper mapper)
        {
            _characterRepository = characterRepository;
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }

        public async Task<CharacterDTO> CreateCharacterAsync(CharacterDTO characterDto)
        {
            var character = _mapper.Map<Character>(characterDto);
            await _characterRepository.Create(character);

            var inventory = new Inventory
            {
                CharacterID = character.CharacterID
            };
            await _inventoryRepository.Create(inventory);

            return _mapper.Map<CharacterDTO>(character);
        }

        public async Task<List<CharacterDTO>> GetAllCharactersAsync()
        {
            var characters = await _characterRepository.List.ToListAsync();
            return _mapper.Map<List<CharacterDTO>>(characters);
        }

        public async Task<CharacterDTO> GetCharacterByIdAsync(int characterId)
        {
            var character = await _characterRepository.List.FirstOrDefaultAsync(c => c.CharacterID == characterId)
                ?? throw new KeyNotFoundException($"Character with ID: {characterId} not found.");
            return _mapper.Map<CharacterDTO>(character);
        }

        public async Task<bool> UpdateCharacterAsync(CharacterDTO characterDto)
        {
            var character = _mapper.Map<Character>(characterDto);
            _ = await _characterRepository.List.FirstOrDefaultAsync(c => c.CharacterID == character.CharacterID)
                ?? throw new KeyNotFoundException($"Character with ID: {character.CharacterID} not found.");

            await _characterRepository.Update(character);
            return true;
        }

        public async Task<bool> DeleteCharacterAsync(int characterId)
        {
            var character = await _characterRepository.List.FirstOrDefaultAsync(c => c.CharacterID == characterId)
                ?? throw new KeyNotFoundException($"Character with ID: {characterId} not found.");

            await _characterRepository.Delete(character);
            return true;
        }
    }
}