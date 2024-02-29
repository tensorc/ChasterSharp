using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class PeriodDetailsDto
    {
        [JsonPropertyName("date")]
        [Required(AllowEmptyStrings = true)]
        public DateTimeOffset Date { get; set; } 

    }

}