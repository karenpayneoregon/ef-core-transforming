
using HasConversion.Data;

namespace HasConversion.Classes;

class AmPmOperations
{
    public static void Example()
    {
        using var context = new ExampleAmPmContext();
        Helpers.CleanDatabase(context);
        context.Add(new DateItem() { WantToBeDateTime = "31/5/2022 11:00:00 a. m." });
        context.SaveChanges();

    }
}