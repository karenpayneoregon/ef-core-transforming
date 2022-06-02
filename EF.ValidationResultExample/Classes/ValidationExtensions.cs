using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EF.ValidationResultExample.Classes
{
    public static class ValidationExtensions
    {
        /// <summary>
        /// Determine if model instance is valid
        /// </summary>
        public static bool IsValid(this IEnumerable<ValidationResult> sender)
            => !sender.Any();
    }
}