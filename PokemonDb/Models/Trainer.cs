using System.Collections.Generic;

namespace PokemonDb.Models
{
    public class Trainer
    {
        public Trainer()
        {
            this.Pokemons = new HashSet<Pokemon>();
        }

        public int TrainerId { get; set; }
        public string TrainerName { get; set; }
        public virtual ICollection<Pokemon> Pokemons { get; set; }
    }
}