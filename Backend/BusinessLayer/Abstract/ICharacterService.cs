using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.EntityLayer.Concrete;
using Backend.DTOs;

namespace Backend.BusinessLayer.Abstract
{
    public interface ICharacterService
    {
        Task<CharacterDTO> CreateCharacterAsync(CharacterCreateDTO characterDto);
        Task<List<CharacterDTO>> GetAllCharactersAsync();
        Task<CharacterDTO> GetCharacterByIdAsync(int id);
        Task<CharacterDTO> UpdateCharacterAsync(int id, CharacterUpdateDTO characterDto);
        Task<bool> DeleteCharacterAsync(int id);
        Task<CharacterAbilityDTO> UpdateCharacterAbilityValueAsync(int characterId, int abilityId, int value);
        Task<CharacterSkillDTO> AddSkillToCharacterAsync(int characterId, int skillId);
        Task<bool> RemoveSkillFromCharacterAsync(int characterId, int skillId);
    }
}