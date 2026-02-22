namespace PowkeApp.Models;

public class PokemonStat
{
    public int Id { get; set; }
    public int PokemonId { get; set; }
    public required string StatName { get; set; }
    public int? BaseStat { get; set; }
    public int? Effort { get; set; }

    // Navigation property
    public Pokemon Pokemon { get; set; } = null!;
}