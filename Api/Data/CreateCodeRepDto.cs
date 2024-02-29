using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class CreateCodeRepDto
    {
        [JsonPropertyName("combinationId")]
        [Required(AllowEmptyStrings = true)]
        public string CombinationId { get; set; } = default!;

    }

}