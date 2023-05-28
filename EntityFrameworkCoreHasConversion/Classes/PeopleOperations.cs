using System;
using System.Drawing;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using HasConversion.Data;
using Person = HasConversion.Models.Person;

namespace HasConversion.Classes;

public class PeopleOperations
{
    /// <summary>
    /// Example for <see cref="BoolToStringConverter"/> where a bool is saved to a
    /// column of type nvarchar(3) and read back as a bool.
    /// </summary>
    public static void AddViewPeople()
    {
        using var context = new PeopleContext();

        Helpers.CleanDatabase(context);

        context.Add(new Person() { FirstName = "Jim", LastName = "Jacobe", IsFriend = true, 
            DateTime = new DateTime(2022, 5,5), 
            Color = Color.AliceBlue});

        context.Add(new Person() { FirstName = "Bob", LastName = "Smith", IsFriend = false , 
            Color = Color.Coral});

        context.Add(new Person()
        {
            FirstName = "Karen", LastName = "Payne", IsFriend = true,
            Color = Color.Red
        });

        context.SaveChanges();

        ReadPeople();

    }

    private static void ReadPeople()
    {
        using var context = new PeopleContext();
        var people = context.People.ToList();
        foreach (var person in people)
        {
            Console.WriteLine($"{person.Id,-3}{person.Color.Name,-12}{person.IsFriend.ToYesNo(),-5}{person.LastName}");
        }
    }
}