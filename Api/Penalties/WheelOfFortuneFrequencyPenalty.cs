

using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class WheelOfFortuneFrequencyPenalty : PenaltyBase
    {
        [JsonPropertyName("params")]
        public PenaltyFrequencyParams? Params { get; set; } = new();

        public WheelOfFortuneFrequencyPenalty()
        {
            Name = PenaltyName.WheelOfFortuneTurns;
        }
    }

}