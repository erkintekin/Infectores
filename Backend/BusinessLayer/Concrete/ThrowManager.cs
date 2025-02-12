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
    public class ThrowManager : IThrowService
    {
        private readonly IRepository<Throw> _throwRepository;
        private readonly IRepository<CharacterThrow> _characterThrowRepository;

        public ThrowManager(IRepository<Throw> throwRepository, IRepository<CharacterThrow> characterThrowRepository)
        {
            _throwRepository = throwRepository;
            _characterThrowRepository = characterThrowRepository;
        }

        public async Task<Throw> CreateThrow(Throw throwEntity)
        {
            var throwExists = await _throwRepository.List
                .AnyAsync(t => t.Modifier == throwEntity.Modifier || t.ThrowID == throwEntity.ThrowID);

            if (throwExists)
                throw new InvalidOperationException($"A throw with the name `{throwEntity.Modifier}` or ID `{throwEntity.ThrowID}` already exists.");

            await _throwRepository.Create(throwEntity);
            return throwEntity;
        }


        public async Task<List<Throw>> GetAllThrows() => await _throwRepository.List.ToListAsync();

        public async Task<Throw> GetThrowById(int throwId) => await _throwRepository.List.FirstOrDefaultAsync(t => t.ThrowID == throwId) ?? throw new KeyNotFoundException($"Throw with ID: `{throwId}` is not found.");

        public async Task<bool> UpdateThrow(Throw throwEntity)
        {
            _ = await _throwRepository.List.FirstOrDefaultAsync(t => t.ThrowID == throwEntity.ThrowID) ?? throw new KeyNotFoundException($"Throw with ID: `{throwEntity.ThrowID}` is not found.");

            await _throwRepository.Update(throwEntity);
            return true;
        }

        public async Task<bool> DeleteThrow(int throwId)
        {
            var selectedThrow = await _throwRepository.List.FirstOrDefaultAsync(t => t.ThrowID == throwId) ?? throw new KeyNotFoundException($"Throw with ID: `{throwId}` is not found.");

            await _throwRepository.Delete(selectedThrow);
            return true;
        }

        public async Task<List<CharacterThrow>> GetAllCharacterThrows(int characterId)
        {
            var characterExists = await _characterThrowRepository.List.AnyAsync(c => c.CharacterID == characterId);

            if (!characterExists)
                throw new KeyNotFoundException($"Error: No character found with ID `{characterId}`. Please check the ID.");

            var characterThrows = await _characterThrowRepository.List.Where(ct => ct.CharacterID == characterId).ToListAsync();

            if (characterThrows.Count == 0)
                throw new InvalidOperationException($"Character `{characterId}` exists but has no throws assigned.");

            return characterThrows;
        }

        public async Task<bool> UpdateCharacterThrow(int characterId, int throwId, int newValue)
        {
            var characterExists = await _characterThrowRepository.List.AnyAsync(c => c.CharacterID == characterId);

            if (!characterExists)
                throw new KeyNotFoundException($"Error: No character found with ID `{characterId}`. Please check the ID.");

            var characterThrow = await _characterThrowRepository.List.FirstOrDefaultAsync(ct => ct.CharacterID == characterId && ct.ThrowID == throwId) ?? throw new InvalidOperationException($"Character `{characterId}` exists but does not have the throw `{throwId}` assigned.");

            characterThrow.Value = newValue;

            if (newValue < 0)
                throw new ArgumentOutOfRangeException(nameof(newValue), "Throw value cannot be negative.");

            await _characterThrowRepository.Update(characterThrow);
            return true;
        }

        public async Task<bool> DeleteCharacterThrow(int characterId, int throwId)
        {
            var characterExists = await _characterThrowRepository.List.AnyAsync(c => c.CharacterID == characterId);
            if (!characterExists)
                throw new KeyNotFoundException($"Error: No character found with ID `{characterId}`. Please check the ID.");

            var characterThrow = await _characterThrowRepository.List.FirstOrDefaultAsync(ct => ct.CharacterID == characterId && ct.ThrowID == throwId) ?? throw new InvalidOperationException($"Character `{characterId}` exists but does not have the skill `{throwId}` assigned.");

            await _characterThrowRepository.Delete(characterThrow);
            return true;

        }

    }
}