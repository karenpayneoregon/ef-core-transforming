using System.ComponentModel.DataAnnotations;

namespace HasConversion.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsFriend { get; set; }
        public override string ToString() => $"{FirstName} {LastName}";
    }
}