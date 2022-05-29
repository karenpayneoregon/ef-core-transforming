using Microsoft.EntityFrameworkCore;

namespace HasConversion.Classes
{
    public class Helpers
    {
        public static void CleanDatabase(DbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
