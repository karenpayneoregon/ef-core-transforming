using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
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

        public static async Task<(bool success, Exception exception)> UpdateEntity(SomeEntity entity)
        {
            await using var cn = new SqlConnection(ConnectionString());
            await using var cmd = new SqlCommand() { Connection = cn };

            cmd.CommandText = UpdateStatement;

            entity.SomeGuid = Guid.NewGuid();

            cmd.Parameters.Add("@SomeDateTime", SqlDbType.NVarChar).Value = entity.SomeDateTime
                .ToString(CultureInfo.InvariantCulture);

            cmd.Parameters.Add("@SomeGuid", SqlDbType.NVarChar).Value = entity.SomeGuid.ToString();
            cmd.Parameters.Add("@SomeInt", SqlDbType.NVarChar).Value = entity.SomeInt;
            cmd.Parameters.Add("@SomeEnum", SqlDbType.NVarChar).Value = entity.SomeEnum;
            cmd.Parameters.Add("@SomePrice", SqlDbType.Decimal).Value = entity.SomePrice.Amount;
            cmd.Parameters.Add("@Identifier", SqlDbType.Int).Value = entity.Id;

            Debug.WriteLine(cmd.ActualCommandText());

            await cn.OpenAsync();

            try
            {
                cmd.ExecuteNonQuery();
                return (true, null);
            }
            catch (Exception localException)
            {

                return (false, localException);
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
                SomeEntity entity = new()
                {
                    Id = reader.GetInt32(0),
                    SomeDateTime = Convert.ToDateTime(reader.GetString(1)),
                    SomeInt = Convert.ToInt32(reader.GetString(2)),
                    SomeEnum = reader.GetString(3).ToEnum(SomeEnum.First)
                };

                list.Add(entity);
            }

            return list;

        }

        public static string UpdateStatement => @"
        UPDATE dbo.SomeEntities
          SET 
              SomeDateTime = @SomeDateTime, 
              SomeGuid = @SomeGuid, 
              SomeInt = @SomeInt, 
              SomeEnum = @SomeEnum, 
              SomePrice = @SomePrice
        WHERE Id = @Identifier;";

    }
}
