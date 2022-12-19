using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using ConsoleHelperLibrary.Classes;
using HasConversion.Classes;
using HasConversion.Data;
using HasConversion.Models;
using Microsoft.EntityFrameworkCore;
//using Newtonsoft.Json;
using Spectre.Console;


// ReSharper disable once CheckNamespace
namespace HasConversion
{
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
}





