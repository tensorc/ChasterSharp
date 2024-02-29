using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class WheelOfFortuneConfig
    {
        [JsonPropertyName("segments")]
        public ICollection<WheelOfFortuneSegment> Segments { get; set; } = new Collection<WheelOfFortuneSegment>();

    }

}