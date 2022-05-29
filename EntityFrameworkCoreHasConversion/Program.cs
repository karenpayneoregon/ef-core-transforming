using System;
using System.Linq;
using System.Runtime.InteropServices;
using HasConversion.Classes;
using HasConversion.Data;

namespace HasConversion
{
    partial class Program
    {
        static void Main(string[] args)
        {
            //WineOperations.AddViewWines();
            //BookOperations.AddViewBooks();
            //AccountOperations.ViewAccounts();
            MappingListProperty.AddView();
            //PeopleOperations.AddViewPeople();

            Console.ReadLine();
        }


    }
}
