using System;
using System.Collections.Generic;
using System.IO.Compression;
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
    public class CharacterManager : ICharacterService
    {
        private readonly IRepository<Character> _characterRepository;
        private readonly IRepository<CharacterAbility> _characterAbilityRepository;
        private readonly IRepository<CharacterSkill> _characterSkillRepository;
        private readonly IRepository<CharacterSpell> _characterSpellRepository;
        private readonly IRepository<Inventory> _inventoryRepository;
        private readonly IMapper _mapper;

        public CharacterManager(
            IRepository<Character> characterRepository,
            IRepository<CharacterAbility> characterAbilityRepository,
            IRepository<CharacterSkill> characterSkillRepository,
            IRepository<CharacterSpell> characterSpellRepository,
            IRepository<Inventory> inventoryRepository,
            IMapper mapper)
        {
            _characterRepository = characterRepository;
            _characterAbilityRepository = characterAbilityRepository;
            _characterSkillRepository = characterSkillRepository;
            _characterSpellRepository = characterSpellRepository;
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }

        public async Task<CharacterDTO> CreateCharacterAsync(CharacterCreateDTO characterDto)
        {
            var character = _mapper.Map<Character>(characterDto);
            character.Level = 1;
            character.XP = 0;
            character.ArmorClass = 10;

            await _characterRepository.AddAsync(character);
            await _characterRepository.SaveChangesAsync();

            // Temel yetenekleri ekle
            var abilities = new[] { 1, 2, 3, 4, 5, 6 }; // Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma ID'leri
            foreach (var abilityId in abilities)
            {
                var characterAbility = new CharacterAbility
                {
                    CharacterID = character.CharacterID,
                    AbilityID = abilityId,
                    Value = 10
                };
                await _characterAbilityRepository.AddAsync(characterAbility);
            }
            await _characterAbilityRepository.SaveChangesAsync();

            // Boş envanter oluştur
            var inventory = new Inventory { CharacterID = character.CharacterID };
            await _inventoryRepository.AddAsync(inventory);
            await _inventoryRepository.SaveChangesAsync();

            return await GetCharacterByIdAsync(character.CharacterID);
        }

        public async Task<List<CharacterDTO>> GetAllCharactersAsync()
        {
            var characters = await _characterRepository.GetAllAsync();
            return _mapper.Map<List<CharacterDTO>>(characters);
        }

        public async Task<CharacterDTO> GetCharacterByIdAsync(int id)
        {
            var character = await _characterRepository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException($"Character with ID {id} not found.");
            return _mapper.Map<CharacterDTO>(character);
        }

        public async Task<CharacterDTO> UpdateCharacterAsync(int id, CharacterUpdateDTO characterDto)
        {
            var character = await _characterRepository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException($"Character with ID {id} not found.");

            _mapper.Map(characterDto, character);
            await _characterRepository.UpdateAsync(character);
            await _characterRepository.SaveChangesAsync();

            return await GetCharacterByIdAsync(id);
        }

        public async Task<bool> DeleteCharacterAsync(int id)
        {
            var character = await _characterRepository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException($"Character with ID {id} not found.");

            await _characterRepository.DeleteAsync(character);
            await _characterRepository.SaveChangesAsync();
            return true;
        }

        public async Task<CharacterAbilityDTO> UpdateCharacterAbilityValueAsync(int characterId, int abilityId, int value)
        {
            var characterAbility = await _characterAbilityRepository.GetFirstOrDefaultAsync(
                ca => ca.CharacterID == characterId && ca.AbilityID == abilityId)
                ?? throw new KeyNotFoundException("Character ability not found.");

            characterAbility.Value = value;
            await _characterAbilityRepository.UpdateAsync(characterAbility);
            await _characterAbilityRepository.SaveChangesAsync();

            return _mapper.Map<CharacterAbilityDTO>(characterAbility);
        }

        public async Task<CharacterSkillDTO> AddSkillToCharacterAsync(int characterId, int skillId)
        {
            var exists = await _characterSkillRepository.AnyAsync(
                cs => cs.CharacterID == characterId && cs.SkillID == skillId);

            if (exists)
            {
                throw new InvalidOperationException("Character already has this skill.");
            }

            var characterSkill = new CharacterSkill
            {
                CharacterID = characterId,
                SkillID = skillId,
                IsProficient = true
            };

            await _characterSkillRepository.AddAsync(characterSkill);
            await _characterSkillRepository.SaveChangesAsync();

            return _mapper.Map<CharacterSkillDTO>(characterSkill);
        }

        public async Task<bool> RemoveSkillFromCharacterAsync(int characterId, int skillId)
        {
            var characterSkill = await _characterSkillRepository.GetFirstOrDefaultAsync(
                cs => cs.CharacterID == characterId && cs.SkillID == skillId)
                ?? throw new KeyNotFoundException("Character skill not found.");

            await _characterSkillRepository.DeleteAsync(characterSkill);
            await _characterSkillRepository.SaveChangesAsync();
            return true;
        }
    }
}