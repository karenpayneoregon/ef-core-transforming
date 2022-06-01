using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkApp.Data;
using EntityFrameworkApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkApp.Classes
{
    public class Operations
    {
        public static async Task<List<SomeEntity>> ReadEntitiesAsync()
        {
            await using var context = new SomeContext(ConnectionType.Standard);

            return await context.SomeEntities.ToListAsync();
        }
    }
}
