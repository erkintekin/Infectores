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
    public class ClassManager : IClassService
    {
        private readonly IRepository<Class> _classRepository;

        public ClassManager(IRepository<Class> classRepository)
        {
            _classRepository = classRepository;
        }

        public async Task<Class> CreateClass(Class classEntity)
        {
            await _classRepository.Create(classEntity);
            return classEntity;
        }

        public async Task<List<Class>> GetAllClasses() => await _classRepository.List.ToListAsync();
        public async Task<Class> GetClassById(int id) => await _classRepository.List.FirstOrDefaultAsync(s => s.ClassID == id);

        public async Task<bool> UpdateClass(Class classEntity)
        {
            var existingClass = await _classRepository.List.FirstOrDefaultAsync(s => s.ClassID == classEntity.ClassID);

            if (existingClass == null)
                return false;

            await _classRepository.Update(classEntity);
            return true;
        }

        public async Task<bool> DeleteClass(int classId)
        {
            var existingClass = await _classRepository.List.FirstOrDefaultAsync(s => s.ClassID == classId);

            if (existingClass == null)
                return false;

            await _classRepository.Delete(existingClass);
            return true;
        }
    }
}