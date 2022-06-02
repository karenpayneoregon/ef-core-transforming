using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HasConversion.Data
{
    public class ExampleContext : DbContext
    {
        public DbSet<Person1> People { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Person1>()
                .Property(p => p.Address)
                .HasConversion<AddressConverter>();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseSqlServer(
                    "Server=(localdb)\\mssqllocaldb;Database=EF.Example1;Trusted_Connection=True");
    }
    public class Person1
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
    }
    public class Address
    {
        public string Country { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
    }
    public class AddressConverter : ValueConverter<Address, string>
    {
        public AddressConverter() : base(
                v => JsonSerializer.Serialize(v, null),
                v => JsonSerializer.Deserialize<Address>(v, (JsonSerializerOptions)null))
        {
        }
    }

}

