using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class PenaltyTimeLimitParams
    {
        [JsonPropertyName("timeLimit")]
        public int TimeLimit { get; set; }

    }

}