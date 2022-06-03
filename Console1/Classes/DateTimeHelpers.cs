using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Console1.Classes
{
    public class DateTimeHelpers
    {
        public static DateTimeFormatInfo AmDateTimeFormatInfo 
            => new()
            {
                AMDesignator = "a. m.", 
                PMDesignator = "p. m."
            };
    }
}
