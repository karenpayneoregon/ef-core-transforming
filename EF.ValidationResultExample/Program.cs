using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EF.ValidationResultExample.Data;
using EF.ValidationResultExample.Models;
using Spectre.Console;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;

namespace EF.ValidationResultExample
{
    partial class Program
    {
        static void Main(string[] args)
        {
            AnsiConsole.Write(new Rule($"[yellow]{Console.Title}[/]").LeftAligned().RuleStyle("grey"));
            AnsiConsole.WriteLine();

            using var context = new BookContext();
            IEnumerable<ValidationResult> validationResults;
            Book book = BookMissingTitleAndAuthor();

            AnsiConsole.WriteLine();

            ValidationContext validationContext;
            BookMissingAuthor(book);

            AnsiConsole.WriteLine();

            BookIsValid(book);


            Console.ReadLine();
        }


    }
}
