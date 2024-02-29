

using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class RandomEventsConfig
    {
        [JsonPropertyName("difficulty")]
        [JsonConverter(typeof(CustomStringEnumConverter<RandomEventsDifficulty>))]
        public RandomEventsDifficulty Difficulty { get; set; }

    }

}