﻿
// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using ConfigurationLibrary.Classes;
using KP_ConsoleAppNet6.Classes;
using KP_ConsoleAppNet6.Data.Configurations;
using KP_ConsoleAppNet6.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;

#nullable disable

namespace KP_ConsoleAppNet6.Data
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Person> Person { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=HasConversions;Integrated Security=True");
                optionsBuilder.UseSqlServer(ConfigurationHelper.ConnectionString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Configurations.PersonConfiguration());

            modelBuilder.HasSequence<int>("seq_test").HasMin(1);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");
            base.ConfigureConventions(builder);
        }
    }
}
