using System;
using System.Linq;
using System.Net;
using HasConversion.Data;
using HasConversion.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Spectre.Console;

namespace HasConversion.Classes;

public class SomeOperations
{
    /// <summary>
    /// Create database/table, populate
    /// </summary>
    public static void AddView(bool reCreate = false)
    {
        using var context = new SomeContext();

        if (reCreate)
        {

            Helpers.CleanDatabase(context);

            for (int index = 0; index < 10; index++)
            {
                context.SomeEntities.Add(new SomeEntity
                {
                    SomeDateTime = DateTime.Now,
                    SomeGuid = Guid.NewGuid(),
                    SomeInt = new Random().Next(1_000_000),
                    SomeDouble = new Random().NextDouble() * 10_000,
                    SomePrice = new Dollars(Convert.ToDecimal(new Random().NextDouble() * 10_000)),
                    SomeEnum = (SomeEnum)new Random().Next(3),
                    SomeFlagsEnum = SomeFlagsEnum.First | SomeFlagsEnum.Second,
                    SomeAddress = IPAddress.Parse(GetRandomIpAddress())
                });
            }


            context.SaveChanges();
        }

        /*
         * TODO
         * Now inspect the column types in the database table
         */

        var table = Table;

        var list = context.SomeEntities.ToList();

        list[2].SomeEnum = SomeEnum.First;

        #region Examine details for converter
        PropertyValues databaseValues = context.Entry(list[2]).GetDatabaseValues();
        var mapping = databaseValues.Properties[1].GetTypeMapping().Converter;
        #endregion

        foreach (var entity in list)
        {
            if (entity.SomeEnum == SomeEnum.First)
            {

                table.AddRow(
                    entity.Id.ToString(),
                    $"[white on red]{entity.SomeEnum}[/]",
                    entity.SomeDateTime.ToString("d"),
                    entity.SomeDouble.ToString("C"),
                    entity.SomeAddress.ToString(),
                    $"{entity.SomePrice,-12}{entity.SomePrice.GetType().Name}");
            }
            else
            {
                table.AddRow(
                    entity.Id.ToString(),
                    entity.SomeEnum.ToString(),
                    entity.SomeDateTime.ToString("d"),
                    entity.SomeDouble.ToString("C"),
                    entity.SomeAddress.ToString(),
                    $"{entity.SomePrice,-12}{entity.SomePrice.GetType().Name}");
            }
        }

        AnsiConsole.Write(table);

    }

    private static string GetRandomIpAddress()
    {
        var random = new Random();
        return $"{random.Next(1, 255)}.{random.Next(0, 255)}.{random.Next(0, 255)}.{random.Next(0, 255)}";
    }

    public static Table Table => new Table()
        .RoundedBorder()
        .AddColumn("[b]Id[/]")
        .AddColumn("[b]Enum[/]")
        .AddColumn("[b]DateTime[/]")
        .AddColumn("[b]Double[/]")
        .AddColumn("[b]IP Address[/]")
        .AddColumn("[b]Price[/]")
        .Alignment(Justify.Center)
        .BorderColor(Color.LightSlateGrey)
        .Title("[yellow]Entities[/]");
}