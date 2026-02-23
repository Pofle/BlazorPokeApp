using Microsoft.EntityFrameworkCore;
using PowkeApp.Data;
using PowkeApp.Models;

namespace PowkeApp.Api;

public static class PokemonApi
{
    public static void MapPokemonEndpoints(this WebApplication app)
    {
        //*Pokemon API
        app.MapGet("/api/pokemons", GetAllPokemons);

        //*Team API
        app.MapPost("/api/teams", CreateTeam);
    }

    private static async Task<IResult> GetAllPokemons(IDbContextFactory<PowkeAppDbContext> dbFactory)
    {
        await using var context = await dbFactory.CreateDbContextAsync();
        var pokemons = await context.Pokemons
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

        return Results.Ok(pokemons);
    }

    private static async Task<IResult> CreateTeam(TeamDto dto, PowkeAppDbContext db)
    {
        var team = new Team
        {
            Name = dto.Name,
            Description = dto.Description
        };

        db.Teams.Add(team);
        await db.SaveChangesAsync();
        return Results.Created($"/api/teams/{team.Id}", team);
    }
}