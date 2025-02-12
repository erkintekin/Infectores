using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.EntityLayer.Concrete;

namespace Backend.BusinessLayer.Abstract
{
    public interface ISpellService
    {
        Task<Spell> CreateSpell(Spell spell);
        Task<List<Spell>> GetAllSpells();
        Task<Spell> GetSpellById(int spellId);
        Task<bool> UpdateSpell(Spell spell);
        Task<bool> DeleteSpell(int spellId);
        Task<CharacterSpell> AddSpellCharacter(int characterId, int spellId);
        Task<List<CharacterSpell>> GetAllCharacterSpells(int characterId);
        Task<bool> UpdateCharacterSpell(int characterId, int spellId, int newValue);
        Task<bool> DeleteCharacterSpell(int characterId, int spellId);
    }
}