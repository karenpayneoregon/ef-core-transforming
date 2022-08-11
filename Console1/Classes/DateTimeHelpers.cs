using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Console1.Classes
{
    public static class DateTimeHelpers
    {
        public static DateTimeFormatInfo AmDateTimeFormatInfo 
            => new()
            {
                AMDesignator = "a. m.", 
                PMDesignator = "p. m."
            };

        public static DateTime FixAmPm(this string sender)
        {
            string[] endings = { "a. m.", "p. m." };


            return endings.Any(sender.EndsWith) ? 
                DateTime.ParseExact(sender, "dd/M/yyyy hh:mm:ss tt", AmDateTimeFormatInfo) : 
                Convert.ToDateTime(sender);
        }
    }
}
