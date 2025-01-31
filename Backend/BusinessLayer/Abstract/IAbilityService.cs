using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.EntityLayer.Concrete;

namespace Backend.BusinessLayer.Abstract
{
    public interface IAbilityService
    {
        Task<List<Ability>> GetAllAbilities();
        Task<List<CharacterAbility>> GetCharacterAbilities(int characterId);
        void UpdateCharacterAbility(CharacterAbility characterAbility);

    }
}