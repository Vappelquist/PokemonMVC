using PokemonMVC.Models;
using System.Text.Json;

namespace PokemonMVC.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly HttpClient _httpClient;

        public PokemonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<PokemonListResponse> GetAllPokemon()
        {
            try
            {
                var response = await _httpClient.GetAsync("?limit=100000");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<PokemonListResponse>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        //public async Task<PokemonSearch> PokemonSearch(string name)
        //{
        //    var url = name;
        //    try
        //    {
        //        var response = await _httpClient.GetAsync(url);
        //        response.EnsureSuccessStatusCode();

        //        var json = await response.Content.ReadAsStringAsync();
        //        var data = JsonSerializer.Deserialize<PokemonSearch>(json);

        //        return data;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex);
        //        return null;
        //    }
        //}

        public async Task<List<PokemonListItem>> GetPokemonList(string query)
        {
            var all = await GetAllPokemon();
            if (all.Results == null)
            {
                return new List<PokemonListItem>();
            }
            return all.Results
                .Where (p => p.Name.Contains (query, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
        
        public async Task <PokemonSearch> GetPokemonById(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{id}/");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<PokemonSearch>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
