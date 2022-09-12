using System;
// do not remove
using HasConversion.Classes;


namespace HasConversion
{
    partial class Program
    {
        /// <summary>
        /// Uncomment one at a time, run, go back and study code.
        /// In many cases excluding enum, transformations are in the database, not code.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            /*
             * Get descriptions for enum which can be used in a user interface
             */
            //GetEnumDescriptions();


            /*
             * Second attempt at using emun with navigation
             */
            //WineOperations.AddViewWines();

            /*
             * potpourri of standard converters
             */
            //SomeOperations.AddView();

            /*
             * String to list and back
             */
            //MappingListProperty.AddView();


            /*
             * Bool to string and back
             * Color and back
             */
            //PeopleOperations.AddViewPeople();

            /*
             * string to array and back
             */
            //AccountOperations.ViewAccounts();

            AmPmOperations.Example();
            Console.ReadLine();

        }


    }
}
