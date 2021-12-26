using BusinesLogic.Interfaces;
using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IEntityDB _entityDBContext;

        public UserService(IEntityDB entityDBContext)
        {
             _entityDBContext = entityDBContext;
        }

        public async Task<User> AddUser(User user)
        {
            _entityDBContext.Users.Add(user);
            await _entityDBContext.SaveChanges();
            return user;
        }

        public async Task<User> DeleteUser(int Id)
        {
            var exist = await _entityDBContext.Users.Where(b => b.Id == Id).ToListAsync();

            if (!exist.Any()) throw new NotImplementedException("User not Found");

                  _entityDBContext.Users.Remove(exist[0]);
            await _entityDBContext.SaveChanges();
            return exist[0];            
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _entityDBContext.Users.ToListAsync(); 
        }

        public async Task<User> GetUserById(int Id)
        {
            var exist = await _entityDBContext.Users.Where(b => b.Id == Id).ToListAsync();

            if (!exist.Any()) throw new NotImplementedException("User not Found");

            return exist[0];
        }

        public async Task<User> UpdateUser(User user)
        {
            var exist = await _entityDBContext.Users.Where(b => b.Id == user.Id).ToListAsync();

            if (!exist.Any()) throw new NotImplementedException("User not Found");

            exist[0].userName = user.userName;
            exist[0].password = user.password;
            exist[0].fullName = user.fullName;

                  _entityDBContext.Users.Update(exist[0]);
            await _entityDBContext.SaveChanges();

            return user;
        }
    }
}
