using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using HasConversion.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
//using Newtonsoft.Json;

namespace HasConversion.Data
{
    public class ListContext : DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder
                .Entity<EntityType>()
                .Property(e => e.ListProperty)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<List<int>>(v, (JsonSerializerOptions)null),
                    new ValueComparer<List<int>>(
                        (list1, list2) => list1.SequenceEqual(list2),
                        c => c.Aggregate(0, (a, v) => 
                            HashCode.Combine(a, v.GetHashCode())),
                        c => c.ToList()));
            
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseSqlServer(
                    "Server=(localdb)\\mssqllocaldb;Database=EF.MappingList;Trusted_Connection=True");
    }
}