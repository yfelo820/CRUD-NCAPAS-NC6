using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLogic.Interfaces
{
    public interface IUserService
    {
        public Task<User> AddUser(User user);
        public Task<List<User>> GetAllUsers();
        public Task<User> GetUserById(int Id);
        public Task<User> UpdateUser(User user);
        public Task<User> DeleteUser(int Id);
    }
}
