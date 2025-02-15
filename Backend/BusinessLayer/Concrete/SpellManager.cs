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
    public class SpellManager : ISpellService
    {
        private readonly IRepository<Spell> _spellRepository;
        private readonly IRepository<CharacterSpell> _characterSpellRepository;

        public SpellManager(IRepository<Spell> spellRepository, IRepository<CharacterSpell> characterSpellRepository)
        {
            _characterSpellRepository = characterSpellRepository;
            _spellRepository = spellRepository;
        }
        public async Task<Spell> CreateSpell(Spell spell)
        {
            var spellExists = await _spellRepository.List.AnyAsync(cs => cs.Name == spell.Name);

            if (spellExists)
            {
                throw new InvalidOperationException($"A spell with the name `{spell.Name}` or ID `{spell.SpellID}` already exists.");
            }

            await _spellRepository.Create(spell);
            return spell;
        }

        public async Task<List<Spell>> GetAllSpells() => await _spellRepository.List.ToListAsync();

        public async Task<Spell> GetSpellById(int spellId)
        {
            var selectedSpell = await _spellRepository.List.FirstOrDefaultAsync(cs => cs.SpellID == spellId) ?? throw new KeyNotFoundException($"Spell with ID: `{spellId}` is not found.");

            return selectedSpell;
        }

        public async Task<bool> UpdateSpell(Spell spell)
        {
            var spellExists = await _spellRepository.List.AnyAsync(cs => cs.SpellID == spell.SpellID);

            if (!spellExists)
                throw new KeyNotFoundException($"Spell with ID: `{spell.SpellID}` is not found.");

            await _spellRepository.Update(spell);
            return true;
        }
        public async Task<bool> DeleteSpell(int spellId)
        {
            var selectedExists = await _spellRepository.List.AnyAsync(cs => cs.SpellID == spellId);

            if (!selectedExists)
                throw new KeyNotFoundException($"Spell with ID: `{spellId}` is not found.");

            var selectedSpell = await _spellRepository.List.FirstAsync(cs => cs.SpellID == spellId);
            await _spellRepository.Delete(selectedSpell);
            return true;
        }
        public async Task<CharacterSpell> AddSpellCharacter(int characterId, int spellId)  // Proficiency Manager has this method too
        {
            var characterExists = await _characterSpellRepository.List.AnyAsync(cs => cs.CharacterID == characterId);

            if (!characterExists)
                throw new KeyNotFoundException($"Character with ID: `{characterId}` is not found.");

            var spellExists = await _spellRepository.List.AnyAsync(cs => cs.SpellID == spellId);

            if (!spellExists)
                throw new KeyNotFoundException($"Spell with ID: `{spellId}` is not found.");

            var existingSpell = await _characterSpellRepository.List.FirstOrDefaultAsync(cs => cs.CharacterID == characterId && cs.SpellID == spellId);

            if (existingSpell != null)
            {
                throw new InvalidOperationException("Character already has this spell.");
            }

            var newCharacterSpell = new CharacterSpell
            {
                CharacterID = characterId,
                SpellID = spellId
            };

            await _characterSpellRepository.Create(newCharacterSpell);

            return newCharacterSpell;
        }

        public async Task<List<CharacterSpell>> GetAllCharacterSpells(int characterId)
        {
            var characterExists = await _characterSpellRepository.List.AnyAsync(cs => cs.CharacterID == characterId);

            if (!characterExists)
                throw new KeyNotFoundException($"Character with ID: `{characterId}` is not found.");

            return await _characterSpellRepository.List.Where(cs => cs.CharacterID == characterId).ToListAsync();
        }
        public async Task<bool> UpdateCharacterSpell(int characterId, int spellId, int newLevel)
        {
            var selectedSpell = await _characterSpellRepository.List.AnyAsync(cs => cs.SpellID == spellId);

            if (!selectedSpell)
                throw new KeyNotFoundException($"Spell with ID: `{spellId}` is not found.");

            var selectedCharacter = await _characterSpellRepository.List.AnyAsync(cs => cs.CharacterID == characterId);

            if (!selectedCharacter)
                throw new KeyNotFoundException($"Character with ID: `{characterId}` is not found.");

            var existingSpell = await _characterSpellRepository.List.FirstOrDefaultAsync(cs => cs.CharacterID == characterId && cs.SpellID == spellId) ?? throw new KeyNotFoundException($"Character with ID: `{characterId}` has not the selected spell `{spellId}`.");

            existingSpell.Level = newLevel;  // p.s. Spell levels change damage or ranga of the spell. Checkable.

            if (newLevel < 0)
                throw new ArgumentOutOfRangeException(nameof(newLevel), "Spell level cannot be negative.");

            await _characterSpellRepository.Update(existingSpell);
            return true;
        }

        public async Task<bool> DeleteCharacterSpell(int characterId, int spellId)
        {
            var selectedSpell = await _characterSpellRepository.List.AnyAsync(cs => cs.SpellID == spellId);

            if (!selectedSpell)
                throw new KeyNotFoundException($"Spell with ID: `{spellId}` is not found.");

            var selectedCharacter = await _characterSpellRepository.List.AnyAsync(cs => cs.CharacterID == characterId);

            if (!selectedCharacter)
                throw new KeyNotFoundException($"Character with ID: `{characterId}` is not found.");

            var existingSpell = await _characterSpellRepository.List.FirstOrDefaultAsync(cs => cs.CharacterID == characterId && cs.SpellID == spellId) ?? throw new KeyNotFoundException($"Character with ID: `{characterId}` has not the selected spell `{spellId}`.");

            await _characterSpellRepository.Delete(existingSpell);
            return true;
        }
    }
}