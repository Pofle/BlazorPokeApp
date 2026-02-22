namespace PowkeApp.Models;

public class PokemonEvolution
{
    public int Id { get; set; }
    public required string FromPokemonName { get; set; }
    public required string ToPokemonName { get; set; }
    public string? Trigger { get; set; }
    public int? MinLevel { get; set; }
    public string? Item { get; set; }
}