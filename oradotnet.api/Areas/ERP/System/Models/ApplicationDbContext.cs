using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using oradotnet.api.Areas.ERP.System.Models;

namespace oradotnet.api.Areas.ERP.System.Models
{
    public class ApplicationDbContext : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle(@"User Id=hr;Password=s;Data Source=localhost:1521/orcl");
        }
        public DbSet<CM_SYSTEM_USERS> Users { get; set; }
    }
}
