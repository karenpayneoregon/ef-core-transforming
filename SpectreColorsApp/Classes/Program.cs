using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace SpectreColorsApp;
internal partial class Program
{
    private static IntPtr handle;
    [ModuleInitializer]
    public static void Init()
    {
        handle = GetConsoleWindow();
        ShowWindow(handle, SW_HIDE);
        Console.Title = "Code sample EF Core Value converter";
    }
}
