using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.EntityLayer.Concrete;

namespace Backend.BusinessLayer.Abstract
{
    public interface IUserService
    {
        void CreateUser(User user);
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> GetUserByEmail(string email);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}