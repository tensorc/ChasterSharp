using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class ChastikeyStatsForPublic
    {
        [JsonPropertyName("_id")]
        [Required(AllowEmptyStrings = true)]
        public string Id { get; set; } = default!;
        [JsonPropertyName("totalLocksManaged")]
        public int TotalLocksManaged { get; set; } = default!;
        [JsonPropertyName("cumulativeSecondsLocked")]
        public int CumulativeSecondsLocked { get; set; } = default!;
        [JsonPropertyName("averageTimeLockedInSeconds")]
        public double AverageTimeLockedInSeconds { get; set; } = default!; //TODO: Should this be an int?
        [JsonPropertyName("longestCompletedLockInSeconds")]
        public int LongestCompletedLockInSeconds { get; set; } = default!;
        [JsonPropertyName("totalNoOfCompletedLocks")]
        public int TotalNoOfCompletedLocks { get; set; } = default!;
        [JsonPropertyName("username")]
        [Required(AllowEmptyStrings = true)]
        public string Username { get; set; } = default!;
        [JsonPropertyName("mainRole")]
        [Required(AllowEmptyStrings = true)]
        public string MainRole { get; set; } = default!;

    }

}