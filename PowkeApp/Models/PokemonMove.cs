namespace PowkeApp.Models;

public class PokemonMove
{
    public int Id { get; set; }
    public int PokemonId { get; set; }
    public required string MoveName { get; set; }
    public string? LearnMethod { get; set; }
    public int? LevelLearnedAt { get; set; }

    // Navigation property
    public Pokemon Pokemon { get; set; } = null!;
}