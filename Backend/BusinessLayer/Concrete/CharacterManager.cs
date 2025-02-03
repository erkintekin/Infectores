using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using Backend.BusinessLayer.Abstract;
using Backend.DataAccessLayer.Abstract;
using Backend.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Backend.BusinessLayer.Concrete
{
    public class CharacterManager : ICharacterService
    {
        private readonly IRepository<Character> _characterRepository;
        private readonly IRepository<Inventory> _inventoryRepository;

        public CharacterManager(IRepository<Character> characterRepository, IRepository<Inventory> inventoryRepository)
        {
            _characterRepository = characterRepository;
            _inventoryRepository = inventoryRepository;
        }

        public async Task<Character> CreateCharacter(Character character)
        {
            await _characterRepository.Create(character);

            var inventory = new Inventory
            {
                CharacterID = character.CharacterID
            };

            await _inventoryRepository.Create(inventory);  // Character and Inventory are creating in same method.

            return character;
        }

        public async Task<List<Character>> GetAllCharacters() => await _characterRepository.List.ToListAsync();
        public async Task<Character> GetCharacterById(int id)
        {
            var character = await _characterRepository.List.Include(c => c.Inventory).FirstOrDefaultAsync(s => s.CharacterID == id) ?? throw new KeyNotFoundException($"Character with ID {id} not found."); // For simplify, I tried to coalesce the expression.
            return character;
        }

        public async Task<bool> UpdateCharacter(Character character)
        {

            var existingCharacter = _characterRepository.List.FirstOrDefaultAsync(s => s.CharacterID == character.CharacterID);
            if (existingCharacter == null)
                return false;

            await _characterRepository.Update(character);
            return true;
        }

        public async Task<bool> DeleteCharacter(int characterId)
        {
            var character = await _characterRepository.List.FirstOrDefaultAsync(s => s.CharacterID == characterId);
            if (character == null)
                return false;

            await _characterRepository.Delete(character);
            return true;
        }
    }
}