using System.Diagnostics;
using EntityCoreFileLogger;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ValueConversionsEncryptProperty.Models;

using static ConfigurationLibrary.Classes.ConfigurationHelper;
using static ValueConversionsEncryptProperty.Classes.SecurityHelpers;

namespace ValueConversionsEncryptProperty.Data
{
    public class SampleDbContext : DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region ConfigureEncryptPropertyValues
            modelBuilder.Entity<User>().Property(e => e.Password).HasConversion(
                v => BC.HashPassword(v),
                v => v);
            #endregion
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .LogTo(new DbContextToFileLogger().Log,
                    [DbLoggerCategory.Database.Command.Name],
                    LogLevel.Information)
                .UseSqlServer(ConnectionString())
                .EnableSensitiveDataLogging();
    }
}
