using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class UpdateTimeDto
    {
        /// <summary>
        /// The duration to add, in seconds
        /// <br/>
        /// <br/>Wearer can only add duration (positive values),
        /// <br/>unlike keyholders who can add or remove time.
        /// </summary>
        [JsonPropertyName("duration")]
        public int Duration { get; set; } 

    }

}