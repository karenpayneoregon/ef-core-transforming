using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;

namespace SpectreColorsApp.Classes;

    public class SpectreItem
    {
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }
    }

    public class SpectreItemConverter : ValueConverter<SpectreItem, string>
    {
        public SpectreItemConverter() : base(
            v => 
                JsonSerializer.Serialize(v, (JsonSerializerOptions)null!),
            v => 
                JsonSerializer.Deserialize<SpectreItem>(v, (JsonSerializerOptions)null!)!) { }
    }

