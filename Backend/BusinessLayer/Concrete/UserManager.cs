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

        public async Task<UserDTO> CreateUserAsync(UserCreateDTO userDto)
        {
            var exists = await _userRepository.AnyAsync(u => u.Email.ToLower() == userDto.Email.ToLower());
            if (exists)
            {
                throw new InvalidOperationException($"User with email '{userDto.Email}' already exists.");
            }

            var user = _mapper.Map<User>(userDto);
            // Burada şifre hash'leme işlemi yapılmalı
            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<List<UserDTO>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<List<UserDTO>>(users);
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException($"User with ID {id} not found.");
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetFirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower())
                ?? throw new KeyNotFoundException($"User with email {email} not found.");
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> UpdateUserAsync(int id, UserUpdateDTO userDto)
        {
            var user = await _userRepository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException($"User with ID {id} not found.");

            if (userDto.Email != user.Email)
            {
                var exists = await _userRepository.AnyAsync(u => u.Email.ToLower() == userDto.Email.ToLower());
                if (exists)
                {
                    throw new InvalidOperationException($"User with email '{userDto.Email}' already exists.");
                }
            }

            // Burada şifre doğrulama ve yeni şifre hash'leme işlemleri yapılmalı
            _mapper.Map(userDto, user);
            await _userRepository.UpdateAsync(user);
            await _userRepository.SaveChangesAsync();

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException($"User with ID {id} not found.");

            await _userRepository.DeleteAsync(user);
            await _userRepository.SaveChangesAsync();
            return true;
        }
    }
}