using SpectreColorsApp.Classes;
using SpectreColorsApp.Data;
using SpectreColorsApp.Models;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace SpectreColorsApp;

internal partial class Program
{
    [DllImport("kernel32.dll")]
    static extern IntPtr GetConsoleWindow();

    [DllImport("user32.dll")]
    static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    const int SW_HIDE = 0;
    const int SW_SHOW = 5;
    static void Main(string[] args)
    {
        
        ViewAll();

        Console.ReadLine();
    }

    private static void ViewAll()
    {
        using var context = new Context();
        var list = context.SpectreTable.ToList();

        ShowWindow(handle, SW_SHOW);
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);

        foreach (var row in list)
        {
            AnsiConsole.MarkupLine($"[{row.ItemColor}]{row.Purpose}[/]");
        }
    }

    private static void DisplayByPurposeDemo()
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
            Purpose = "Error color",
            ItemColor = new SpectreItem() { R = 255, G = 0, B = 0 }
        };

        using var context = new Context();
        context.SpectreTable.Add(spectreTable);
        Console.WriteLine(context.SaveChanges());
    }
}