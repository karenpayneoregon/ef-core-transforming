using System;
using System.Globalization;
using Console1.Classes;
using Spectre.Console;

namespace Console1
{
    partial class Program
    {
        static void Main(string[] args)
        {

            // 31/5/2022 11:00:00 a. m.
            // 31/5/2022 11:00:00 AM

            //AnsiConsole.MarkupLine("[b][white]Conventional DateTime with AM/PM[/][/]");
            Console.WriteLine(DateTime.Now.ToString("dd/M/yyyy hh:mm tt"));

            Console.WriteLine();

            DoConvert1();
            DoConvert2();

            Console.WriteLine();
            AnsiConsole.MarkupLine("[b][white]Done[/][/]");
            Console.ReadLine();

        }

        private static string _dateTimeValue => "31/5/2022 11:00:00 a. m.";

        private static void DoConvert1()
        {

            AnsiConsole.MarkupLine($"[b][white on blue]{nameof(DoConvert1)}[/][/]");

           string cleanedValue = _dateTimeValue
                .Replace("a. m.", "AM")
                .Replace("p. m.", "PM");

            string format = "d/M/yyyy h:mm:ss tt";

            var dateTime = DateTime.ParseExact(cleanedValue, format, CultureInfo.InvariantCulture);

            Console.WriteLine(_dateTimeValue);
            Console.WriteLine(dateTime);

        }

        private static void DoConvert2()
        {

            AnsiConsole.MarkupLine($"[b][white on blue]{nameof(DoConvert2)}[/][/]");

            DateTimeFormatInfo formatInfo = new ()
            {
                AMDesignator = "a. m.", 
                PMDesignator = "p. m."
            };

            var dateTime = DateTime.ParseExact(
                _dateTimeValue, 
                "dd/M/yyyy hh:mm:ss tt", 
                formatInfo);

            Console.WriteLine(_dateTimeValue);
            Console.WriteLine(dateTime);
        }
    }
}
