using System;
using System.Drawing;
using HasConversion.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HasConversion.Data
{
    public class PeopleContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EF.Friends;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Person>()
                .Property(person => person.IsFriend)
                .HasConversion(new BoolToStringConverter("No", "Yes"));

            modelBuilder.Entity<Person>()
                .Property(person => person.Color)
                .HasConversion(
                    color => color.Name, 
                    value => Color.FromName(value));


            var dateTimeConverter = new ValueConverter<DateTime, DateTime>(
                datetime => datetime, 
                dateTime => 
                    DateTime.SpecifyKind(dateTime, DateTimeKind.Utc));


            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
                    {
                        property.SetValueConverter(dateTimeConverter);
                    }
                }
            }

        }
    }
}
