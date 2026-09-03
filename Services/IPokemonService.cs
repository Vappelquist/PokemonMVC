using PokemonMVC.Models;

namespace PokemonMVC.Services
{
    public interface IPokemonService
    {
        Task<PokemonListResponse> GetAllPokemon();
        Task<List<PokemonListItem>> GetPokemonList(string query);
        Task<PokemonModel> GetPokemonById(int id);

    }
}
