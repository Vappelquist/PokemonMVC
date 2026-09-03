using PokemonMVC.Models;
using System.Text.Json.Serialization;

namespace PokemonMVC.Models
{
    public class PokemonModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("weight")]
        public int Weight { get; set; }

        [JsonPropertyName("sprites")]
        public PokemonSprites Sprites { get; set; }

        [JsonPropertyName("types")]
        public List<PokemonType> Types { get; set; }
    }

    public class PokemonSprites
    {
        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; }
    }



    public class PokemonListItem
    {


        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        public int Id
        {
            get
            {
                var segment = Url?.TrimEnd('/').Split('/').LastOrDefault();
                return int.TryParse(segment, out int id) ? id : 0;
            }
        }

        public string SpriteUrl
        {
            get
            {
                var id = Url?.TrimEnd('/').Split('/').LastOrDefault();
                return id != null
                    ? $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{id}.png"
                    : null;
            }
        }
    }
    public class PokemonListResponse
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("results")]
        public List<PokemonListItem>? Results { get; set; }
    }

    public class PokemonType
    {
        [JsonPropertyName("type")]
        public NamedResource? Type { get; set; }
    }
    public class NamedResource
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
