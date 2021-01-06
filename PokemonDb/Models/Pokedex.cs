// Join table 

namespace PokemonDb.Models
{
    public class Pokedex
    {
        public int PokedexId { get; set; }
        public int PokemonId { get; set; }
        public int PokeTypeId { get; set; }
        public PokeType PokeType { get; set; }
        public Pokemon Pokemon { get; set; }
    }
}