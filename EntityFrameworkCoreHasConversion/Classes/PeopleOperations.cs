using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using HasConversion.Data;
using HasConversion.Models;

namespace HasConversion.Classes
{
    public class PeopleOperations
    {
        /// <summary>
        /// Example for <see cref="BoolToStringConverter"/> where a bool is saved to a
        /// column of type nvarchar(3) and read back as a bool.
        /// </summary>
        public static void AddViewPeople()
        {
            using var context = new PeopleContext();
            
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Add(new Person() { FirstName = "Jim", LastName = "Jacobe", IsFriend = true, 
                DateTime = new DateTime(2022, 5,5)});

            context.Add(new Person() { FirstName = "Bob", LastName = "Smith", IsFriend = false });

            context.Add(new Person() { FirstName = "Karen", LastName = "Payne", IsFriend = true });

            context.SaveChanges();
        }
    }
}
