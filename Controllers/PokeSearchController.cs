//using Microsoft.AspNetCore.Mvc;
//using PokemonMVC.Services;

//namespace PokemonMVC.Controllers
//{
//    public class PokeSearchController : Controller
//    {
//        private readonly IPokemonService _pokemonService;
//        public PokeSearchController(IPokemonService pokeService)
//        {
//            _pokemonService = pokeService;
//        }
//        public IActionResult Index()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> Index(string name)
//        {
//            if (string.IsNullOrWhiteSpace(name))
//            {
//                ViewBag.Error = "Enter a Pokémon name.";
//                return View();
//            }
//            var result = await _pokemonService.PokemonSearch(name);
//            if (result ==  null)
//            {
//                ViewBag.Error = $"No Pokemon found for \"{name}\"";
//            }
//            return View(result);

//        }
//    }
//}
