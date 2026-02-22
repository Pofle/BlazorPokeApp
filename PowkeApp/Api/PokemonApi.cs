using Microsoft.EntityFrameworkCore;
using PowkeApp.Data;
using PowkeApp.Models;

namespace PowkeApp.Api;

public static class PokemonApi
{
    public static void MapPokemonEndpoints(this WebApplication app)
    {
        app.MapGet("/api/pokemons", async (IDbContextFactory<PowkeAppDbContext> dbFactory) =>
        {
            await using var context = await dbFactory.CreateDbContextAsync();
            return await context.Pokemons.ToListAsync();
        });
    }
}