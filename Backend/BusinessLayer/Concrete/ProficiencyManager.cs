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
            await _proficiencyRepository.Create(proficiency);
            return proficiency;
        }

        public async Task<List<Proficiency>> GetAllProficiencies() => await _proficiencyRepository.List.ToListAsync();
        public async Task<Proficiency> GetProficiencyById(int proficiencyId) => await _proficiencyRepository.List.FirstOrDefaultAsync(s => s.ProficiencyID == proficiencyId) ?? throw new KeyNotFoundException($"Proficiency with ID {proficiencyId} not found.");
        public async Task<List<CharacterProficiency>> GetAllCharProficiencies(int charId) => await _characterProficiencyRepository.List.Where(s => s.CharacterID == charId).ToListAsync();

        public async Task<CharacterProficiency> AddProficiencyToCharacter(int characterId, int proficiencyId)
        {
            var existingProficiency = await _characterProficiencyRepository.List.FirstOrDefaultAsync(s => s.CharacterID == characterId && s.ProficiencyID == proficiencyId);

            if (existingProficiency != null)
            {
                throw new InvalidOperationException("Character already has this proficiency.");
            }

            var existingCharacter = await _characterProficiencyRepository.List.AnyAsync(s => s.CharacterID == characterId);
            var proficiencyExists = await _proficiencyRepository.List.AnyAsync(s => s.ProficiencyID == proficiencyId);

            if (!existingCharacter || !proficiencyExists)
            {
                throw new KeyNotFoundException("Character or Proficiency not found");
            }

            var newCharacterProficiency = new CharacterProficiency
            {
                CharacterID = characterId,
                ProficiencyID = proficiencyId
            };

            await _characterProficiencyRepository.Create(newCharacterProficiency);

            return newCharacterProficiency;
        }

        public async Task<bool> UpdateProficiency(Proficiency proficiency)
        {
            var existingProficiency = await _proficiencyRepository.List.FirstOrDefaultAsync(s => s.ProficiencyID == proficiency.ProficiencyID);
            if (existingProficiency == null)
                return false;

            await _proficiencyRepository.Update(proficiency);
            return true;
        }

        public async Task<bool> DeleteProficiency(int proficiencyId)
        {
            var existingProficiency = await _proficiencyRepository.List.FirstOrDefaultAsync(s => s.ProficiencyID == proficiencyId);
            if (existingProficiency == null)
                return false;

            await _proficiencyRepository.Delete(existingProficiency);
            return true;
        }

        public async Task<bool> DeleteCharacterProficiency(int characterId, int proficiencyId)
        {
            var characterProficiency = new CharacterProficiency
            {
                CharacterID = characterId,
                ProficiencyID = proficiencyId
            };

            if (characterProficiency == null)
                return false;

            await _characterProficiencyRepository.Delete(characterProficiency);
            return true;
        }

        public async Task<ProficiencyTool> AddToolToProficiency(int proficiencyId, int toolId)
        {
            var existingProficiency = await _proficiencyRepository.List.AnyAsync(pt => pt.ProficiencyID == proficiencyId);

            if (!existingProficiency)
            {
                throw new KeyNotFoundException($"Proficiency with ID `{proficiencyId}` not found.");
            }

            var existingTool = await _toolRepository.List.AnyAsync(pt => pt.ToolID == toolId);

            if (!existingTool)
            {
                throw new KeyNotFoundException($"Tool with ID `{toolId}` not found");
            }

            var existingProficiencyTool = await _proficiencyToolRepository.List.FirstOrDefaultAsync(pt => pt.ProficiencyID == proficiencyId && pt.ToolID == toolId);

            if (existingProficiencyTool != null)
            {
                throw new InvalidOperationException($"Proficiency {proficiencyId} has Tool {toolId} already.");
            }

            var newProficiencyTool = new ProficiencyTool
            {
                ProficiencyID = proficiencyId,
                ToolID = toolId
            };

            await _proficiencyToolRepository.Create(newProficiencyTool);
            return newProficiencyTool;
        }

    }
}