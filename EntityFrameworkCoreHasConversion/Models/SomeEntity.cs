﻿using System;
using System.Net;

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

        public IPAddress SomeAddress { get; set; }

        public Dollars SomePrice { get; set; }

        //public string ShortName { get; set; }

        public override string ToString() => Id.ToString();

    }
}
