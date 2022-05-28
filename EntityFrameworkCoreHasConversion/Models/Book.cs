﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace HasConversion.Models
{
    public partial class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public BookCategory BookCategory { get; set; }
        public override string ToString() => Title;

    }

    public class BookVariant
    {
        [Key]
        public BookCategory BookCategoryId { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
        public override string ToString() => Name;

    }
}