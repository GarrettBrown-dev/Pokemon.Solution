using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace PokemonDb.Models
{
    public class Pokemon
    {
        public Pokemon()
        {
            this.PokeTypes = new HashSet<Pokedex>();
        }
        public int PokemonId { get; set; }
        public string PokemonDescription { get; set; }
        public string PokemonName { get; set; }
        public string PokemonGender { get; set; }
        public int PokemonLevel { get; set; }
        public ICollection<Pokedex> PokeTypes { get; }

        public void LevelUp()
        {
            this.PokemonLevel += 1;
        }

    }
}
