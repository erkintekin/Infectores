using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.EntityLayer.Concrete;

namespace Backend.BusinessLayer.Abstract
{
    public interface ISkillService
    {
        Task<Skill> CreateSkill(Skill skill);
        Task<List<Skill>> GetAllSkills();
        Task<Skill> GetSkillById(int skillId);
        Task<bool> UpdateSkill(Skill skill);
        Task<bool> DeleteSkill(int skillId);
        Task<List<CharacterSkill>> GetCharacterSkills(int characterId);
        Task<bool> UpdateCharacterSkill(int characterId, int skillId, int newValue);
        Task<bool> DeleteCharacterSkill(int characterId, int skillId);

    }
}