using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HasConversion.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HasConversion.Data
{
    public class SomeContext : DbContext
    {
        public DbSet<SomeEntity> SomeEntities { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EF.SomeDatabase;Trusted_Connection=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SomeEntity>()
                .Property(entity => entity.SomeDateTime)
                .HasConversion(new DateTimeToStringConverter());

            modelBuilder.Entity<SomeEntity>()
                .Property(entity => entity.SomeGuid)
                .HasConversion(new GuidToStringConverter());

            modelBuilder.Entity<SomeEntity>()
                .Property(entity => entity.SomeInt)
                .HasConversion(new NumberToStringConverter<int>());

            modelBuilder.Entity<SomeEntity>()
                .Property(entity => entity.SomeDouble)
                .HasConversion(new NumberToStringConverter<double>());

            modelBuilder.Entity<SomeEntity>()
                .Property(entity => entity.SomeEnum)
                .HasConversion(new EnumToStringConverter<SomeEnum>());

            modelBuilder.Entity<SomeEntity>()
                .Property(entity => entity.SomeFlagsEnum)
                .HasConversion(new EnumToStringConverter<SomeFlagsEnum>());
        }
    }
}
