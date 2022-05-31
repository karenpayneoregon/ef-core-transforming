
# About

This project shows what a developer need to code when confronted with a database table schema which does not have proper data types e.g. a DateTime is stored for instance as a string.

```csharp
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
```