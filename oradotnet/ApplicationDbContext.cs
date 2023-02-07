using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace oradotnet
{
   
        public class ApplicationDbContext : DbContext
        {

        public DbSet<CM_SYSTEM_USERS> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseOracle(@"User Id=hr;Password=s;Data Source=localhost:1521/orcl");
            }
            
        }

       
    
}
