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
    public class SkillManager : IRepository<ISkillService>
    {
        private readonly IRepository<Skill> _skillRepository;
        private readonly IRepository<CharacterSkill> _characterSkillRepository;

        public async Task<Skill> CreateSkill(Skill skill)
        {
            var skillExists = await _skillRepository.List.AnyAsync(i => i.Name == skill.Name && i.SkillID == skill.SkillID);

            if (skillExists)
            {
                throw new InvalidOperationException($"An skill with the name `{skill.Name}` already exists");
            }
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

    }
}