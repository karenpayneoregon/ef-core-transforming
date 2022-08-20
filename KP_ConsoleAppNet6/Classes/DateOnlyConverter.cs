#nullable disable
using KP_ConsoleAppNet6;

namespace KP_ConsoleAppNet6.Classes;

internal class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
{
    public DateOnlyConverter()
        : base(d => d.ToDateTime(TimeOnly.MinValue),
            d => DateOnly.FromDateTime(d)) { }
}