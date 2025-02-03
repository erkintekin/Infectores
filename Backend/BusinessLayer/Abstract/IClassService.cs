using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.EntityLayer.Concrete;

namespace Backend.BusinessLayer.Abstract
{
    public interface IClassService
    {
        Task<Class> CreateClass(Class classEntity);
        Task<List<Class>> GetAllClasses();
        Task<Class> GetClassById(int id);
        Task<bool> UpdateClass(Class classEntity);
        Task<bool> DeleteClass(int characterId);

    }
}