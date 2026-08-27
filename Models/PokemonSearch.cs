using System.Text.Json.Serialization;

namespace PokemonMVC.Models
{
    public class PokemonSearch
    {
        [JsonPropertyName("id")]
        public int PokemonId { get; set; }

        [JsonPropertyName("name")]
        public string PokemonName { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("weight")]
        public int weight { get; set; }
        
        


    }
}
