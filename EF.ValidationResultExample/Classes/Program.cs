using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using EF.ValidationResultExample.Classes;
using EF.ValidationResultExample.Models;
using Spectre.Console;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;


// ReSharper disable once CheckNamespace
namespace EF.ValidationResultExample
{
    partial class Program
    {
        private static void BookIsValid()
        {
            Book book = new Book
            {
                Title = "Learning to code in C#",
                Author = "Karen Payne",
                ISBN = "978-92-95055-02-5"
            };

            AnsiConsole.MarkupLine($"[b][cyan]{nameof(BookIsValid)}[/][/]");
            ValidationContext validationContext;
            IEnumerable<ValidationResult> validationResults;


            validationContext = new ValidationContext(book);
            validationResults = book.Validate(validationContext);

            if (validationResults.IsValid())
            {
                AnsiConsole.MarkupLine("[b][yellow]Valid[/][/] book");
            }
            else
            {
                AnsiConsole.MarkupLine("[b][red]Failed[/][/] validation");
                foreach (var result in validationResults)
                {
                    Console.WriteLine(result.ErrorMessage);
                }
            }

        }

        private static void BookMissingAuthor()
        {

            AnsiConsole.MarkupLine($"[b][cyan]{nameof(BookMissingAuthor)}[/][/]");

            IEnumerable<ValidationResult> validationResults;

            Book book = new Book
            {
                Title = "Learning to code in C#",
                ISBN = "978-92-95055-02-5"
            };

            var validationContext = new ValidationContext(book);
            validationResults = book.Validate(validationContext);

            if (validationResults.IsValid())
            {
                AnsiConsole.MarkupLine("[b][yellow]Valid[/][/] book");
            }
            else
            {
                AnsiConsole.MarkupLine("[b][red]Failed[/][/] validation");
                foreach (var result in validationResults)
                {
                    Console.WriteLine($"{result.ErrorMessage,25}");
                }
            }
        }

        private static Book BookMissingTitleAndAuthor()
        {
            AnsiConsole.MarkupLine($"[b][cyan]{nameof(BookMissingTitleAndAuthor)}[/][/]");

            Book book = new();

            ValidationContext validationContext = new ValidationContext(book);
            IEnumerable<ValidationResult> validationResults = book.Validate(validationContext);

            if (validationResults.IsValid())
            {
                AnsiConsole.MarkupLine("[b][yellow]Valid[/][/] book");
            }
            else
            {
                AnsiConsole.MarkupLine("[b][red]Failed[/][/] validation");
                foreach (var result in validationResults)
                {
                    Console.WriteLine($"{result.ErrorMessage,25}");
                }
            }

            return book;
        }

        [ModuleInitializer]
        public static void Init()
        {
            Console.Title = "Single validation code sample";
        }
    }
}





