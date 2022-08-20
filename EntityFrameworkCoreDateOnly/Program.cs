using DateOnlyApp.Data;

namespace DateOnlyApp
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            
            AnsiConsole.MarkupLine("[yellow]Reading people[/]");

           
            using var context = new Context();

            var table = KP_ConsoleAppNet6.Program.CreateTable();

            var people = context.Person.ToList();

            foreach (var person in people)
            {
                table.AddRow(person.PersonId.ToString(), person.FirstName, person.LastName, person.BirthDate!.Value.ToString("MM/dd/yyyy"));
            }

            AnsiConsole.Clear();
            AnsiConsole.Write(table);
            AnsiConsole.MarkupLine("Press [b]ENTER[/] to return to menu");

            Console.ReadLine();
        }


    }
}