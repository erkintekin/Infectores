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
    public class ProficiencyManager : IProficiencyService
    {
        private readonly IRepository<Proficiency> _proficiencyRepository;
        private readonly IRepository<CharacterProficiency> _characterProficiencyRepository;

        public ProficiencyManager(IRepository<Proficiency> proficiencyRepository, IRepository<CharacterProficiency> characterRepository)
        {
            _proficiencyRepository = proficiencyRepository;
            _characterProficiencyRepository = characterRepository;
        }

        public void CreateProficiency(Proficiency proficiency)
        {
            _proficiencyRepository.Create(proficiency);
        }

        public async Task<List<Proficiency>> GetAllProficiencies() => await _proficiencyRepository.List.ToListAsync();
        public async Task<Proficiency> GetProficiencyById(int proficiencyId) => await _proficiencyRepository.List.FirstOrDefaultAsync(s => s.ProficiencyID == proficiencyId) ?? throw new KeyNotFoundException($"Proficiency with ID {proficiencyId} not found.");
        public async Task<List<CharacterProficiency>> GetAllCharProficiencies(int charId) => await _characterProficiencyRepository.List.Where(s => s.CharacterID == charId).ToListAsync();

        public void UpdateProficiency(Proficiency proficiency)
        {
            _proficiencyRepository.Update(proficiency);
        }

        public void DeleteProficiency(Proficiency proficiency)
        {
            _proficiencyRepository.Delete(proficiency);
        }

    }
}