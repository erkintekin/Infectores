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

        public void UpdateCharacterAbility(CharacterAbility characterAbility)
        {
            _characterAbilityRepository.Update(characterAbility);  // Note: When the new ability score is under 0, warning have to pop up.
        }

        public async Task<List<CharacterAbility>> GetCharacterAbilities(int characterId) => await _characterAbilityRepository.List.Where(s => s.CharacterID == characterId).ToListAsync();
        public async Task<List<Ability>> GetAllAbilities() => await _abilityRepository.List.ToListAsync();
    }
}