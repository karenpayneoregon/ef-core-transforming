using SpectreColorsApp.Classes;
using SpectreColorsApp.Data;
using SpectreColorsApp.Models;

namespace SpectreColorsApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        using var context = new Context();
        var list = context.SpectreTable.ToList();
        foreach (var row in list)
        {
            AnsiConsole.MarkupLine($"[{row.Color}]{row.Purpose}[/]");
        }

        Console.ReadLine();
    }

    private static void DisplayDemo()
    {
        using var context = new Context();
        var st = context.SpectreTable.FirstOrDefault( x=> x.Purpose == "Main text");

        var color = new Color(st.ItemColor.R, st.ItemColor.G, st.ItemColor.B);
        
        AnsiConsole.MarkupLine($"[{color.ToMarkup()}]Test[/]");
    }

    private static void CreateRecord()
    {
        SpectreTable spectreTable = new SpectreTable()
        {
            Purpose = "Secondary",
            ItemColor = new SpectreItem() { R = 255, G = 255, B = 0 }
        };

        using var context = new Context();
        context.SpectreTable.Add(spectreTable);
        Console.WriteLine(context.SaveChanges());
    }
}