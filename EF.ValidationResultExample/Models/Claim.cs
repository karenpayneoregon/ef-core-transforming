﻿using System.ComponentModel.DataAnnotations;

namespace EF.ValidationResultExample.Models;

class Claim : IValidatableObject
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string SSN { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        throw new ClaimsException("");
    }
}


public class ClaimsException : Exception
{
    public ClaimsException()
    {

    }

    public ClaimsException(string message) : base(message)
    {

    }

    public ClaimsException(string message, Exception inner) : base(message, inner)
    {
    }
}