using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.EntityLayer.Concrete;
using Backend.DTOs;

namespace Backend.BusinessLayer.Abstract
{
    public interface IUserService
    {
        Task<UserDTO> CreateUserAsync(UserDTO userDto);
        Task<List<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int id);
        Task<UserDTO> GetUserByEmailAsync(string email);
        Task<bool> UpdateUserAsync(UserDTO userDto);
        Task<bool> DeleteUserAsync(int userId);
    }
}