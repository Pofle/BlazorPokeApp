using Microsoft.EntityFrameworkCore;
using PowkeApp.Data;

namespace PowkeApp.Api;

public static class PokemonApi
{
    public static void MapPokemonEndpoints(this WebApplication app)
    {
        app.MapGet("/api/pokemons", async (IDbContextFactory<PowkeAppDbContext> dbFactory) =>
        {
            await using var context = await dbFactory.CreateDbContextAsync();
            return await context.Pokemons
                .Include(p => p.Sprite)
                .Select(p => new 
                {
                    p.Id,
                    p.Name,
                    p.Weight,
                    p.Height,
                    p.Order,
                    FrontDefault = p.Sprite != null ? p.Sprite.FrontDefault : null
                })
                .ToListAsync();
        });
    }
}