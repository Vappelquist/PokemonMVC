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
            var result = await _pokeService.PokemonSearch(name);
            if (result == null)
            {
                var vm = new PokeListViewModel()
                {
                    Error = $"No Pokémon found for \"{name}\"",
                    AllPokemon = await _pokeService.GetAllPokemon()
                };
                return View(vm);
            }

            return View(new PokeListViewModel { SearchResult = result });
                
            }
            

        }
    }

