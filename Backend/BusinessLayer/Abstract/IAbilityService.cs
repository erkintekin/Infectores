using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.EntityLayer.Concrete;
using Backend.DTOs;

namespace Backend.BusinessLayer.Abstract
{
    public interface IAbilityService
    {
        Task<AbilityDTO> CreateAbilityAsync(AbilityCreateDTO abilityDto);
        Task<List<AbilityDTO>> GetAllAbilitiesAsync();
        Task<AbilityDTO> GetAbilityByIdAsync(int id);
        Task<List<CharacterAbilityDTO>> GetCharacterAbilitiesAsync(int characterId);
        Task<AbilityDTO> UpdateAbilityAsync(int id, AbilityUpdateDTO abilityDto);
        Task<bool> DeleteAbilityAsync(int id);
        Task<CharacterAbilityDTO> UpdateCharacterAbilityValueAsync(int characterId, int abilityId, int value);
    }
}