﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EF.ValidationResultExample.Attributes
{
    public class UpperCaseAttribute : ValidationAttribute
    {
        public UpperCaseAttribute() : base("Must be upper case.")
        {

        }

        public override bool IsValid(object value)
        {
            if (value is string checkValue)
            {
                return checkValue.All(char.IsUpper);
            }

            return false;
        }
    }
}