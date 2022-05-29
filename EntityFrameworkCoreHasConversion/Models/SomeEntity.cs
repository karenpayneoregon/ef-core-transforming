using System;

namespace HasConversion.Models
{
    public class SomeEntity
    {
        public int Id { get; set; }

        public DateTime SomeDateTime { get; set; }

        public Guid SomeGuid { get; set; }

        public int SomeInt { get; set; }

        public double SomeDouble { get; set; }

        public SomeEnum SomeEnum { get; set; }

        public SomeFlagsEnum SomeFlagsEnum { get; set; }

        public override string ToString() => Id.ToString();

    }
}
