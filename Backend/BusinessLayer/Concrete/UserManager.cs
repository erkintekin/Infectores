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

        public void CreateUser(User user)
        {
            _userRepository.Create(user);
        }

        public async Task<List<User>> GetAllUsers() => await _userRepository.List.ToListAsync();
        public async Task<User> GetUserById(int id) => await _userRepository.List.FirstOrDefaultAsync(s => s.UserID == id) ?? throw new KeyNotFoundException($"User with ID {id} not found.");
        public async Task<User> GetUserByEmail(string email) => await _userRepository.List.FirstOrDefaultAsync(s => s.Mail == email) ?? throw new KeyNotFoundException($"User with e-Mail {email} not found.");

        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
        }

        public void DeleteUser(User user)
        {
            _userRepository.Delete(user);
        }
    }
}