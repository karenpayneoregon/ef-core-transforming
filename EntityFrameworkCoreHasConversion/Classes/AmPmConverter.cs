using System;
using System.Globalization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HasConversion.Classes
{
    /// <summary>
    /// Only for EF Core 6
    /// </summary>
    public class AmPmConverter : ValueConverter<string,DateTime>
    {
        public AmPmConverter() : base(

                v => DateTime.ParseExact(v, "dd/M/yyyy hh:mm:ss tt", 
                    new DateTimeFormatInfo() { AMDesignator = "a. m.", PMDesignator = "p. m." }),
                v => v.ToString(CultureInfo.InvariantCulture)
                
                ) { }
    }
}