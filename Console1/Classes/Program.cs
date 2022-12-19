using ConsoleHelperLibrary.Classes;
using System.Runtime.CompilerServices;


// ReSharper disable once CheckNamespace
namespace Console1;

partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Code sample: AM/PM";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
}