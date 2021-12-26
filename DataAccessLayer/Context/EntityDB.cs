using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context 
{
    public class EntityDB : DbContext, IEntityDB
    {
        public EntityDB(DbContextOptions<EntityDB> options):base(options) { }
        public DbSet<User> Users { get; set; }

        async Task IEntityDB.SaveChanges()
        {
            await this.SaveChangesAsync();
        }
    }
}
