using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HasConversion.Data;
using HasConversion.Models;
using Microsoft.Extensions.Logging;
using Spectre.Console;

namespace HasConversion.Classes
{
    class MappingListProperty
    {
        public static void Run(bool reCreate = false)
        {
            AnsiConsole.MarkupLine("[b][white]Value conversions[/][/] for a List<int>");

            if (reCreate)
            {

                AnsiConsole.Status().Start("Creating database...", ctx =>
                {
                    using var context = new ListContext();
                    Helpers.CleanDatabase(context);

                    ctx.Status("Save a new entity");
                    ctx.Spinner(Spinner.Known.Star);
                    ctx.SpinnerStyle(Style.Parse("green"));

                    var entity = new EntityType { ListProperty = new List<int> { 1, 2, 3 } };
                    AnsiConsole.MarkupLine("[b][yellow]Adding[/][/] record");
                    context.Add(entity);
                    AnsiConsole.MarkupLine("[b][yellow]Saving[/][/]");
                    context.SaveChanges();

                    AnsiConsole.MarkupLine("[b][yellow]Mutate[/][/] the property value and save again...");
                    // This will be detected and EF will update the database on SaveChanges
                    entity.ListProperty.Add(4);

                    context.SaveChanges();

                });
            }


            using (var context = new ListContext())
            {
                AnsiConsole.MarkupLine("[b][cyan]Reading[/][/]");

                var entity = context.Set<EntityType>().Single();

                Debug.Assert(entity.ListProperty.SequenceEqual(new List<int> { 1, 2, 3, 4 }));
                Console.WriteLine($"\tId: {entity.Id,-5}List values: {string.Join(",", entity.ListProperty)}");
            }

            AnsiConsole.MarkupLine("[b][white]Finished[/][/]");
        }

    }
}
