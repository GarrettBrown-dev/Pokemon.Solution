using Microsoft.EntityFrameworkCore;


namespace PokemonDb.Models
{
    public class PokemonDbContext : DbContext
    {
        public virtual DbSet<PokeType> PokeTypes { get; set; }
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Pokedex> Pokedex { get; set; }
        public DbSet<Trainer> Trainers { get; set; }

        public PokemonDbContext(DbContextOptions options) : base(options) { }
    }
}