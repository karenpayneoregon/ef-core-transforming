using System;
using System.Collections.Generic;
using System.Linq;
using HasConversion.Data;
using HasConversion.Models;
using Spectre.Console;
using static HasConversion.Models.BookVariantId;

namespace HasConversion.Classes
{
    public class BookOperations
    {
        public static void AddViewBooks(bool reCreate = false)
        {
            using var context = new BookContext();

            if (reCreate)
            {
                Helpers.CleanDatabase(context);
                AddRecords(context);
            }

            ShowRecords(context);

        }
        private static void ShowRecords(BookContext context)
        {
            var allBooksTable = new Table()
                .RoundedBorder()
                .AddColumn("[b]Id[/]")
                .AddColumn("[b]Title[/]")
                .AddColumn("[b]Category[/]")
                .Alignment(Justify.Center)
                .BorderColor(Color.LightSlateGrey)
                .Title("[yellow]All books[/]");

            var bookList = context.Book.ToList();


            foreach (var book in bookList)
            {
                allBooksTable.AddRow(
                    book.BookId.ToString(),
                    book.Title,
                    book.BookVariantId.ToString()
                    );
            }

            AnsiConsole.Write(allBooksTable);

            var adventureTable = new Table()
                .RoundedBorder()
                .AddColumn("[b]Id[/]")
                .AddColumn("[b]Title[/]")
                .AddColumn("[b]Category[/]")
                .Alignment(Justify.Center)
                .BorderColor(Color.LightSlateGrey)
                .Title("[yellow]Programming books[/]");


            var list = bookList
                .Where(books => books.BookVariantId == Programming)
                .ToList();

            foreach (var book in list)
            {

                adventureTable.AddRow(
                    book.BookId.ToString(),
                    book.Title,
                    book.BookVariantId.ToString());

            }

            AnsiConsole.Write(adventureTable);

        }

        private static void AddRecords(BookContext context)
        {

            List<Book> list = new()
            {
                new()
                {
                    BookVariantId = Adventure,
                    Title = "First book"
                },
                new()
                {
                    BookVariantId = Automobile,
                    Title = "Second book"
                },
                new()
                {
                    BookVariantId = Programming,
                    Title = "Third book"
                },
                new()
                {
                    BookVariantId = Adventure,
                    Title = "Fourth book"
                },
                new()
                {
                    BookVariantId = Adventure,
                    Title = "5th book"
                }
            };

            context.AddRange(list);

            try
            {
                context.SaveChanges();
            }
            catch (Exception e)
            {
                //TODO
            }
            Console.WriteLine($"Books saved {context.SaveChanges()}");

        }
    }
}
