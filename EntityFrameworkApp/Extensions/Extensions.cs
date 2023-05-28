using System;
using System.Text.RegularExpressions;

namespace EntityFrameworkApp.Extensions
{
    public static class Extensions
    {
        public static bool IsNull(this object sender)
        {
            return sender == null || sender == DBNull.Value || Convert.IsDBNull(sender) == true;
        }

        /// <summary>
        /// Is the instance of a class null
        /// </summary>
        /// <typeparam name="T">Concrete class type</typeparam>
        /// <param name="senderInstance">Instance of concrete class</param>
        /// <returns>True if null, false if not null</returns>
        public static bool IsNull<T>(this T senderInstance) where T : new() => senderInstance is null;

        /// <summary>
        /// Is the instance of a class not null
        /// </summary>
        /// <typeparam name="T">Concrete class type</typeparam>
        /// <param name="senderInstance">Instance of concrete class</param>
        /// <returns>True if not null, false if null</returns>
        public static bool IsNotNull<T>(this T senderInstance) where T : new() => !senderInstance.IsNull();
        /// <summary>
        /// Use to split on upper cased characters and separate with a single space.
        /// </summary>
        public static string SplitCamelCase(this string sender) =>
            string.Join(" ", Regex.Matches(sender, @"([A-Z][a-z]+)")
                .Select(m => m.Value));

    }
}
