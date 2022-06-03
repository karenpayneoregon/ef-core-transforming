using System.Collections.Generic;
using System.ComponentModel;

namespace BooksLibrary.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public BookVariantId BookVariantId { get; set; }
        public BookVariant BookVariant { get; set; }
        public override string ToString() => Name;
    }

    public enum BookVariantId : int
    {
        [Description("Space Travel")]
        SpaceTravel = 0,

        [Description("Adventure")]
        Adventure = 1,

        [Description("Sports")]
        Sports = 2,

        [Description("Automobile")]
        Automobile = 3,

        [Description("Computer Programming")]
        Programming = 4
    }


    public class BookVariant
    {
        public BookVariantId BookVariantId { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
        public override string ToString() => Name;
    }
}
