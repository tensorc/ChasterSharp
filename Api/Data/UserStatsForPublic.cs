using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class UserStatsForPublic
    {
        /// <summary>
        /// Number of locks started by the user as a wearer
        /// </summary>
        [JsonPropertyName("nbStartedLocks")]
        public int NbStartedLocks { get; set; } = default!;
        /// <summary>
        /// Number of locks ended by the user as a wearer
        /// </summary>
        [JsonPropertyName("nbEndedLocks")]
        public int NbEndedLocks { get; set; } = default!;
        /// <summary>
        /// Total time locked
        /// </summary>
        [JsonPropertyName("totalTimeLocked")]
        public int TotalTimeLocked { get; set; } = default!;
        /// <summary>
        /// Maximum session duration
        /// </summary>
        [JsonPropertyName("maxTimeLocked")]
        public int MaxTimeLocked { get; set; } = default!;
        /// <summary>
        /// Number of locks keyholded
        /// </summary>
        [JsonPropertyName("keyholderNbLocks")]
        public int KeyholderNbLocks { get; set; } = default!;

    }

}