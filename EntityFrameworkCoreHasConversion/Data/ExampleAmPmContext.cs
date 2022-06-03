using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HasConversion.Classes;
using Microsoft.EntityFrameworkCore;

namespace HasConversion.Data
{
    public class ExampleAmPmContext : DbContext  
    {
        public DbSet<DateItem> DateItem { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder
                .Entity<DateItem>()
                .Property(e => e.WantToBeDateTime)
                .HasConversion<AmPmConverter>();

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseSqlServer(
                    "Server=(localdb)\\mssqllocaldb;Database=EF.Example2;Trusted_Connection=True");
    }

    public class DateItem
    {
        [Key]
        public int Id { get; set; }
        public string WantToBeDateTime { get; set; }
    }
}
