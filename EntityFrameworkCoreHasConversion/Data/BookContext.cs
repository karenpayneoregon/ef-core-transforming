﻿
// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Linq;
using HasConversion.Models;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HasConversion.Data
{
    public partial class BookContext : DbContext
    {
        public BookContext()
        {
        }

        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Book { get; set; }
        public DbSet<BookVariant> BookVariants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // for this demo we are not concerned about security
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=HasConversions;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");


            modelBuilder
                .Entity<Book>()
                .Property(e => e.BookCategory)
                .HasConversion<int>();

            modelBuilder
                .Entity<BookVariant>().HasData(
                    Enum.GetValues(typeof(BookCategory))
                        .Cast<BookCategory>()
                        .Select(e => new BookVariant()
                        {
                            BookCategoryId = e,
                            Name = e.ToString()
                        })
                );

            modelBuilder.HasSequence<int>("seq_test").HasMin(1);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}