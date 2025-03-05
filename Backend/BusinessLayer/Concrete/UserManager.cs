using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Backend.BusinessLayer.Abstract;
using Backend.DataAccessLayer.Abstract;
using Backend.DTOs;
using Backend.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Backend.BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserManager(IRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO> CreateUserAsync(UserDTO userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userRepository.Create(user);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<List<UserDTO>> GetAllUsersAsync()
        {
            var users = await _userRepository.List.ToListAsync();
            return _mapper.Map<List<UserDTO>>(users);
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.List.FirstOrDefaultAsync(s => s.UserID == id)
                ?? throw new KeyNotFoundException($"User with ID {id} not found.");
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.List.FirstOrDefaultAsync(s => s.Mail == email)
                ?? throw new KeyNotFoundException($"User with e-Mail {email} not found.");
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<bool> UpdateUserAsync(UserDTO userDto)
        {
            var user = _mapper.Map<User>(userDto);
            _ = await _userRepository.List.FirstOrDefaultAsync(s => s.UserID == user.UserID)
                ?? throw new KeyNotFoundException($"User with ID {user.UserID} not found.");

            await _userRepository.Update(user);
            return true;
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var user = await _userRepository.List.FirstOrDefaultAsync(s => s.UserID == userId)
                ?? throw new KeyNotFoundException($"User with ID {userId} not found.");

            await _userRepository.Delete(user);
            return true;
        }
    }
}