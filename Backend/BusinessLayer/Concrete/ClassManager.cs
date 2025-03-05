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

        public async Task<ClassDTO> CreateClassAsync(ClassCreateDTO classDto)
        {
            var exists = await _classRepository.AnyAsync(c => c.Name.ToLower() == classDto.Name.ToLower());
            if (exists)
            {
                throw new InvalidOperationException($"Class with name '{classDto.Name}' already exists.");
            }

            var classEntity = _mapper.Map<Class>(classDto);
            await _classRepository.AddAsync(classEntity);
            await _classRepository.SaveChangesAsync();

            return await GetClassByIdAsync(classEntity.ClassID);
        }

        public async Task<List<ClassDTO>> GetAllClassesAsync()
        {
            var classes = await _classRepository.GetAllAsync();
            return _mapper.Map<List<ClassDTO>>(classes);
        }

        public async Task<ClassDTO> GetClassByIdAsync(int id)
        {
            var classEntity = await _classRepository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException($"Class with ID {id} not found.");
            return _mapper.Map<ClassDTO>(classEntity);
        }

        public async Task<ClassDTO> UpdateClassAsync(int id, ClassUpdateDTO classDto)
        {
            var classEntity = await _classRepository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException($"Class with ID {id} not found.");

            if (classDto.Name != classEntity.Name)
            {
                var exists = await _classRepository.AnyAsync(c => c.Name.ToLower() == classDto.Name.ToLower());
                if (exists)
                {
                    throw new InvalidOperationException($"Class with name '{classDto.Name}' already exists.");
                }
            }

            _mapper.Map(classDto, classEntity);
            await _classRepository.UpdateAsync(classEntity);
            await _classRepository.SaveChangesAsync();

            return await GetClassByIdAsync(id);
        }

        public async Task<bool> DeleteClassAsync(int id)
        {
            var classEntity = await _classRepository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException($"Class with ID {id} not found.");

            await _classRepository.DeleteAsync(classEntity);
            await _classRepository.SaveChangesAsync();
            return true;
        }
    }
}