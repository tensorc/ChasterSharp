using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class PenaltiesUserData
    {

        [JsonPropertyName("status")]
        public ICollection<PenaltyUserDataParams>? Status { get; set; } = new Collection<PenaltyUserDataParams>();

    }
}
