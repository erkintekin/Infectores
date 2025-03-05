using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.EntityLayer.Concrete;
using Backend.DTOs;

namespace Backend.BusinessLayer.Abstract
{
    public interface IClassService
    {
        Task<ClassDTO> CreateClassAsync(ClassCreateDTO classDto);
        Task<List<ClassDTO>> GetAllClassesAsync();
        Task<ClassDTO> GetClassByIdAsync(int id);
        Task<ClassDTO> UpdateClassAsync(int id, ClassUpdateDTO classDto);
        Task<bool> DeleteClassAsync(int id);
    }
}