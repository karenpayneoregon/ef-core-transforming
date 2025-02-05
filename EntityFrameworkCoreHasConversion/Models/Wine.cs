﻿using System.Collections.Generic;
using System.ComponentModel;

namespace HasConversion.Models;

public class Wine
{
    public int WineId { get; set; }
    public string Name { get; set; }
    public WineType WineVariantId { get; set; }
    public WineVariant WineVariant { get; set; }
    public override string ToString() => Name;
}

public enum WineType
{
    [Description("Imported red wine")]
    Red = 0,
    [Description("Imported white wine")]
    White = 1,
    [Description("Imported rose wine")]
    Rose = 2
}

public class WineVariant
{
    public WineType WineVariantId { get; set; }
    public string Name { get; set; }
    public List<Wine> Wines { get; set; }
    public override string ToString() => Name;
}