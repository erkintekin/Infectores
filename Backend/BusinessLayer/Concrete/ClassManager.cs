using AutoMapper;
using Backend.BusinessLayer.Abstract;
using Backend.DataAccessLayer.Abstract;
using Backend.DTOs;
using Backend.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Backend.BusinessLayer.Concrete
{
    public class ClassManager : IClassService
    {
        private readonly IRepository<Class> _classRepository;
        private readonly IMapper _mapper;

        public ClassManager(IRepository<Class> classRepository, IMapper mapper)
        {
            _classRepository = classRepository;
            _mapper = mapper;
        }

        public async Task<ClassDTO> CreateClassAsync(ClassDTO classDto)
        {
            var classEntity = _mapper.Map<Class>(classDto);
            await _classRepository.Create(classEntity);
            return _mapper.Map<ClassDTO>(classEntity);
        }

        public async Task<List<ClassDTO>> GetAllClassesAsync()
        {
            var classes = await _classRepository.List.ToListAsync();
            return _mapper.Map<List<ClassDTO>>(classes);
        }

        public async Task<ClassDTO> GetClassByIdAsync(int id)
        {
            var classEntity = await _classRepository.List.FirstOrDefaultAsync(s => s.ClassID == id)
                ?? throw new KeyNotFoundException($"Class with ID: `{id}` not found.");
            return _mapper.Map<ClassDTO>(classEntity);
        }

        public async Task<bool> UpdateClassAsync(ClassDTO classDto)
        {
            var classEntity = _mapper.Map<Class>(classDto);
            _ = await _classRepository.List.FirstOrDefaultAsync(s => s.ClassID == classEntity.ClassID)
                ?? throw new KeyNotFoundException($"Class with ID: `{classEntity.ClassID}` not found.");

            await _classRepository.Update(classEntity);
            return true;
        }

        public async Task<bool> DeleteClassAsync(int classId)
        {
            var classEntity = await _classRepository.List.FirstOrDefaultAsync(s => s.ClassID == classId)
                ?? throw new KeyNotFoundException($"Class with ID: `{classId}` not found.");

            await _classRepository.Delete(classEntity);
            return true;
        }
    }
}