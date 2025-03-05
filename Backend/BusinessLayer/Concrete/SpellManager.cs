using System;
using System.Collections.Generic;
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
    public class SpellManager : ISpellService
    {
        private readonly IRepository<Spell> _spellRepository;
        private readonly IRepository<CharacterSpell> _characterSpellRepository;
        private readonly IMapper _mapper;

        public SpellManager(
            IRepository<Spell> spellRepository,
            IRepository<CharacterSpell> characterSpellRepository,
            IMapper mapper)
        {
            _spellRepository = spellRepository;
            _characterSpellRepository = characterSpellRepository;
            _mapper = mapper;
        }

        public async Task<SpellDTO> CreateSpellAsync(SpellDTO spellDto)
        {
            var spell = _mapper.Map<Spell>(spellDto);
            await _spellRepository.Create(spell);
            return _mapper.Map<SpellDTO>(spell);
        }

        public async Task<List<SpellDTO>> GetAllSpellsAsync()
        {
            var spells = await _spellRepository.List.ToListAsync();
            return _mapper.Map<List<SpellDTO>>(spells);
        }

        public async Task<SpellDTO> GetSpellByIdAsync(int spellId)
        {
            var spell = await _spellRepository.List.FirstOrDefaultAsync(s => s.SpellID == spellId)
                ?? throw new KeyNotFoundException($"Spell with ID: {spellId} not found.");
            return _mapper.Map<SpellDTO>(spell);
        }

        public async Task<bool> UpdateSpellAsync(SpellDTO spellDto)
        {
            var spell = _mapper.Map<Spell>(spellDto);
            _ = await _spellRepository.List.FirstOrDefaultAsync(s => s.SpellID == spell.SpellID)
                ?? throw new KeyNotFoundException($"Spell with ID: {spell.SpellID} not found.");

            await _spellRepository.Update(spell);
            return true;
        }

        public async Task<bool> DeleteSpellAsync(int spellId)
        {
            var spell = await _spellRepository.List.FirstOrDefaultAsync(s => s.SpellID == spellId)
                ?? throw new KeyNotFoundException($"Spell with ID: {spellId} not found.");

            await _spellRepository.Delete(spell);
            return true;
        }

        public async Task<CharacterSpellDTO> AddSpellToCharacterAsync(int characterId, int spellId)
        {
            var characterSpell = new CharacterSpell
            {
                CharacterID = characterId,
                SpellID = spellId,
                Level = 1
            };

            await _characterSpellRepository.Create(characterSpell);
            return _mapper.Map<CharacterSpellDTO>(characterSpell);
        }

        public async Task<List<CharacterSpellDTO>> GetAllCharacterSpellsAsync(int characterId)
        {
            var spells = await _characterSpellRepository.List
                .Where(cs => cs.CharacterID == characterId)
                .ToListAsync();

            return _mapper.Map<List<CharacterSpellDTO>>(spells);
        }

        public async Task<bool> UpdateCharacterSpellAsync(int characterId, int spellId, int newLevel)
        {
            var characterSpell = await _characterSpellRepository.List
                .FirstOrDefaultAsync(cs => cs.CharacterID == characterId && cs.SpellID == spellId)
                ?? throw new KeyNotFoundException($"Character spell not found.");

            characterSpell.Level = newLevel;
            await _characterSpellRepository.Update(characterSpell);
            return true;
        }

        public async Task<bool> DeleteCharacterSpellAsync(int characterId, int spellId)
        {
            var characterSpell = await _characterSpellRepository.List
                .FirstOrDefaultAsync(cs => cs.CharacterID == characterId && cs.SpellID == spellId)
                ?? throw new KeyNotFoundException($"Character spell not found.");

            await _characterSpellRepository.Delete(characterSpell);
            return true;
        }
    }
}