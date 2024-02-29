using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class PeriodDetailsRepDto
    {
        [JsonPropertyName("categories")]
        [Required]
        public IDictionary<string, int> Categories { get; set; } = new Dictionary<string, int>();
        [JsonPropertyName("actions")]
        [Required]
        public IDictionary<string, int> Actions { get; set; } = new Dictionary<string, int>();
        [JsonPropertyName("start")]
        [Required(AllowEmptyStrings = true)]
        public DateTimeOffset Start { get; set; } = default!;
        [JsonPropertyName("end")]
        [Required(AllowEmptyStrings = true)]
        public DateTimeOffset End { get; set; } = default!;

    }

}