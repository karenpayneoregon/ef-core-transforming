using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfigurationLibrary.LanguageExtensions;
using ConventionalApp.Models;
using static ConfigurationLibrary.Classes.ConfigurationHelper;

namespace ConventionalApp.Classes
{
    public class Operations
    {
        public static async Task<bool> CanConnect()
        {
            await using var cn = new SqlConnection(ConnectionString());
            await using var cmd = new SqlCommand() { Connection = cn };
            cmd.CommandText = "SELECT Id, SomeDateTime, SomeInt, SomeEnum, SomePrice FROM dbo.SomeEntities;";
            try
            {
                await cn.OpenAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static async Task<List<SomeEntity>> ReadEntitiesAsync()
        {

            List<SomeEntity> list = new();

            await using var cn = new SqlConnection(ConnectionString());
            await using var cmd = new SqlCommand() { Connection = cn };
            cmd.CommandText = "SELECT Id, SomeDateTime, SomeInt, SomeEnum, SomePrice FROM dbo.SomeEntities;";
            await cn.OpenAsync();
            var reader = await cmd.ExecuteReaderAsync();

            while (reader.Read())
            {
                SomeEntity entity = new();

                entity.Id = reader.GetInt32(0);
                entity.SomeDateTime = Convert.ToDateTime(reader.GetString(1));
                entity.SomeInt = Convert.ToInt32(reader.GetString(2));
                entity.SomeEnum = reader.GetString(3).ToEnum<SomeEnum>(SomeEnum.First);

                list.Add(entity);
            }


            return list;
        }
    }
}
