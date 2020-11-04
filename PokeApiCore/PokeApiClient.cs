using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace PokeApiCore
{
    /// <summary>
    /// Client class to consume PokeAPI
    /// https://pokeapi.co/
    /// </summary>
    public class PokeApiClient
    {
        static readonly HttpClient client;

        static PokeApiClient()
        {
            client = new HttpClient();
            // Must end base address with a forward slash
            client.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
            client.DefaultRequestHeaders.Add("User-Agent", "Kevin's PokeAPI");
        }

        /// <summary>
        /// Retrieve Pokemon by Name
        /// </summary>
        /// <exception cref="HttpRequestException"></exception>
        /// <param name="name"></param>
        /// <exception cref="ArgumentException">Thrown when Pokemon is not found</exception>
        /// <returns>Pokemon</returns>
        public async Task<Pokemon> GetPokemonByName(string name)
        {
            name = name.ToLower(); // Pokemon name must be lowercase
            return await GetPokemonByNameOrId(name);
        }

        private static async Task<Pokemon> GetPokemonByNameOrId(string name)
        {
            string url = $"pokemon/{name}";
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Pokemon>(responseBody);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new ArgumentException("{name} does not exist");
            }
            else
            {
                throw new HttpRequestException();
            }
        }

        /// <summary>
        /// Gets a Pokemon by their Pokedex ID Number
        /// </summary>
        /// <param name="id"></param>
        public async Task<Pokemon> GetPokemonById(int id)
        {
            return await GetPokemonByNameOrId(id.ToString());
        }
    }
}
