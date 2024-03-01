using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class ExtensionCriteriaData
    {
        [JsonPropertyName("extensions")]
        [Required]
        public List<string> Extensions { get; set; } = [];
        [JsonPropertyName("all")]
        public bool All { get; set; } = false;

    }

}