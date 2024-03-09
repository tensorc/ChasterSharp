

using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class VerificationPictureFrequencyPenalty : PenaltyBase
    {
        [JsonPropertyName("params")]
        public PenaltyFrequencyParams? Params { get; set; } = new();

        public VerificationPictureFrequencyPenalty()
        {
            Name = PenaltyName.VerificationPictureFrequency;
        }
    }

}