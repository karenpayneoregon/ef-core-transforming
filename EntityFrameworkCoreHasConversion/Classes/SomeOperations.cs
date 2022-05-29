﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HasConversion.Data;
using HasConversion.Models;

namespace HasConversion.Classes
{
    public class SomeOperations
    {
        /// <summary>
        /// Create database/table, populate
        /// </summary>
        public static void AddView()
        {
            using var context = new SomeContext();
            Helpers.CleanDatabase(context);

            for (int index = 0; index < 5; index++)
            {
                context.SomeEntities.Add(new SomeEntity
                {
                    SomeDateTime = DateTime.Now,
                    SomeGuid = Guid.NewGuid(),
                    SomeInt = new Random().Next(1_000_000),
                    SomeDouble = new Random().NextDouble() * 10_000,
                    SomeEnum = (SomeEnum)new Random().Next(3),
                    SomeFlagsEnum = SomeFlagsEnum.First | SomeFlagsEnum.Second
                });
            }

            
            context.SaveChanges();

            /*
             * TODO
             * Now inspect the column types in the database table
             */
        }
    }
}
