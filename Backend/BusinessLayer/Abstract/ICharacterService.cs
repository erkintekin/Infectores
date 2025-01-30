using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.EntityLayer.Concrete;

namespace Backend.BusinessLayer.Abstract
{
    public interface ICharacterService
    {
        void CreateCharacter(Character character);
        Task<List<Character>> GetAllCharacters();
        Task<Character> GetCharacterById(int id);
        void UpdateCharacter(Character character);
        void DeleteCharacter(Character character);
    }
}