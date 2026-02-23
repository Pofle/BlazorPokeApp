namespace PowkeApp.Models;

public class Pokemon
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int? Weight { get; set; }
    public int? Height { get; set; }
    public int? BaseExperience { get; set; }
    public int? Order { get; set; }

    // Navigation properties
    public ICollection<PokemonType> Types { get; set; } = [];
    public ICollection<PokemonStat> Stats { get; set; } = [];
    public ICollection<PokemonAbility> Abilities { get; set; } = [];
    public ICollection<PokemonMove> Moves { get; set; } = [];
    public PokemonSprite? Sprite { get; set; }
    public ICollection<Team> Teams { get; set; } = [];
}