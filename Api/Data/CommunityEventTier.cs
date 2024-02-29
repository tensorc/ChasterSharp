using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class CommunityEventTier
    {
        [JsonPropertyName("name")]
        [Required(AllowEmptyStrings = true)]
        public string Name { get; set; } = default!;
        [JsonPropertyName("requiredPoints")]
        public int RequiredPoints { get; set; } = default!;

    }

}