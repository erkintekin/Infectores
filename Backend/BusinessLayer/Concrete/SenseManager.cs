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
    public class SenseManager : ISenseService
    {
        private readonly IRepository<Sense> _senseRepository;

        public SenseManager(IRepository<Sense> senseRepository)
        {
            _senseRepository = senseRepository;
        }

        public async Task<Sense> CreateSense(Sense sense)
        {
            var isExists = await _senseRepository.List.AnyAsync(s => s.SenseID == sense.SenseID);

            if (isExists)
            {
                throw new InvalidOperationException($"Sense with ID:`{sense.SenseID}` has already assigned.");
            }

            await _senseRepository.Create(sense);
            return sense;
        }

        public async Task<List<Sense>> GetAllSenses() => await _senseRepository.List.ToListAsync();

        public async Task<Sense> GetSenseById(int senseId) => await _senseRepository.List.FirstOrDefaultAsync(s => s.SenseID == senseId) ?? throw new KeyNotFoundException($"Sense with ID: `{senseId}` not found.");

        public async Task<bool> UpdateSense(Sense sense)
        {
            var existingSense = await _senseRepository.List.FirstOrDefaultAsync(s => s.SenseID == sense.SenseID) ?? throw new KeyNotFoundException($"Sense with ID:`{sense.SenseID}` not found.");

            await _senseRepository.Update(sense);
            return true;
        }


        public async Task<bool> DeleteSense(int senseId)
        {
            var selectedSense = await _senseRepository.List.FirstOrDefaultAsync(s => s.SenseID == senseId) ?? throw new KeyNotFoundException($"Sense with ID: `{senseId}` not found.");

            await _senseRepository.Delete(selectedSense);
            return true;
        }
    }
}