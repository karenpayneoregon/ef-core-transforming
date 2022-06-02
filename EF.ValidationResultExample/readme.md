# self-validation : IValidatableObject

![Self Validate](assets/self_validate.png)

A `self-validating` model is a model object that knows how to validate itself. A model object can
announce this capability by implementing the [IValidatableObject](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.ivalidatableobject?view=net-6.0) interface.

**Implement** `IValidatableObject`

```csharp
public partial class Book : IValidatableObject
```

**Annotate**

```csharp
[Required]
public string Title { get; set; }
[Required]
public string Author { get; set; }
```

**Validate**

```csharp
public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
{
    if (string.IsNullOrWhiteSpace(Title))
    {
        yield return new ValidationResult(
            $"{nameof(Title)} cannot be empty",
            new[] { nameof(Title) });
    }

    if (string.IsNullOrWhiteSpace(Author))
    {
        yield return new ValidationResult(
            $"{nameof(Author)} cannot be empty",
            new[] { nameof(Author) });
    }
}
```

**Perform validation**

```csharp
private static Book BookMissingTitleAndAuthor()
{
    Book book = new();

    ValidationContext validationContext = new ValidationContext(book);
    IEnumerable<ValidationResult> validationResults = book.Validate(validationContext);

    if (validationResults.IsValid())
    {
        AnsiConsole.MarkupLine("[b][yellow]Valid[/][/] book");
    }
    else
    {
        AnsiConsole.MarkupLine("[b][red]Failed[/][/] validation");
        foreach (var result in validationResults)
        {
            Console.WriteLine($"{result.ErrorMessage,25}");
        }
    }

    return book;
}
```