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
    public class SkillManager : ISkillService
    {
        private readonly IRepository<Skill> _skillRepository;
        private readonly IRepository<CharacterSkill> _characterSkillRepository;

        public SkillManager(IRepository<Skill> skillRepository, IRepository<CharacterSkill> characterSkillRepository)
        {
            _skillRepository = skillRepository;
            _characterSkillRepository = characterSkillRepository;

        }

        public async Task<Skill> CreateSkill(Skill skill)
        {
            var skillExists = await _skillRepository.List.AnyAsync(i => i.Name == skill.Name && i.SkillID == skill.SkillID);

            if (skillExists)
                throw new InvalidOperationException($"An skill with the name `{skill.Name}` already exists");

            await _skillRepository.Create(skill);
            return skill;
        }

        public async Task<List<Skill>> GetAllSkills() => await _skillRepository.List.ToListAsync();
        public async Task<Skill> GetSkillById(int skillId) => await _skillRepository.List.FirstOrDefaultAsync(i => i.SkillID == skillId) ?? throw new KeyNotFoundException($"Skill with ID: `{skillId}` is not found.");
        public async Task<bool> UpdateSkill(Skill skill)
        {
            _ = await _skillRepository.List.FirstOrDefaultAsync(s => s.SkillID == skill.SkillID) ?? throw new KeyNotFoundException($"Skill with ID: `{skill.SkillID}` is not found.");

            await _skillRepository.Update(skill);
            return true;
        }

        public async Task<bool> DeleteSkill(int skillId)
        {
            var selectedSkill = await _skillRepository.List.FirstOrDefaultAsync(s => s.SkillID == skillId) ?? throw new KeyNotFoundException($"Skill with ID: `{skillId}` is not found or character has not have it.");

            await _skillRepository.Delete(selectedSkill);
            return true;

        }

        public async Task<List<CharacterSkill>> GetCharacterSkills(int characterId)
        {
            var characterExists = await _characterSkillRepository.List.AnyAsync(c => c.CharacterID == characterId);
            if (!characterExists)
                throw new KeyNotFoundException($"Error: No character found with ID `{characterId}`. Please check the ID.");

            var characterSkills = await _characterSkillRepository.List
                .Where(cs => cs.CharacterID == characterId)
                .ToListAsync();

            if (characterSkills.Count == 0)
                throw new InvalidOperationException($"Character `{characterId}` exists but has no skills assigned.");

            return characterSkills;
        }

        public async Task<bool> UpdateCharacterSkill(int characterId, int skillId, int newValue)
        {
            var characterExists = await _characterSkillRepository.List.AnyAsync(c => c.CharacterID == characterId);
            if (!characterExists)
                throw new KeyNotFoundException($"No character found with ID `{characterId}`. Please check the ID.");

            var characterSkill = await _characterSkillRepository.List
                .FirstOrDefaultAsync(cs => cs.CharacterID == characterId && cs.SkillID == skillId) ?? throw new InvalidOperationException($"Character `{characterId}` exists but does not have the skill `{skillId}` assigned.");

            characterSkill.Value = newValue;

            if (newValue < 0)
                throw new ArgumentOutOfRangeException(nameof(newValue), "Skill value cannot be negative.");

            await _characterSkillRepository.Update(characterSkill);
            return true;
        }

        public async Task<bool> DeleteCharacterSkill(int characterId, int skillId)
        {
            var characterExists = await _characterSkillRepository.List.AnyAsync(cs => cs.CharacterID == characterId);
            if (!characterExists)
            {
                throw new KeyNotFoundException($"No character found with ID `{characterId}`. Please check the ID.");
            }

            var characterSkill = await _characterSkillRepository.List.FirstOrDefaultAsync(cs => cs.CharacterID == characterId && cs.SkillID == skillId) ?? throw new InvalidOperationException($"Character `{characterId}` exists but does not have the skill `{skillId}` assigned.");

            await _characterSkillRepository.Delete(characterSkill);
            return true;
        }

    }
}