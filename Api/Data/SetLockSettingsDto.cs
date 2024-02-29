using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class SetLockSettingsDto
    {
        /// <summary>
        /// Whether the remaining time is displayed to the wearer
        /// </summary>
        [JsonPropertyName("displayRemainingTime")]
        public bool? DisplayRemainingTime { get; set; } 
        /// <summary>
        /// Whether the time information should be hidden from the history
        /// </summary>
        [JsonPropertyName("hideTimeLogs")]
        public bool? HideTimeLogs { get; set; } 

    }

}