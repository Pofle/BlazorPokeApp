// //! Comment and not comment this code to put poke datas in the database
// using Microsoft.AspNetCore.Builder;
// using Microsoft.EntityFrameworkCore;
// using PowkeApp.Data;
// using PowkeApp.Models;

// namespace PowkeApp.Api;

// public static class SeedApi
// {
//     public static void MapSeedEndpoints(this WebApplication app)
//     {
//         // ⚠️ TEMPORARY - Remove after seeding !
//         app.MapGet("/api/seed", async (IDbContextFactory<PowkeAppDbContext> dbFactory) =>
//         {
//             using var http = new HttpClient();
//             await using var context = await dbFactory.CreateDbContextAsync();

//             var evolutionChainsDone = new HashSet<string>();
//             var results = new List<string>();

//             for (int i = 1; i <= 151; i++)
//             {
//                 try
//                 {
//                     // Fetch pokemon data
//                     var data = await http.GetFromJsonAsync<PokeApiPokemon>(
//                         $"https://pokeapi.co/api/v2/pokemon/{i}");

//                     if (data is null) continue;

//                     // -- Pokemon
//                     var existing = await context.Pokemons.FindAsync(data.Id);
//                     if (existing is null)
//                     {
//                         context.Pokemons.Add(new Pokemon
//                         {
//                             Id = data.Id,
//                             Name = data.Name,
//                             Weight = data.Weight,
//                             Height = data.Height,
//                             BaseExperience = data.BaseExperience,
//                             Order = data.Order
//                         });
//                     }

//                     await context.SaveChangesAsync();

//                     // -- Types
//                     var oldTypes = context.PokemonTypes.Where(t => t.PokemonId == i);
//                     context.PokemonTypes.RemoveRange(oldTypes);
//                     foreach (var t in data.Types)
//                     {
//                         context.PokemonTypes.Add(new PokemonType
//                         {
//                             PokemonId = i,
//                             TypeName = t.Type.Name,
//                             Slot = t.Slot
//                         });
//                     }

//                     // -- Stats
//                     var oldStats = context.PokemonStats.Where(s => s.PokemonId == i);
//                     context.PokemonStats.RemoveRange(oldStats);
//                     foreach (var s in data.Stats)
//                     {
//                         context.PokemonStats.Add(new PokemonStat
//                         {
//                             PokemonId = i,
//                             StatName = s.Stat.Name,
//                             BaseStat = s.BaseStat,
//                             Effort = s.Effort
//                         });
//                     }

//                     // -- Abilities
//                     var oldAbilities = context.PokemonAbilities.Where(a => a.PokemonId == i);
//                     context.PokemonAbilities.RemoveRange(oldAbilities);
//                     foreach (var a in data.Abilities)
//                     {
//                         context.PokemonAbilities.Add(new PokemonAbility
//                         {
//                             PokemonId = i,
//                             AbilityName = a.Ability.Name,
//                             IsHidden = a.IsHidden,
//                             Slot = a.Slot
//                         });
//                     }

//                     // -- Moves
//                     var oldMoves = context.PokemonMoves.Where(m => m.PokemonId == i);
//                     context.PokemonMoves.RemoveRange(oldMoves);
//                     foreach (var m in data.Moves)
//                     {
//                         foreach (var version in m.VersionGroupDetails)
//                         {
//                             context.PokemonMoves.Add(new PokemonMove
//                             {
//                                 PokemonId = i,
//                                 MoveName = m.Move.Name,
//                                 LearnMethod = version.MoveLearnMethod.Name,
//                                 LevelLearnedAt = version.LevelLearnedAt
//                             });
//                         }
//                     }

//                     // -- Sprites
//                     var oldSprite = await context.PokemonSprites.FindAsync(i);
//                     if (oldSprite is not null) context.PokemonSprites.Remove(oldSprite);
//                     context.PokemonSprites.Add(new PokemonSprite
//                     {
//                         PokemonId = i,
//                         FrontDefault = data.Sprites.FrontDefault,
//                         FrontShiny = data.Sprites.FrontShiny,
//                         BackDefault = data.Sprites.BackDefault,
//                         BackShiny = data.Sprites.BackShiny
//                     });

//                     // -- Evolution chain
//                     var speciesData = await http.GetFromJsonAsync<PokeApiSpecies>(data.Species.Url);
//                     if (speciesData is not null)
//                     {
//                         var chainUrl = speciesData.EvolutionChain.Url;
//                         if (!evolutionChainsDone.Contains(chainUrl))
//                         {
//                             evolutionChainsDone.Add(chainUrl);
//                             var chainData = await http.GetFromJsonAsync<PokeApiEvolutionChain>(chainUrl);
//                             if (chainData is not null)
//                             {
//                                 var evolutions = ParseEvolutionChain(chainData.Chain);
//                                 foreach (var evo in evolutions)
//                                 {
//                                     var exists = context.PokemonEvolutions.Any(e =>
//                                         e.FromPokemonName == evo.FromPokemonName &&
//                                         e.ToPokemonName == evo.ToPokemonName);

//                                     if (!exists)
//                                         context.PokemonEvolutions.Add(evo);
//                                 }
//                             }
//                         }
//                     }

//                     await context.SaveChangesAsync();

//                     results.Add($"[{i}/151] {data.Name} ✓");
//                     await Task.Delay(300);
//                 }
//                 catch (Exception ex)
//                 {
//                     results.Add($"[{i}/151] ERROR: {ex.Message}");
//                 }
//             }

//             return Results.Ok(results);
//         });
//     }

//     private static List<PokemonEvolution> ParseEvolutionChain(PokeApiChainLink chain)
//     {
//         var results = new List<PokemonEvolution>();
//         foreach (var evolution in chain.EvolvesTo)
//         {
//             var details = evolution.EvolutionDetails.FirstOrDefault();
//             results.Add(new PokemonEvolution
//             {
//                 FromPokemonName = chain.Species.Name,
//                 ToPokemonName = evolution.Species.Name,
//                 Trigger = details?.Trigger?.Name,
//                 MinLevel = details?.MinLevel,
//                 Item = details?.Item?.Name
//             });
//             results.AddRange(ParseEvolutionChain(evolution));
//         }
//         return results;
//     }
// }