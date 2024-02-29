using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class ReasonPreventingUnlocking
    {
        [JsonPropertyName("reason")]
        [Required(AllowEmptyStrings = true)]
        public string Reason { get; set; } = default!;
        [JsonPropertyName("icon")]
        [Required(AllowEmptyStrings = true)]
        public string Icon { get; set; } = default!;

    }

}