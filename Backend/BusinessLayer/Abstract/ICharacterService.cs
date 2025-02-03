using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.EntityLayer.Concrete;

namespace Backend.BusinessLayer.Abstract
{
    public interface ICharacterService
    {
        Task<Character> CreateCharacter(Character character);
        Task<List<Character>> GetAllCharacters();
        Task<Character> GetCharacterById(int characterId);
        Task<bool> UpdateCharacter(Character character);
        Task<bool> DeleteCharacter(int characterId);
    }
}