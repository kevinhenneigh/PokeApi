using PokeApiCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokeAPIWebsite.Models
{
    public static class PokeAPIHelper
    {
        /// <summary>
        /// Get a Pokemon by Id, moves will be sorted in alphabetical order
        /// </summary>
        /// <param name="desiredId"></param>
        /// <returns>result</returns>
        public static async Task<Pokemon> GetById(int desiredId)
        {
            PokeApiClient myClient = new PokeApiClient();
            Pokemon result = await myClient.GetPokemonById(desiredId);
            
            // Sort moves by name alphabetically
            result.moves.OrderBy(m => m.move.name);

            return result;
        }
    }
}
