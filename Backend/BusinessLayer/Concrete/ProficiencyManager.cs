using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.BusinessLayer.Abstract;
using Backend.DataAccessLayer.Abstract;
using Backend.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Backend.DTOs;
using Backend.BusinessLayer.Exceptions;
using AutoMapper;

namespace Backend.BusinessLayer.Concrete
{
    public class ProficiencyManager : IProficiencyService
    {
        private readonly IRepository<Proficiency> _proficiencyRepository;
        private readonly IRepository<CharacterProficiency> _characterProficiencyRepository;
        private readonly IRepository<ProficiencyTool> _proficiencyToolRepository;
        private readonly IRepository<Tool> _toolRepository;

        public ProficiencyManager(IRepository<Proficiency> proficiencyRepository, IRepository<CharacterProficiency> characterRepository, IRepository<ProficiencyTool> proficiencyToolRepository, IRepository<Tool> toolRepository)
        {
            _proficiencyRepository = proficiencyRepository;
            _characterProficiencyRepository = characterRepository;
            _proficiencyToolRepository = proficiencyToolRepository;
            _toolRepository = toolRepository;
        }

        public async Task<Proficiency> CreateProficiency(Proficiency proficiency)
        {
            var addedProficiency = await _proficiencyRepository.AddAsync(proficiency);
            await _proficiencyRepository.SaveChangesAsync();
            return addedProficiency;
        }

        public async Task<List<Proficiency>> GetAllProficiencies()
        {
            var proficiencies = await _proficiencyRepository.GetAllAsync();
            return proficiencies.ToList();
        }

        public async Task<Proficiency> GetProficiencyById(int proficiencyId)
        {
            var proficiency = await _proficiencyRepository.GetByIdAsync(proficiencyId);
            if (proficiency == null)
                throw new KeyNotFoundException($"Proficiency with ID {proficiencyId} not found.");
            return proficiency;
        }

        public async Task<List<CharacterProficiency>> GetAllCharProficiencies(int charId)
        {
            var characterProficiencies = await _characterProficiencyRepository.GetAllAsync(s => s.CharacterID == charId);
            return characterProficiencies.ToList();
        }

        public async Task<CharacterProficiency> AddProficiencyToCharacter(int characterId, int proficiencyId)
        {
            var existingProficiency = await _characterProficiencyRepository.GetFirstOrDefaultAsync(
                s => s.CharacterID == characterId && s.ProficiencyID == proficiencyId);

            if (existingProficiency != null)
            {
                throw new InvalidOperationException("Character already has this proficiency.");
            }

            var existingCharacter = await _characterProficiencyRepository.AnyAsync(s => s.CharacterID == characterId);
            var proficiencyExists = await _proficiencyRepository.AnyAsync(s => s.ProficiencyID == proficiencyId);

            if (!existingCharacter || !proficiencyExists)
            {
                throw new KeyNotFoundException("Character or Proficiency not found");
            }

            var newCharacterProficiency = new CharacterProficiency
            {
                CharacterID = characterId,
                ProficiencyID = proficiencyId
            };

            await _characterProficiencyRepository.AddAsync(newCharacterProficiency);
            await _characterProficiencyRepository.SaveChangesAsync();

            return newCharacterProficiency;
        }

        public async Task<bool> UpdateProficiency(Proficiency proficiency)
        {
            var existingProficiency = await _proficiencyRepository.GetByIdAsync(proficiency.ProficiencyID);
            if (existingProficiency == null)
                return false;

            await _proficiencyRepository.UpdateAsync(proficiency);
            await _proficiencyRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProficiency(int proficiencyId)
        {
            var existingProficiency = await _proficiencyRepository.GetByIdAsync(proficiencyId);
            if (existingProficiency == null)
                return false;

            await _proficiencyRepository.DeleteAsync(existingProficiency);
            await _proficiencyRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCharacterProficiency(int characterId, int proficiencyId)
        {
            var characterProficiency = await _characterProficiencyRepository.GetFirstOrDefaultAsync(
                cp => cp.CharacterID == characterId && cp.ProficiencyID == proficiencyId);

            if (characterProficiency == null)
                return false;

            await _characterProficiencyRepository.DeleteAsync(characterProficiency);
            await _characterProficiencyRepository.SaveChangesAsync();
            return true;
        }

        public async Task<ProficiencyTool> AddToolToProficiency(int proficiencyId, int toolId)
        {
            var existingProficiency = await _proficiencyRepository.AnyAsync(pt => pt.ProficiencyID == proficiencyId);

            if (!existingProficiency)
            {
                throw new KeyNotFoundException($"Proficiency with ID `{proficiencyId}` not found.");
            }

            var existingTool = await _toolRepository.AnyAsync(pt => pt.ToolID == toolId);

            if (!existingTool)
            {
                throw new KeyNotFoundException($"Tool with ID `{toolId}` not found");
            }

            var existingProficiencyTool = await _proficiencyToolRepository.GetFirstOrDefaultAsync(
                pt => pt.ProficiencyID == proficiencyId && pt.ToolID == toolId);

            if (existingProficiencyTool != null)
            {
                throw new InvalidOperationException($"Proficiency {proficiencyId} has Tool {toolId} already.");
            }

            var newProficiencyTool = new ProficiencyTool
            {
                ProficiencyID = proficiencyId,
                ToolID = toolId
            };

            await _proficiencyToolRepository.AddAsync(newProficiencyTool);
            await _proficiencyToolRepository.SaveChangesAsync();
            return newProficiencyTool;
        }

    }
}