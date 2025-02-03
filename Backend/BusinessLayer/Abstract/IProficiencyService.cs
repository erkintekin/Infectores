using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.EntityLayer.Concrete;

namespace Backend.BusinessLayer.Abstract
{
    public interface IProficiencyService
    {
        Task<Proficiency> CreateProficiency(Proficiency proficiency);
        Task<List<Proficiency>> GetAllProficiencies();
        Task<Proficiency> GetProficiencyById(int id);
        Task<List<CharacterProficiency>> GetAllCharProficiencies(int characterId);
        Task<CharacterProficiency> AddProficiencyToCharacter(int characterId, int proficiencyId);
        Task<bool> UpdateProficiency(Proficiency proficiency);
        Task<bool> DeleteProficiency(int proficiencyId);
        Task<bool> DeleteCharacterProficiency(int characterId, int proficiencyId);
    }
}