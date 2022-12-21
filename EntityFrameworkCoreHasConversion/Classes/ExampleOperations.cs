using HasConversion.Data;

namespace HasConversion.Classes;

/// <summary>
/// This code works only with EF Core 6 but will compile with EF Core, run and get
/// a runtime exception.
///
/// The property 'Person1.Address' is of type 'Address' which is not supported by the current database provider.
/// Either change the property CLR type, or ignore the property using the '[NotMapped]' attribute or
/// by using 'EntityTypeBuilder.Ignore' in 'OnModelCreating'.
/// </summary>
public class ExampleOperations
{
    public static Person1 newPerson()
    {
        Person1 person = new ()
        {
            FirstName = "Jim", 
            LastName = "Smith",
            Address = new() {Country = "USA", Street = "123 Apple Road", ZipCode = "1111"}
        };

        return person;

    }

    public static void AddView()
    {
        using var context = new ExampleContext();
        Helpers.CleanDatabase(context);
        context.Add(newPerson());
    }

}