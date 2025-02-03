using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using Backend.BusinessLayer.Abstract;
using Backend.DataAccessLayer.Abstract;
using Backend.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Backend.BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserManager(IRepository<User> userRepository)  // DI
        {
            _userRepository = userRepository;
        }

        public async Task<User> CreateUser(User user)
        {
            await _userRepository.Create(user);
            return user;
        }

        public async Task<List<User>> GetAllUsers() => await _userRepository.List.ToListAsync();
        public async Task<User> GetUserById(int id) => await _userRepository.List.FirstOrDefaultAsync(s => s.UserID == id) ?? throw new KeyNotFoundException($"User with ID {id} not found.");
        public async Task<User> GetUserByEmail(string email)
        {
            var existingEmail = await _userRepository.List.FirstOrDefaultAsync(s => s.Mail == email);

            if (existingEmail == null)
            {
                throw new KeyNotFoundException($"User with e-Mail {email} not found.");
            }

            return existingEmail;
        }


        public async Task<bool> UpdateUser(User user)
        {
            var existingUser = await _userRepository.List.FirstOrDefaultAsync(s => s.UserID == user.UserID);

            if (existingUser == null)
                return false;

            await _userRepository.Update(user);
            return true;
        }

        public async Task<bool> DeleteUser(int userId)
        {
            var existingUser = await _userRepository.List.FirstOrDefaultAsync(s => s.UserID == userId);

            if (existingUser == null)
                return false;

            await _userRepository.Delete(existingUser);
            return true;
        }
    }
}