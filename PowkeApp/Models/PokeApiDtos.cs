// //! Comment and not comment this code to put poke datas in the database
// using System.Text.Json.Serialization;

// namespace PowkeApp.Models;

// public class PokeApiPokemon
// {
//     public int Id { get; set; }
//     public string Name { get; set; } = "";
//     public int Weight { get; set; }
//     public int Height { get; set; }
//     public int Order { get; set; }

//     [JsonPropertyName("base_experience")]
//     public int? BaseExperience { get; set; }

//     public List<PokeApiTypeSlot> Types { get; set; } = [];
//     public List<PokeApiStatSlot> Stats { get; set; } = [];
//     public List<PokeApiAbilitySlot> Abilities { get; set; } = [];
//     public List<PokeApiMoveSlot> Moves { get; set; } = [];
//     public PokeApiSprites Sprites { get; set; } = new();

//     [JsonPropertyName("species")]
//     public PokeApiNamedResource Species { get; set; } = new();
// }

// public class PokeApiTypeSlot
// {
//     public int Slot { get; set; }
//     public PokeApiNamedResource Type { get; set; } = new();
// }

// public class PokeApiStatSlot
// {
//     [JsonPropertyName("base_stat")]
//     public int BaseStat { get; set; }
//     public int Effort { get; set; }
//     public PokeApiNamedResource Stat { get; set; } = new();
// }

// public class PokeApiAbilitySlot
// {
//     [JsonPropertyName("is_hidden")]
//     public bool IsHidden { get; set; }
//     public int Slot { get; set; }
//     public PokeApiNamedResource Ability { get; set; } = new();
// }

// public class PokeApiMoveSlot
// {
//     public PokeApiNamedResource Move { get; set; } = new();

//     [JsonPropertyName("version_group_details")]
//     public List<PokeApiMoveVersion> VersionGroupDetails { get; set; } = [];
// }

// public class PokeApiMoveVersion
// {
//     [JsonPropertyName("level_learned_at")]
//     public int LevelLearnedAt { get; set; }

//     [JsonPropertyName("move_learn_method")]
//     public PokeApiNamedResource MoveLearnMethod { get; set; } = new();
// }

// public class PokeApiSprites
// {
//     [JsonPropertyName("front_default")]
//     public string? FrontDefault { get; set; }

//     [JsonPropertyName("front_shiny")]
//     public string? FrontShiny { get; set; }

//     [JsonPropertyName("back_default")]
//     public string? BackDefault { get; set; }

//     [JsonPropertyName("back_shiny")]
//     public string? BackShiny { get; set; }
// }

// public class PokeApiNamedResource
// {
//     public string Name { get; set; } = "";
//     public string Url { get; set; } = "";
// }

// public class PokeApiSpecies
// {
//     [JsonPropertyName("evolution_chain")]
//     public PokeApiEvolutionChainRef EvolutionChain { get; set; } = new();
// }

// public class PokeApiEvolutionChainRef
// {
//     public string Url { get; set; } = "";
// }

// public class PokeApiEvolutionChain
// {
//     public PokeApiChainLink Chain { get; set; } = new();
// }

// public class PokeApiChainLink
// {
//     public PokeApiNamedResource Species { get; set; } = new();

//     [JsonPropertyName("evolves_to")]
//     public List<PokeApiChainLink> EvolvesTo { get; set; } = [];

//     [JsonPropertyName("evolution_details")]
//     public List<PokeApiEvolutionDetail> EvolutionDetails { get; set; } = [];
// }

// public class PokeApiEvolutionDetail
// {
//     public PokeApiNamedResource? Trigger { get; set; }

//     [JsonPropertyName("min_level")]
//     public int? MinLevel { get; set; }

//     public PokeApiNamedResource? Item { get; set; }
// }