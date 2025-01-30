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
    public class CharacterManager : ICharacterService
    {
        private readonly IRepository<Character> _characterRepository;

        public void CreateCharacter(Character character)
        {
            _characterRepository.Create(character);
        }

        public async Task<List<Character>> GetAllCharacters() => await _characterRepository.List.ToListAsync();
        public async Task<Character> GetCharacterById(int id)
        {
            var character = await _characterRepository.List.FirstOrDefaultAsync(s => s.CharacterID == id) ?? throw new KeyNotFoundException($"Character with ID {id} not found."); // For simplify, I tried to coalesce the expression.
            return character;
        }

        public void UpdateCharacter(Character character)
        {
            _characterRepository.Update(character);
        }

        public void DeleteCharacter(Character character)
        {
            _characterRepository.Delete(character);
        }
    }
}