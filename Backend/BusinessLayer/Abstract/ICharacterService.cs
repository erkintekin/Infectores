using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.EntityLayer.Concrete;
using Backend.DTOs;

namespace Backend.BusinessLayer.Abstract
{
    public interface ICharacterService
    {
        Task<CharacterDTO> CreateCharacterAsync(CharacterDTO characterDto);
        Task<List<CharacterDTO>> GetAllCharactersAsync();
        Task<CharacterDTO> GetCharacterByIdAsync(int characterId);
        Task<bool> UpdateCharacterAsync(CharacterDTO characterDto);
        Task<bool> DeleteCharacterAsync(int characterId);
    }
}