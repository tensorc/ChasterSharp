
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class PenaltiesUserData
    {

        [JsonPropertyName("status")]
        public List<PenaltyUserDataParams>? Status { get; set; } = default;

    }
}
