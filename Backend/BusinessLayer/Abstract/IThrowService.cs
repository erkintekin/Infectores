using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.EntityLayer.Concrete;

namespace Backend.BusinessLayer.Abstract
{
    public interface IThrowService
    {
        Task<Throw> CreateThrow(Throw throwEntity);
        Task<List<Throw>> GetAllThrows();
        Task<Throw> GetThrowById(int sikllId);
        Task<bool> UpdateThrow(Throw throwEntity);
        Task<bool> DeleteThrow(int throwId);
        Task<List<CharacterThrow>> GetAllCharacterThrows(int characterId);
        Task<bool> UpdateCharacterThrow(int characterId, int throwId, int newValue);
        Task<bool> DeleteCharacterThrow(int characterId, int throwId);
    }
}