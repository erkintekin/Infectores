using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.EntityLayer.Concrete;
using Backend.DTOs;

namespace Backend.BusinessLayer.Abstract
{
    public interface ISpellService
    {
        Task<SpellDTO> CreateSpellAsync(SpellDTO spellDto);
        Task<List<SpellDTO>> GetAllSpellsAsync();
        Task<SpellDTO> GetSpellByIdAsync(int spellId);
        Task<bool> UpdateSpellAsync(SpellDTO spellDto);
        Task<bool> DeleteSpellAsync(int spellId);
        Task<CharacterSpellDTO> AddSpellToCharacterAsync(int characterId, int spellId);
        Task<List<CharacterSpellDTO>> GetAllCharacterSpellsAsync(int characterId);
        Task<bool> UpdateCharacterSpellAsync(int characterId, int spellId, int newLevel);
        Task<bool> DeleteCharacterSpellAsync(int characterId, int spellId);
    }
}