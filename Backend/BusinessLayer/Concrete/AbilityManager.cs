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
    public class AbilityManager : IAbilityService
    {
        private readonly IRepository<Ability> _abilityRepository;
        private readonly IRepository<CharacterAbility> _characterAbilityRepository;
        private readonly IMapper _mapper;

        public AbilityManager(
            IRepository<Ability> abilityRepository,
            IRepository<CharacterAbility> characterAbilityRepository,
            IMapper mapper)
        {
            _abilityRepository = abilityRepository;
            _characterAbilityRepository = characterAbilityRepository;
            _mapper = mapper;
        }

        public async Task<AbilityDTO> CreateAbilityAsync(AbilityCreateDTO abilityDto)
        {
            var exists = await _abilityRepository.List
                .AnyAsync(a => a.AbilityName.ToLower() == abilityDto.AbilityName.ToLower());

            if (exists)
            {
                throw new InvalidOperationException($"Ability with name '{abilityDto.AbilityName}' already exists.");
            }

            var ability = _mapper.Map<Ability>(abilityDto);
            await _abilityRepository.Create(ability);

            return await GetAbilityByIdAsync(ability.AbilityID);
        }

        public async Task<List<AbilityDTO>> GetAllAbilitiesAsync()
        {
            var abilities = await _abilityRepository.List.ToListAsync();
            return _mapper.Map<List<AbilityDTO>>(abilities);
        }

        public async Task<AbilityDTO> GetAbilityByIdAsync(int id)
        {
            var ability = await _abilityRepository.List
                .FirstOrDefaultAsync(a => a.AbilityID == id)
                ?? throw new KeyNotFoundException($"Ability with ID {id} not found.");

            return _mapper.Map<AbilityDTO>(ability);
        }

        public async Task<List<CharacterAbilityDTO>> GetCharacterAbilitiesAsync(int characterId)
        {
            var abilities = await _characterAbilityRepository.List
                .Include(ca => ca.Ability)
                .Where(ca => ca.CharacterID == characterId)
                .ToListAsync();

            return _mapper.Map<List<CharacterAbilityDTO>>(abilities);
        }

        public async Task<AbilityDTO> UpdateAbilityAsync(int id, AbilityUpdateDTO abilityDto)
        {
            var ability = await _abilityRepository.List
                .FirstOrDefaultAsync(a => a.AbilityID == id)
                ?? throw new KeyNotFoundException($"Ability with ID {id} not found.");

            if (abilityDto.AbilityName != ability.AbilityName)
            {
                var exists = await _abilityRepository.List
                    .AnyAsync(a => a.AbilityName.ToLower() == abilityDto.AbilityName.ToLower());

                if (exists)
                {
                    throw new InvalidOperationException($"Ability with name '{abilityDto.AbilityName}' already exists.");
                }
            }

            _mapper.Map(abilityDto, ability);
            await _abilityRepository.Update(ability);

            return await GetAbilityByIdAsync(id);
        }

        public async Task<bool> DeleteAbilityAsync(int id)
        {
            var ability = await _abilityRepository.List
                .FirstOrDefaultAsync(a => a.AbilityID == id)
                ?? throw new KeyNotFoundException($"Ability with ID {id} not found.");

            await _abilityRepository.Delete(ability);
            return true;
        }

        public async Task<CharacterAbilityDTO> UpdateCharacterAbilityValueAsync(int characterId, int abilityId, int value)
        {
            var characterAbility = await _characterAbilityRepository.List
                .Include(ca => ca.Ability)
                .FirstOrDefaultAsync(ca => ca.CharacterID == characterId && ca.AbilityID == abilityId)
                ?? throw new KeyNotFoundException("Character ability not found.");

            characterAbility.Value = value;
            await _characterAbilityRepository.Update(characterAbility);

            return _mapper.Map<CharacterAbilityDTO>(characterAbility);
        }
    }
}