using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.BusinessLayer.Abstract;
using Backend.DataAccessLayer.Abstract;
using Backend.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Backend.BusinessLayer.Exceptions;
using AutoMapper;

namespace Backend.BusinessLayer.Concrete
{
    public class ThrowManager : IThrowService
    {
        private readonly IRepository<Throw> _throwRepository;
        private readonly IRepository<CharacterThrow> _characterThrowRepository;
        private readonly IRepository<Character> _characterRepository;
        private readonly IMapper _mapper;

        public ThrowManager(
            IRepository<Throw> throwRepository,
            IRepository<CharacterThrow> characterThrowRepository,
            IRepository<Character> characterRepository,
            IMapper mapper)
        {
            _throwRepository = throwRepository;
            _characterThrowRepository = characterThrowRepository;
            _characterRepository = characterRepository;
            _mapper = mapper;
        }

        public async Task<Throw> CreateThrow(Throw throwEntity)
        {
            var addedThrow = await _throwRepository.AddAsync(throwEntity);
            await _throwRepository.SaveChangesAsync();
            return addedThrow;
        }

        public async Task<List<Throw>> GetAllThrows()
        {
            var throws = await _throwRepository.GetAllAsync();
            return throws.ToList();
        }

        public async Task<Throw> GetThrowById(int throwId)
        {
            var throwEntity = await _throwRepository.GetByIdAsync(throwId);
            if (throwEntity == null)
                throw new NotFoundException($"Throw with ID {throwId} not found");
            return throwEntity;
        }

        public async Task<bool> UpdateThrow(Throw throwEntity)
        {
            var existingThrow = await _throwRepository.GetByIdAsync(throwEntity.ThrowID);
            if (existingThrow == null)
                throw new NotFoundException($"Throw with ID {throwEntity.ThrowID} not found");

            await _throwRepository.UpdateAsync(throwEntity);
            await _throwRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteThrow(int throwId)
        {
            var throwEntity = await _throwRepository.GetByIdAsync(throwId);
            if (throwEntity == null)
                throw new NotFoundException($"Throw with ID {throwId} not found");

            await _throwRepository.DeleteAsync(throwEntity);
            await _throwRepository.SaveChangesAsync();
            return true;
        }

        public async Task<List<CharacterThrow>> GetAllCharacterThrows(int characterId)
        {
            var characterThrows = await _characterThrowRepository.GetAllAsync(
                ct => ct.CharacterID == characterId,
                includeProperties: "Throw");
            return characterThrows.ToList();
        }

        public async Task<bool> UpdateCharacterThrow(int characterId, int throwId, int newValue)
        {
            var characterThrow = await _characterThrowRepository.GetFirstOrDefaultAsync(
                ct => ct.CharacterID == characterId && ct.ThrowID == throwId);

            if (characterThrow == null)
                throw new NotFoundException($"Character throw not found for Character ID {characterId} and Throw ID {throwId}");

            characterThrow.BonusValue = newValue;
            await _characterThrowRepository.UpdateAsync(characterThrow);
            await _characterThrowRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCharacterThrow(int characterId, int throwId)
        {
            var characterThrow = await _characterThrowRepository.GetFirstOrDefaultAsync(
                ct => ct.CharacterID == characterId && ct.ThrowID == throwId);

            if (characterThrow == null)
                throw new NotFoundException($"Character throw not found for Character ID {characterId} and Throw ID {throwId}");

            await _characterThrowRepository.DeleteAsync(characterThrow);
            await _characterThrowRepository.SaveChangesAsync();
            return true;
        }

        public async Task<CharacterThrow> AddThrowToCharacterAsync(int characterId, int throwId)
        {
            var character = await _characterRepository.GetByIdAsync(characterId)
                ?? throw new NotFoundException($"Character with ID {characterId} not found");

            var throwEntity = await _throwRepository.GetByIdAsync(throwId)
                ?? throw new NotFoundException($"Throw with ID {throwId} not found");

            var characterThrow = new CharacterThrow
            {
                CharacterID = characterId,
                ThrowID = throwId,
                Character = character,
                Throw = throwEntity
            };

            var addedCharacterThrow = await _characterThrowRepository.AddAsync(characterThrow);
            await _characterThrowRepository.SaveChangesAsync();
            return addedCharacterThrow;
        }
    }
}