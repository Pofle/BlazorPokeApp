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
        app.MapGet("/api/teams", GetAllTeams);
        app.MapPost("/api/teams", CreateTeam);
    }

/// <summary>
/// Get ALL the Pokemons
/// </summary>
/// <param name="db"> Database context </param>
/// <returns></returns>
    private static async Task<IResult> GetAllPokemons(IDbContextFactory<PowkeAppDbContext> db)
    {
        await using var context = await db.CreateDbContextAsync();
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
            }).ToListAsync();

        return Results.Ok(pokemons);
    }

    /// <summary>
    /// Get ALL the Teams
    /// </summary>
    /// <param name="db"> Database context</param>
    /// <returns></returns>
    private static async Task<IResult> GetAllTeams (IDbContextFactory<PowkeAppDbContext> db)
    {
        await using var context = await db.CreateDbContextAsync();
        var teams = await context.Teams
        .Select(t => new
        {
            t.Id,
            t.Name,
            t.Description
        }).ToListAsync();
        
        return Results.Ok(teams);
    }

    /// <summary>
    /// CREATE a new Team
    /// </summary>
    /// <param name="TeamDto"> DTO for team </param>
    /// <param name="db"> Databse context</param>
    /// <returns></returns>
    private static async Task<IResult> CreateTeam(TeamDto TeamDto, PowkeAppDbContext db)
    {
        var team = new Team
        {
            Name = TeamDto.Name,
            Description = TeamDto.Description
        };

        db.Teams.Add(team);
        await db.SaveChangesAsync();
        return Results.Created($"/api/teams/{team.Id}", team);
    }
}