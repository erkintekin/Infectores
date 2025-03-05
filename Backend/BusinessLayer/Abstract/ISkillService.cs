using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.EntityLayer.Concrete;
using Backend.DTOs;

namespace Backend.BusinessLayer.Abstract
{
    public interface ISkillService
    {
        Task<SkillDTO> CreateSkillAsync(SkillCreateDTO skillDto);
        Task<List<SkillDTO>> GetAllSkillsAsync();
        Task<SkillDTO> GetSkillByIdAsync(int id);
        Task<List<CharacterSkillDTO>> GetCharacterSkillsAsync(int characterId);
        Task<SkillDTO> UpdateSkillAsync(int id, SkillUpdateDTO skillDto);
        Task<bool> DeleteSkillAsync(int id);
        Task<CharacterSkillDTO> UpdateCharacterSkillProficiencyAsync(int characterId, int skillId, bool isProficient);
    }
}