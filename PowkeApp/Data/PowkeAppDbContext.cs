using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PowkeApp.Models;

namespace PowkeApp.Data
{
    public class PowkeAppDbContext : DbContext
    {
        public PowkeAppDbContext (DbContextOptions<PowkeAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pokemon> Pokemons { get; set; } = default!;
        public DbSet<PokemonType> PokemonTypes => Set<PokemonType>();
        public DbSet<PokemonStat> PokemonStats => Set<PokemonStat>();
        public DbSet<PokemonAbility> PokemonAbilities => Set<PokemonAbility>();
        public DbSet<PokemonMove> PokemonMoves => Set<PokemonMove>();
        public DbSet<PokemonEvolution> PokemonEvolutions => Set<PokemonEvolution>();
        public DbSet<PokemonSprite> PokemonSprites => Set<PokemonSprite>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        // PokemonSprite has a 1-to-1 relationship with Pokemon
        // PokemonId is both PK and FK
        modelBuilder.Entity<PokemonSprite>()
            .HasKey(s => s.PokemonId);

        modelBuilder.Entity<PokemonSprite>()
            .HasOne(s => s.Pokemon)
            .WithOne(p => p.Sprite)
            .HasForeignKey<PokemonSprite>(s => s.PokemonId);
        }

        
    }
}
