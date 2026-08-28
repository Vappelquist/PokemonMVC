namespace PokemonMVC.Models
{
    public class PokeListViewModel
    {
        public PokemonSearch SearchResult { get; set; }
        public PokemonListResponse AllPokemon { get; set; }
        public string Error { get; set; }
    }
}
