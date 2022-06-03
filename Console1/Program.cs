using System;
using System.Globalization;

namespace Console1
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var value = "31/5/2022 11:00:00 a. m.";
            DateTimeFormatInfo formatInfo = new () { AMDesignator = "a. m.", PMDesignator = "p. m." };
            var dateTime = DateTime.ParseExact(value, "dd/M/yyyy hh:mm:ss tt", formatInfo);
            Console.WriteLine(value);
            Console.WriteLine(dateTime);

            Console.ReadLine();
        }
    }
}
