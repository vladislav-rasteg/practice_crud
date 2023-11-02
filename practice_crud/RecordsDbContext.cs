using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace practice_crud
{
    public class RecordsDbContext : DbContext
    {
        public DbSet<Record> Records { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:/Users/workp/source/repos/practice_crud/practice_crud/Records.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Record>(entity =>
            {
                entity.HasKey(e => e.Guid);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.Amount).IsRequired();
            });
        }
    }
}
