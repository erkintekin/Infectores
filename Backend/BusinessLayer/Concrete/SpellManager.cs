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

        public async Task<SpellDTO> CreateSpellAsync(SpellCreateDTO spellDto)
        {
            var exists = await _spellRepository.AnyAsync(s => s.Name.ToLower() == spellDto.Name.ToLower());
            if (exists)
            {
                throw new InvalidOperationException($"Spell with name '{spellDto.Name}' already exists.");
            }

            var spell = _mapper.Map<Spell>(spellDto);
            await _spellRepository.AddAsync(spell);
            await _spellRepository.SaveChangesAsync();

            return await GetSpellByIdAsync(spell.SpellID);
        }

        public async Task<List<SpellDTO>> GetAllSpellsAsync()
        {
            var spells = await _spellRepository.GetAllAsync();
            return _mapper.Map<List<SpellDTO>>(spells);
        }

        public async Task<SpellDTO> GetSpellByIdAsync(int id)
        {
            var spell = await _spellRepository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException($"Spell with ID {id} not found.");
            return _mapper.Map<SpellDTO>(spell);
        }

        public async Task<SpellDTO> UpdateSpellAsync(int id, SpellUpdateDTO spellDto)
        {
            var spell = await _spellRepository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException($"Spell with ID {id} not found.");

            if (spellDto.Name != spell.Name)
            {
                var exists = await _spellRepository.AnyAsync(s => s.Name.ToLower() == spellDto.Name.ToLower());
                if (exists)
                {
                    throw new InvalidOperationException($"Spell with name '{spellDto.Name}' already exists.");
                }
            }

            _mapper.Map(spellDto, spell);
            await _spellRepository.UpdateAsync(spell);
            await _spellRepository.SaveChangesAsync();

            return await GetSpellByIdAsync(id);
        }

        public async Task<bool> DeleteSpellAsync(int id)
        {
            var spell = await _spellRepository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException($"Spell with ID {id} not found.");

            await _spellRepository.DeleteAsync(spell);
            await _spellRepository.SaveChangesAsync();
            return true;
        }

        public async Task<CharacterSpellDTO> AddSpellToCharacterAsync(int characterId, int spellId)
        {
            var exists = await _characterSpellRepository.AnyAsync(
                cs => cs.CharacterID == characterId && cs.SpellID == spellId);

            if (exists)
            {
                throw new InvalidOperationException("Character already has this spell.");
            }

            var characterSpell = new CharacterSpell
            {
                CharacterID = characterId,
                SpellID = spellId,
                Level = 1
            };

            await _characterSpellRepository.AddAsync(characterSpell);
            await _characterSpellRepository.SaveChangesAsync();

            return _mapper.Map<CharacterSpellDTO>(characterSpell);
        }

        public async Task<List<CharacterSpellDTO>> GetAllCharacterSpellsAsync(int characterId)
        {
            var spells = await _characterSpellRepository.GetAllAsync(
                cs => cs.CharacterID == characterId);

            return _mapper.Map<List<CharacterSpellDTO>>(spells);
        }

        public async Task<bool> UpdateCharacterSpellAsync(int characterId, int spellId, int newLevel)
        {
            var characterSpell = await _characterSpellRepository.GetFirstOrDefaultAsync(
                cs => cs.CharacterID == characterId && cs.SpellID == spellId)
                ?? throw new KeyNotFoundException("Character spell not found.");

            characterSpell.Level = newLevel;
            await _characterSpellRepository.UpdateAsync(characterSpell);
            await _characterSpellRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCharacterSpellAsync(int characterId, int spellId)
        {
            var characterSpell = await _characterSpellRepository.GetFirstOrDefaultAsync(
                cs => cs.CharacterID == characterId && cs.SpellID == spellId)
                ?? throw new KeyNotFoundException("Character spell not found.");

            await _characterSpellRepository.DeleteAsync(characterSpell);
            await _characterSpellRepository.SaveChangesAsync();
            return true;
        }
    }
}