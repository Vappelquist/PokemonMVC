using Microsoft.AspNetCore.Mvc;
using PokemonMVC.Services;

namespace PokemonMVC.Controllers
{
    public class PokeListController : Controller
    {
        private readonly IPokemonService _pokeService;
        public PokeListController(IPokemonService pokeService)
        {
            _pokeService = pokeService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _pokeService.GetAllPokemon();
            return View(result);
        }
    }
}
