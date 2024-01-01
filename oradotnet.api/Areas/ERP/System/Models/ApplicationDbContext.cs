using Microsoft.EntityFrameworkCore;
using System.IO;

namespace oradotnet.api.Areas.ERP.System.Models
{
    public class ApplicationDbContext : DbContext
    {


        public DbSet<Category> Categories { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure foreign key relationship between Project and Category
            modelBuilder.Entity<Project>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Projects)
                .HasForeignKey(p => p.CategoryId)
                .IsRequired();
            modelBuilder.Entity<CM_SYSTEM_USERS>().HasNoKey();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //   optionsBuilder.UseOracle(@"User Id=hr;Password=s;Data Source=localhost:1521/orcl");
            optionsBuilder.UseSqlite("Data Source='" + Path.Combine(Directory.GetCurrentDirectory(), @"portfolio.db") + "' ");
        }
        public DbSet<CM_SYSTEM_USERS> CM_SYSTEM_USERS { get; set; }
    }
}
