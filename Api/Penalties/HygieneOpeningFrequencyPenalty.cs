

using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class HygieneOpeningFrequencyPenalty : PenaltyBase
    {
        [JsonPropertyName("params")]
        public PenaltyFrequencyParams? Params { get; set; } = new();

        public HygieneOpeningFrequencyPenalty()
        {
            Name = PenaltyName.TemporaryOpeningOpen;
        }
    }

}