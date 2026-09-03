using Microsoft.AspNetCore.Mvc;
using PokemonMVC.Models;
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
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var vm = new PokeListViewModel()
            {
                AllPokemon = await _pokeService.GetAllPokemon()
            };
            return View(vm);
        }


        [HttpPost]
        public async Task<IActionResult> Index(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                var vm = new PokeListViewModel()
                {
                    Error = "Enter a pokémon name.",
                    AllPokemon = await _pokeService.GetAllPokemon()
                };
                return View(vm);
            }
            var filtered = await _pokeService.GetPokemonList(name);
            var vmFiltered = new PokeListViewModel()
            {
                AllPokemon = new PokemonListResponse
                {
                    Count = filtered.Count,
                    Results = filtered
                }
            };
            return View(vmFiltered);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var pokemon = await _pokeService.GetPokemonById(id);
            if (pokemon == null)
            {
                return NotFound();
            }
            else
            {
                return View(pokemon);
            }
        }
    }
}

