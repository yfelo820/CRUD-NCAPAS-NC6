using BusinesLogic.Interfaces;
using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using DataAccessLayer.Pagination;
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

        public async Task<Pagination<User>> GetUserPaginations(int pageSize, int page)
        {
            var elementsQuantity = pageSize * page;

            var elements = await _entityDBContext.Users.Take(elementsQuantity).ToListAsync();

            if (elements.Count > elementsQuantity - pageSize)
            {
                elements.RemoveRange(0, page * pageSize - pageSize);

                return new Pagination<User>
                {
                    CurrentPage = page,
                    PageSize = pageSize,
                    HasAnotherPage = (await _entityDBContext.Users.Take(elementsQuantity + 1).ToListAsync()).Count == elementsQuantity + 1,
                    Elements = elements
                };
            }

            throw new Exception("Page not Found");            
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
