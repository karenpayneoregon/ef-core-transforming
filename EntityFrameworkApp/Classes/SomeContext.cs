using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

// ReSharper disable once CheckNamespace
namespace EntityFrameworkApp.Data
{
    public partial class SomeContext
    {

        /// <summary>
        /// Default logging to output window
        /// </summary>
        public static DbContextOptionsBuilder StandardLogging(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging().LogTo(message => Debug.WriteLine(message));
            return optionsBuilder;
        }
    }
}
