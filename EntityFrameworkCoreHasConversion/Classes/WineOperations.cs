using System.Linq;
using HasConversion.Data;
using HasConversion.Models;
using Microsoft.EntityFrameworkCore;
using Spectre.Console;
using static HasConversion.Models.WineVariantId;

namespace HasConversion.Classes
{
    public class WineOperations
    {
        /// <summary>
        /// If database does not exists than pass true to this method
        /// to create and populate with several records.
        ///
        /// Otherwise passing false to view records in database
        /// </summary>
        /// <param name="reCreate"></param>
        public static void AddViewWines(bool reCreate = false)
        {
            using var context = new WineContext();
            
            if (reCreate)
            {

                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Wines.Add(new Wine
                {
                    Name = "Veuve Clicquot Rose",
                    WineVariantId = Rose,
                });

                context.Wines.Add(new Wine
                {
                    Name = "Whispering Angel Rose",
                    WineVariantId = Rose,
                });

                context.Wines.Add(new Wine
                {
                    Name = "Pinot Grigio",
                    WineVariantId = White,
                });

                context.SaveChanges();

            }

            /*
             * Get all wines
             */
            var allWines = context.Wines.Include(item => item.WineVariant).ToList();
            var winesTable = WinTable;

            winesTable.AddRow("[b]All[/]");
            foreach (Wine wineItem in allWines)
            {
                winesTable.AddRow(wineItem.WineVariantId.ToString(), wineItem.Name);
            }
           

            var roseWines = context.Wines.Where(wine => wine.WineVariantId == Rose).ToList();

            winesTable.AddRow("[b]Rose[/]");
            foreach (Wine roseWine in roseWines)
            {
                winesTable.AddRow("", roseWine.Name);
            }

            winesTable.AddRow("[b]Red[/]");
            var redWines = context.Wines.Where(wine => wine.WineVariantId == Red).ToList();
            foreach (var redWine in redWines)
            {
                winesTable.AddRow("", redWine.Name);
            }

            AnsiConsole.Write(winesTable);

        }

        public static Table WinTable => new Table()
            .RoundedBorder()
            .AddColumn("[b]Category[/]")
            .AddColumn("[b]Type[/]")
            .Alignment(Justify.Center)
            .BorderColor(Color.LightSlateGrey)
            .Title("[yellow]Wines[/]");

    }
}
