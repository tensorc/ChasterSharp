using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class UserMetadata
    {
        [JsonPropertyName("locktober2020Points")]
        public int Locktober2020Points { get; set; } = default!;
        [JsonPropertyName("locktober2021Points")]
        public int Locktober2021Points { get; set; } = default!;
        [JsonPropertyName("chastityMonth2022Points")]
        public int ChastityMonth2022Points { get; set; } = default!;
        [JsonPropertyName("locktober2022Points")]
        public int Locktober2022Points { get; set; } = default!;
        [JsonPropertyName("locktober2023Points")]
        public int Locktober2023Points { get; set; } = default!;

    }

}