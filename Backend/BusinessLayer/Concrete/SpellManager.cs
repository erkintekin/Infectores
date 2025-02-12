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
        async Task<Spell> CreateSpell(Spell spell)
        {
            var spellExists = await _spellRepository.List.AnyAsync(cs => cs.Name == spell.Name || cs.SpellID == spell.SpellID);

            if (spellExists)
            {
                throw new InvalidOperationException($"A throw with the name `{spell.Name}` or ID `{spell.SpellID}` already exists.");
            }

            await _spellRepository.Create(spell);
            return spell;
        }

        public async Task<List<Spell>> GetAllSpells() => await _spellRepository.List.ToListAsync();

        async Task<Spell> GetSpellById(int spellId) => await _spellRepository.List.FirstOrDefaultAsync(cs => cs.SpellID == spellId) ?? throw new KeyNotFoundException($"Spell with ID: `{spellId}` is not found.");

        Task<bool> UpdateSpell(Spell spell);
        Task<bool> DeleteSpell(int spellId);
        Task<CharacterSpell> AddSpellCharacter(int characterId, int spellId);
        Task<List<CharacterSpell>> GetAllCharacterSpells(int characterId);
        Task<bool> UpdateCharacterSpell(int characterId, int spellId, int newValue);
        Task<bool> DeleteCharacterSpell(int characterId, int spellId);
    }
}