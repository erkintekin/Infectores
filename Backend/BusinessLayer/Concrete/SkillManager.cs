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
    public class SkillManager : ISkillService
    {
        private readonly IRepository<Skill> _skillRepository;
        private readonly IRepository<CharacterSkill> _characterSkillRepository;
        private readonly IMapper _mapper;

        public SkillManager(
            IRepository<Skill> skillRepository,
            IRepository<CharacterSkill> characterSkillRepository,
            IMapper mapper)
        {
            _skillRepository = skillRepository;
            _characterSkillRepository = characterSkillRepository;
            _mapper = mapper;
        }

        public async Task<SkillDTO> CreateSkillAsync(SkillDTO skillDto)
        {
            var skillExists = await _skillRepository.List.AnyAsync(i => i.Name == skillDto.Name);
            if (skillExists)
                throw new InvalidOperationException($"A skill with the name `{skillDto.Name}` already exists");

            var skill = _mapper.Map<Skill>(skillDto);
            await _skillRepository.Create(skill);
            return _mapper.Map<SkillDTO>(skill);
        }

        public async Task<List<SkillDTO>> GetAllSkillsAsync()
        {
            var skills = await _skillRepository.List.ToListAsync();
            return _mapper.Map<List<SkillDTO>>(skills);
        }

        public async Task<SkillDTO> GetSkillByIdAsync(int skillId)
        {
            var skill = await _skillRepository.List.FirstOrDefaultAsync(i => i.SkillID == skillId)
                ?? throw new KeyNotFoundException($"Skill with ID: `{skillId}` is not found.");
            return _mapper.Map<SkillDTO>(skill);
        }

        public async Task<bool> UpdateSkillAsync(SkillDTO skillDto)
        {
            var skill = _mapper.Map<Skill>(skillDto);
            _ = await _skillRepository.List.FirstOrDefaultAsync(s => s.SkillID == skill.SkillID)
                ?? throw new KeyNotFoundException($"Skill with ID: `{skill.SkillID}` is not found.");

            await _skillRepository.Update(skill);
            return true;
        }

        public async Task<bool> DeleteSkillAsync(int skillId)
        {
            var skill = await _skillRepository.List.FirstOrDefaultAsync(s => s.SkillID == skillId)
                ?? throw new KeyNotFoundException($"Skill with ID: `{skillId}` is not found.");

            await _skillRepository.Delete(skill);
            return true;
        }

        public async Task<List<CharacterSkillDTO>> GetCharacterSkillsAsync(int characterId)
        {
            var characterSkills = await _characterSkillRepository.List
                .Where(cs => cs.CharacterID == characterId)
                .ToListAsync();

            return _mapper.Map<List<CharacterSkillDTO>>(characterSkills);
        }

        public async Task<bool> UpdateCharacterSkillAsync(int characterId, int skillId, int newValue)
        {
            var characterSkill = await _characterSkillRepository.List
                .FirstOrDefaultAsync(cs => cs.CharacterID == characterId && cs.SkillID == skillId)
                ?? throw new KeyNotFoundException($"Character skill not found.");

            characterSkill.Value = newValue;
            await _characterSkillRepository.Update(characterSkill);
            return true;
        }

        public async Task<bool> DeleteCharacterSkillAsync(int characterId, int skillId)
        {
            var characterSkill = await _characterSkillRepository.List
                .FirstOrDefaultAsync(cs => cs.CharacterID == characterId && cs.SkillID == skillId)
                ?? throw new KeyNotFoundException($"Character skill not found.");

            await _characterSkillRepository.Delete(characterSkill);
            return true;
        }
    }
}