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

        public void CreateClass(Class classEntity)
        {
            _classRepository.Create(classEntity);
        }

        public async Task<List<Class>> GetAllClasses() => await _classRepository.List.ToListAsync();
        public async Task<Class> GetClassById(int id) => await _classRepository.List.FirstOrDefaultAsync(s => s.ClassID == id);

        public void UpdateClass(Class classEntity)
        {
            _classRepository.Update(classEntity);
        }

        public void DeleteClass(Class classEntity)
        {
            _classRepository.Delete(classEntity);
        }
    }
}