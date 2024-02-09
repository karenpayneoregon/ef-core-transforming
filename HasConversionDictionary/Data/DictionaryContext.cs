﻿
// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using HasConversionDictionary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

namespace HasConversionDictionary.Data;

public partial class DictionaryContext : DbContext
{
    public DictionaryContext()
    {
    }

    public DictionaryContext(DbContextOptions<DictionaryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Dictionary> Dictionary { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=HasConversions;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasSequence<int>("seq_test").HasMin(1L);


        modelBuilder.Entity<Dictionary>().OwnsOne(
            owner => owner.Data, ownedNavigationBuilder =>
            {
                ownedNavigationBuilder.ToJson();
            });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}