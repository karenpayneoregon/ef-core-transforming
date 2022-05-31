using System;

namespace EntityFrameworkApp.Models
{
    [Flags]
    public enum SomeFlagsEnum
    {
        First = 1,
        Second = 2,
        Third = 4
    }
}