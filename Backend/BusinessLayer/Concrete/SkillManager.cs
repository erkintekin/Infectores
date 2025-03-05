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

        public async Task<SkillDTO> CreateSkillAsync(SkillCreateDTO skillDto)
        {
            var exists = await _skillRepository.AnyAsync(s => s.Name.ToLower() == skillDto.Name.ToLower());
            if (exists)
            {
                throw new InvalidOperationException($"Skill with name '{skillDto.Name}' already exists.");
            }

            var skill = _mapper.Map<Skill>(skillDto);
            await _skillRepository.AddAsync(skill);
            await _skillRepository.SaveChangesAsync();

            return await GetSkillByIdAsync(skill.SkillID);
        }

        public async Task<List<SkillDTO>> GetAllSkillsAsync()
        {
            var skills = await _skillRepository.GetAllAsync(includeProperties: "Ability");
            return _mapper.Map<List<SkillDTO>>(skills);
        }

        public async Task<SkillDTO> GetSkillByIdAsync(int id)
        {
            var skill = await _skillRepository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException($"Skill with ID {id} not found.");
            return _mapper.Map<SkillDTO>(skill);
        }

        public async Task<List<CharacterSkillDTO>> GetCharacterSkillsAsync(int characterId)
        {
            var skills = await _characterSkillRepository.GetAllAsync(
                cs => cs.CharacterID == characterId,
                includeProperties: "Skill,Skill.Ability");

            return _mapper.Map<List<CharacterSkillDTO>>(skills);
        }

        public async Task<SkillDTO> UpdateSkillAsync(int id, SkillUpdateDTO skillDto)
        {
            var skill = await _skillRepository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException($"Skill with ID {id} not found.");

            if (skillDto.Name != skill.Name)
            {
                var exists = await _skillRepository.AnyAsync(s => s.Name.ToLower() == skillDto.Name.ToLower());
                if (exists)
                {
                    throw new InvalidOperationException($"Skill with name '{skillDto.Name}' already exists.");
                }
            }

            _mapper.Map(skillDto, skill);
            await _skillRepository.UpdateAsync(skill);
            await _skillRepository.SaveChangesAsync();

            return await GetSkillByIdAsync(id);
        }

        public async Task<bool> DeleteSkillAsync(int id)
        {
            var skill = await _skillRepository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException($"Skill with ID {id} not found.");

            await _skillRepository.DeleteAsync(skill);
            await _skillRepository.SaveChangesAsync();
            return true;
        }

        public async Task<CharacterSkillDTO> UpdateCharacterSkillProficiencyAsync(int characterId, int skillId, bool isProficient)
        {
            var characterSkill = await _characterSkillRepository.GetFirstOrDefaultAsync(
                cs => cs.CharacterID == characterId && cs.SkillID == skillId,
                includeProperties: "Skill,Skill.Ability")
                ?? throw new KeyNotFoundException("Character skill not found.");

            characterSkill.IsProficient = isProficient;
            await _characterSkillRepository.UpdateAsync(characterSkill);
            await _characterSkillRepository.SaveChangesAsync();

            return _mapper.Map<CharacterSkillDTO>(characterSkill);
        }
    }
}