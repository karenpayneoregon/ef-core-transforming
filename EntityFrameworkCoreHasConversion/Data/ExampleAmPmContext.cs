using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HasConversion.Classes;
using Microsoft.EntityFrameworkCore;

namespace HasConversion.Data
{
    /// <summary>
    /// Work in progress
    /// </summary>
    public class ExampleAmPmContext : DbContext  
    {
        public DbSet<DateItem> DateItem { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseSqlServer(
                    "Server=(localdb)\\mssqllocaldb;Database=EF.ExampleAmPm;Trusted_Connection=True");
    }

    public class DateItem
    {
        [Key]
        public int Id { get; set; }
        public string WantToBeDateTime { get; set; }
    }
}
