namespace PowkeApp.Models;

public class PokemonType
{
    public int Id { get; set; }
    public int PokemonId { get; set; }
    public required string TypeName { get; set; }
    public int? Slot { get; set; }

    // Navigation property
    public Pokemon Pokemon { get; set; } = null!;
}