using System.Text.Json;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpectreColorsApp.Classes;

namespace SpectreColorsApp.ValueConverters;

public class SpectreItemConverter : ValueConverter<SpectreItem, string>
{
    public SpectreItemConverter() : base(
        v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null!),
        v => JsonSerializer.Deserialize<SpectreItem>(v, (JsonSerializerOptions)null!)!)
    { }
}