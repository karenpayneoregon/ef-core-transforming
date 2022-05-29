using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HasConversion.Data;
using HasConversion.Models;
using Spectre.Console;

namespace HasConversion.Classes
{
    public class BookOperations
    {
        public static void AddViewBooks(bool reCreate = false)
        {
            using var context = new BookContext();

            if (reCreate)
            {
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
                    Enum.GetName(typeof(BookCategory), book.BookCategory)!
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
                .Title("[yellow]Adventure books[/]");


            var list = bookList.Where(books => books.BookCategory == BookCategory.Adventure).ToList();

            foreach (var book in list)
            {
                adventureTable.AddRow(
                    book.BookId.ToString(),
                    book.Title,
                    book.BookCategory.ToString());
            }

            AnsiConsole.Write(adventureTable);
        }

        private static void AddRecords(BookContext context)
        {
            if (context.Book.ToList().Count == 0)
            {
                List<Book> list = new()
                {
                    new() { BookCategory = BookCategory.Adventure, Title = "First book" },
                    new() { BookCategory = BookCategory.Automobile, Title = "Second book" },
                    new() { BookCategory = BookCategory.Adventure, Title = "Third book" }
                };

                context.AddRange(list);
                Console.WriteLine($"Books saved {context.SaveChanges()}");
            }
        }
    }
}
