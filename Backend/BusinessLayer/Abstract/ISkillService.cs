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
        Task<SkillDTO> CreateSkillAsync(SkillDTO skillDto);
        Task<List<SkillDTO>> GetAllSkillsAsync();
        Task<SkillDTO> GetSkillByIdAsync(int skillId);
        Task<bool> UpdateSkillAsync(SkillDTO skillDto);
        Task<bool> DeleteSkillAsync(int skillId);
        Task<List<CharacterSkillDTO>> GetCharacterSkillsAsync(int characterId);
        Task<bool> UpdateCharacterSkillAsync(int characterId, int skillId, int newValue);
        Task<bool> DeleteCharacterSkillAsync(int characterId, int skillId);
    }
}