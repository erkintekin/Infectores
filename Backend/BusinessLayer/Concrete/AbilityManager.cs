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
    public class AbilityManager : IAbilityService
    {
        private readonly IRepository<Ability> _abilityRepository;
        private readonly IRepository<CharacterAbility> _characterAbilityRepository;

        public AbilityManager(IRepository<Ability> abilityRepository, IRepository<CharacterAbility> characterAbilityRepository)
        {
            _abilityRepository = abilityRepository;
            _characterAbilityRepository = characterAbilityRepository;
        }

        public async Task<bool> UpdateCharacterAbility(int characterId, int abilityId, int newValue)
        {
            var characterAbility = await _characterAbilityRepository.List.FirstOrDefaultAsync(s => s.CharacterID == characterId && s.AbilityID == abilityId);

            if (characterAbility == null)
                return false;

            if (newValue < 0)
                throw new ArgumentOutOfRangeException(nameof(newValue), "Ability value cannot be negative.");

            characterAbility.Value = newValue;
            await _characterAbilityRepository.Update(characterAbility);
            return true;
        }

        public async Task<List<CharacterAbility>> GetCharacterAbilities(int characterId) => await _characterAbilityRepository.List.Where(s => s.CharacterID == characterId).ToListAsync();
        public async Task<List<Ability>> GetAllAbilities() => await _abilityRepository.List.ToListAsync();
    }
}