using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace EF.ValidationResultExample.Attributes;

/// <summary>
/// Work in progress, there are different types to consider, the following
/// is only considering one format/type.
/// </summary>
public class ISBNAttribute : RegularExpressionAttribute
{
    public ISBNAttribute() : base(
        "^(?:ISBN(?:-13)?:?\\ )?(?=[0-9]{13}$|(?=(?:[0-9]+[-\\ ]){4})[-\\ 0-9]{17}$)97[89][-\\ ]?[0-9]{1,5}[-\\ ]?[0-9]+[-\\ ]?[0-9]+[-\\ ]?[0-9]$")
    {
        //ErrorMessageResourceType = typeof(ValidationMessages);
        ErrorMessageResourceName = "TODO";
        ErrorMessageResourceName = "ISBN";
    }

        
    public override bool IsValid(object value)
    {
        if (value is not string isbn)
        {
            return false;
        }

        if (string.IsNullOrWhiteSpace(isbn))
        {
            return false;
        }

        return new Regex(@"^(?:ISBN(?:-13)?:?\\ )?(?=[0-9]{13}$|(?=(?:[0-9]+[-\\ ]){4})[-\\ 0-9]{17}$)97[89][-\\ ]?[0-9]{1,5}[-\\ ]?[0-9]+[-\\ ]?[0-9]+[-\\ ]?[0-9]$")
            .IsMatch(isbn);

    }
}