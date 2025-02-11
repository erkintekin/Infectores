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
            var throwExists = await _throwRepository.List.AnyAsync(t => t.Modifier == throwEntity.Modifier);

            if (throwExists)
                throw new InvalidOperationException($"An throw with the name `{throwEntity.Modifier}` already exists");

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

    }
}