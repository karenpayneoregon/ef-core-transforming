# About

Example for EF Core `HasConversion` for `enum`

```csharp
var programmingBooks = bookList
    .Where(books => books.BookVariantId == BookVariantId.Programming)
    .ToList();
```
</br>

![Screen Shot](assets/ScreenShot.png)