using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.EntityLayer.Concrete;

namespace Backend.BusinessLayer.Abstract
{
    public interface IClassService
    {
        void CreateClass(Class classEntity);
        Task<List<Class>> GetAllClasses();
        Task<Class> GetClassById(int id);
        void UpdateClass(Class classEntity);
        void DeleteClass(Class classEntity);

    }
}