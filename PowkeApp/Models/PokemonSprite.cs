namespace PowkeApp.Models;

public class PokemonSprite
{
    public int PokemonId { get; set; }
    public string? FrontDefault { get; set; }
    public string? FrontShiny { get; set; }
    public string? BackDefault { get; set; }
    public string? BackShiny { get; set; }

    // Navigation property
    public Pokemon Pokemon { get; set; } = null!;
}