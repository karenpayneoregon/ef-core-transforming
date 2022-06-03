using System;
using System.Globalization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HasConversion.Classes
{
    public class AmPmConverter : ValueConverter<DateTime, string>
    {
        public AmPmConverter() : base(
                v => 
                    v.ToString(CultureInfo.InvariantCulture),
                v => 
                    DateTime.ParseExact(v, "dd/M/yyyy hh:mm:ss tt", 
                        new DateTimeFormatInfo()
                        {
                            AMDesignator = "a. m.", 
                            PMDesignator = "p. m."
                        })
                    ) { }
    }
}