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
    public class SenseManager : ISenseService
    {
        private readonly IRepository<Sense> _senseRepository;
        private readonly IRepository<CharacterSenses> _characterSensesRepository;
        private readonly IRepository<Character> _characterRepository;
        private readonly IMapper _mapper;

        public SenseManager(
            IRepository<Sense> senseRepository,
            IRepository<CharacterSenses> characterSensesRepository,
            IRepository<Character> characterRepository,
            IMapper mapper)
        {
            _senseRepository = senseRepository;
            _characterSensesRepository = characterSensesRepository;
            _characterRepository = characterRepository;
            _mapper = mapper;
        }

        public async Task<Sense> CreateSense(Sense sense)
        {
            var addedSense = await _senseRepository.AddAsync(sense);
            await _senseRepository.SaveChangesAsync();
            return addedSense;
        }

        public async Task<List<Sense>> GetAllSenses()
        {
            var senses = await _senseRepository.GetAllAsync();
            return senses.ToList();
        }

        public async Task<Sense> GetSenseById(int senseId)
        {
            var sense = await _senseRepository.GetByIdAsync(senseId);
            if (sense == null)
                throw new NotFoundException($"Sense with ID {senseId} not found");
            return sense;
        }

        public async Task<bool> UpdateSense(Sense sense)
        {
            var existingSense = await _senseRepository.GetByIdAsync(sense.SenseID);
            if (existingSense == null)
                throw new NotFoundException($"Sense with ID {sense.SenseID} not found");

            await _senseRepository.UpdateAsync(sense);
            await _senseRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteSense(int senseId)
        {
            var sense = await _senseRepository.GetByIdAsync(senseId);
            if (sense == null)
                throw new NotFoundException($"Sense with ID {senseId} not found");

            await _senseRepository.DeleteAsync(sense);
            await _senseRepository.SaveChangesAsync();
            return true;
        }

        public async Task<CharacterSenses> AddSenseToCharacterAsync(int characterId, int senseId)
        {
            var character = await _characterRepository.GetByIdAsync(characterId)
                ?? throw new NotFoundException($"Character with ID {characterId} not found");

            var sense = await _senseRepository.GetByIdAsync(senseId)
                ?? throw new NotFoundException($"Sense with ID {senseId} not found");

            var characterSense = new CharacterSenses
            {
                CharacterID = characterId,
                SenseID = senseId,
                Character = character,
                Sense = sense
            };

            var addedCharacterSense = await _characterSensesRepository.AddAsync(characterSense);
            await _characterSensesRepository.SaveChangesAsync();
            return addedCharacterSense;
        }

        public async Task<IEnumerable<CharacterSenses>> GetCharacterSensesAsync(int characterId)
        {
            var characterSenses = await _characterSensesRepository.GetAllAsync(
                cs => cs.CharacterID == characterId,
                includeProperties: "Sense");
            return characterSenses;
        }

        public async Task DeleteCharacterSenseAsync(int characterId, int senseId)
        {
            var characterSense = await _characterSensesRepository.GetFirstOrDefaultAsync(
                cs => cs.CharacterID == characterId && cs.SenseID == senseId);

            if (characterSense == null)
                throw new NotFoundException($"Character sense not found for Character ID {characterId} and Sense ID {senseId}");

            await _characterSensesRepository.DeleteAsync(characterSense);
            await _characterSensesRepository.SaveChangesAsync();
        }
    }
}