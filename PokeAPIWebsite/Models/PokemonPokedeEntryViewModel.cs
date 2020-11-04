using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokeAPIWebsite.Models
{
    /// <summary>
    /// Information for a single Pokemon Pokedex
    /// </summary>
    public class PokemonPokedeEntryViewModel
    {
        public string PokedexImageUrl { get; set; }

        public string Name { get; set; }

        public int Id { get; set; }

        public string Height { get; set; }

        public string Weight { get; set; }

        public IEnumerable<string> MoveList { get; set; }
    }
}
