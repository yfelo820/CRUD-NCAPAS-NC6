using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
    public interface IEntityDB
    {
        public DbSet<User> Users { get; set; }
        public Task SaveChanges();
    }
}
