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
        Task<ClassDTO> CreateClassAsync(ClassDTO classDto);
        Task<List<ClassDTO>> GetAllClassesAsync();
        Task<ClassDTO> GetClassByIdAsync(int id);
        Task<bool> UpdateClassAsync(ClassDTO classDto);
        Task<bool> DeleteClassAsync(int classId);
    }
}