namespace PowkeApp.Api;

public class PokemonDto
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int? Weight { get; set; }
    public int? Height { get; set; }
    public int? Order { get; set; }
    public string? FrontDefault { get; set; }
}