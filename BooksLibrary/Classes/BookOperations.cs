using System;
using System.Drawing;
using System.Linq;
using BooksLibrary.Data;
using BooksLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BooksLibrary.Classes
{
    public class BookOperations
    {
        /// <summary>
        /// If database does not exists than pass true to this method
        /// to create and populate with several records.
        ///
        /// Otherwise passing false to view records in database
        /// </summary>
        /// <param name="reCreate"></param>
        public static void AddViewWines(bool reCreate = false)
        {
            using var context = new BookContext();
            
            if (reCreate)
            {

                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Books.Add(new Book
                {
                    Name = "Veuve Clicquot Rose",
                    BookVariantId = BookVariantId.Sports
                });

                context.Books.Add(new Book
                {
                    Name = "Whispering Angel Rose",
                    BookVariantId = BookVariantId.Sports
                });

                context.Books.Add(new Book
                {
                    Name = "Pinot Grigio",
                    BookVariantId = BookVariantId.Sports
                });

                context.SaveChanges();

            }

            /*
             * Get all wines
             */
            var allWines = context
                .Books
                .Include(item => item.BookVariant)
                .ToList();





            var roseWines = context
                .Books
                .Where(wine => wine.BookVariantId == BookVariantId.Sports)
                .ToList();



            var redWines = context
                .Books
                .Where(wine => wine.BookVariantId == BookVariantId.SpaceTravel)
                .ToList();

            Console.WriteLine();

        }



    }
}
