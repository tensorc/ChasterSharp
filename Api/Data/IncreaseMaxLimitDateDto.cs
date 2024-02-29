using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class IncreaseMaxLimitDateDto
    {
        /// <summary>
        /// The new maximum limit date
        /// </summary>
        [JsonPropertyName("maxLimitDate")]
        [Required(AllowEmptyStrings = true)]
        public DateTimeOffset MaxLimitDate { get; set; } 
        /// <summary>
        /// Whether the maximum limit date should be disabled
        /// </summary>
        [JsonPropertyName("disableMaxLimitDate")]
        public bool DisableMaxLimitDate { get; set; } 

    }

}