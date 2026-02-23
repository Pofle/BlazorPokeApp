namespace PowkeApp.Models;

public class Team
{
    public int Id { get; set; }

    public required string Name { get ; set; }

    public string? Description { get; set; }

    // Navigation properties

    public ICollection<Pokemon>? Pokemons { get; set;} = [];
}