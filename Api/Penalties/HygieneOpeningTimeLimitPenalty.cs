

using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class HygieneOpeningTimeLimitPenalty : PenaltyBase
    {
        [JsonPropertyName("params")]
        public PenaltyTimeLimitParams? Params { get; set; } = new();

        public HygieneOpeningTimeLimitPenalty()
        {
            Name = PenaltyName.HygieneOpeningTimeLimit;
        }
    }

}