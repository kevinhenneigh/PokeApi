﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokeAPIWebsite.Models
{
    public class PokemonPokedeEntryViewModel
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public string Height { get; set; }

        public string Weight { get; set; }

        public IEnumerable<string> MoveList { get; set; }
    }
}
