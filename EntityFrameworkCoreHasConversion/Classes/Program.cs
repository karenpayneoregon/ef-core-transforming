using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ConsoleHelperLibrary.Classes;
using HasConversion.Classes;
using HasConversion.Models;
//using Newtonsoft.Json;


// ReSharper disable once CheckNamespace
namespace HasConversion;

partial class Program
{

    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Code sample: Has conversions";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }

    /// <summary>
    /// Example to get enum members descriptions
    /// </summary>
    public static void GetEnumDescriptions()
    {

        List<ItemContainer> result = EnumHelper.GetItems<WineVariantId>();

        foreach (var container in result)
        {
            Console.WriteLine($"{container.Value,-10}{container.Description}");
        }

    }

}