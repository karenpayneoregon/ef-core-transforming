﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EF.ValidationResultExample.Models
{
    public partial class Book : IValidatableObject
    {
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        public BookCategory BookCategory { get; set; }
        public override string ToString() => Title;

        /// <summary>
        /// Place code here to validate against data annotations
        /// </summary>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Title))
            {
                yield return new ValidationResult(
                    $"{nameof(Title)} cannot be empty",
                    new[] { nameof(Title) });
            }

            if (string.IsNullOrWhiteSpace(Author))
            {
                yield return new ValidationResult(
                    $"{nameof(Author)} cannot be empty",
                    new[] { nameof(Author) });
            }
        }
    }
}