using System.Collections.Generic;

namespace PokemonDb.Models
{
    public class PokeType
    {
        public PokeType()
        {
            this.Pokemons = new HashSet<Pokedex>();
        }
        public int PokeTypeId { get; set; }
        public string PokeTypeName { get; set; }
        public virtual ICollection<Pokedex> Pokemons { get; set; }
    }
}