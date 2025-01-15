namespace SpectreColorsApp.Classes;

public class SpectreItem
{
    public byte R { get; set; }
    public byte G { get; set; }
    public byte B { get; set; }
    /// <summary>
    /// Markup color
    /// </summary>
    /// <returns>Spectre color</returns>
    public override string ToString() => new Color(R, G, B).ToMarkup();
}