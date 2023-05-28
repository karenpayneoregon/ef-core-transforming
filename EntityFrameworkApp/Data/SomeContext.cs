using ConfigurationLibrary.Classes;
using EntityFrameworkApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
#pragma warning disable CS8618


namespace EntityFrameworkApp.Data;

public partial class SomeContext : DbContext
{
    /// <summary>
    /// Options to connect or connect with logging
    /// </summary>
    private readonly ConnectionType _connectionType;

    /// <summary>
    /// Default to no logging connection
    /// </summary>
    public SomeContext()
    {
        _connectionType = ConnectionType.Standard;
    }

    /// <summary>
    /// Selective connection
    /// </summary>
    /// <param name="connectionType"></param>
    public SomeContext(ConnectionType connectionType)
    {
        _connectionType = connectionType;
    }

    public DbSet<SomeEntity> SomeEntities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (_connectionType == ConnectionType.Standard)
        {
            optionsBuilder.UseSqlServer(ConfigurationHelper.ConnectionString());
        }
        else
        {
            StandardLogging(optionsBuilder).UseSqlServer(ConfigurationHelper.ConnectionString());
        }
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