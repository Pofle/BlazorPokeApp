namespace PowkeApp.Models;

public class PokemonAbility
{
    public int Id { get; set; }
    public int PokemonId { get; set; }
    public required string AbilityName { get; set; }
    public bool IsHidden { get; set; }
    public int? Slot { get; set; }

    // Navigation property
    public Pokemon Pokemon { get; set; } = null!;
}