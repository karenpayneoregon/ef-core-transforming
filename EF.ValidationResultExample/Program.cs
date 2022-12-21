using System.ComponentModel.DataAnnotations;
using EF.ValidationResultExample.Classes;
using EF.ValidationResultExample.Data;
using EF.ValidationResultExample.Models;
using Spectre.Console;
using static System.Console;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;

namespace EF.ValidationResultExample;

partial class Program
{
    static void Main(string[] args)
    {
        AnsiConsole.Write(new Rule($"[yellow]{Title}[/]").LeftAligned().RuleStyle("grey"));
        AnsiConsole.WriteLine();

        using var context = new BookContext();
        //IEnumerable<ValidationResult> validationResults;
        Book book = BookMissingTitleAndAuthor();

        AnsiConsole.WriteLine();

        BookMissingAuthor();

        AnsiConsole.WriteLine();

        BookIsValid();
            
        ReadLine();

    }

    private static void PlayWithBook()
    {
        Book testBook = new ();
        var validationContext = new ValidationContext(testBook);
        var validationResults = testBook.Validate(validationContext);
        WriteLine(validationResults.IsValid());
    }
}