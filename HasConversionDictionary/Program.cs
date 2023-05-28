using HasConversionDictionary.Data;
using HasConversionDictionary.Models;

namespace HasConversionDictionary;

internal partial class Program
{
    static void Main(string[] args)
    {
        using var context = new DictionaryContext();
        //AddItems(context);
        //Show(context);
        Dictionary item = context.Dictionary.FirstOrDefault(x => x.Data.Key == "K2")!;


        Console.ReadLine();
        
    }

    private static void Show(DictionaryContext context)
    {
        var items = context.Dictionary.ToList();
        foreach (var item in items)
        {
            Console.WriteLine($"{item.Id,-4}{item.Data.Key,-4}{item.Data.Value}");
        }
    }

    private static void AddItems(DictionaryContext context)
    {
        context.Add(new Dictionary() { Data = new DataEntity() { Key = "K1", Value = "V1" } });
        context.Add(new Dictionary() { Data = new DataEntity() { Key = "K2", Value = "V2" } });
        context.Add(new Dictionary() { Data = new DataEntity() { Key = "K3", Value = "V3" } });
        context.SaveChanges();
    }
}