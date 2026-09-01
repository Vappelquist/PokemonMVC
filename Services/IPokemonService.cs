using PokemonMVC.Models;

namespace PokemonMVC.Services
{
    public interface IPokemonService
    {
        Task<PokemonListResponse> GetAllPokemon();
        //Task<PokemonSearch> PokemonSearch(string name);
        Task<List<PokemonListItem>> GetPokemonList(string query);
    }
}
