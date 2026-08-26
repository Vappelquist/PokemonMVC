using System.Text.Json.Serialization;

namespace PokemonMVC.Models
{
    public class PokemonListResponse
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("results")]
        public List<PokemonListItem> Results { get; set; }
    }
    public class PokemonListItem
    {
        [JsonPropertyName ("name")]
        public string Name { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
