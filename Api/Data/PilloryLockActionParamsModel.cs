using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class PilloryLockActionParamsModel
    {
        /// <summary>
        /// The pillory duration, in seconds
        /// </summary>
        [JsonPropertyName("duration")]
        [Range(300D, 86400D)]
        public int Duration { get; set; } 
        /// <summary>
        /// The text that will be displayed on the pillory
        /// </summary>
        [JsonPropertyName("reason")]
        public string? Reason { get; set; } 

    }

}