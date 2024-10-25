using HasConversion.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HasConversion.Data
{
    public class SomeContext : DbContext
    {
        public DbSet<SomeEntity>? SomeEntities { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EF.SomeDatabase;Trusted_Connection=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //var uppercaseConverter = new ValueConverter<string, string>(
            //    v => v,
            //    v => v.ToUpper());

            //modelBuilder.Entity<SomeEntity>()
            //    .Property(entity => entity.ShortName)
            //    .HasConversion(new ValueConverter<string, string>(
            //        toValue => toValue.ToUpper(),
            //        fromValue => fromValue));

            //modelBuilder.Entity<SomeEntity>()
            //    .Property(entity => entity.ShortName)
            //    .HasColumnName("short_name");


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

            modelBuilder.Entity<SomeEntity>()
                .Property(entity => entity.SomeAddress)
                .HasConversion<string>();

            var dollarsConverter = new ValueConverter<Dollars, decimal>(
                dollars => dollars.Amount,
                dec => new Dollars(dec),
                new ConverterMappingHints(precision: 16, scale: 2));


            modelBuilder.Entity<SomeEntity>()
                .Property(e => e.SomePrice)
                .HasConversion(dollarsConverter);

        }
    }
}
