using System.Text.Json.Serialization;

namespace ChasterSharp
{

    public sealed class PostsDto
    {
        [JsonPropertyName("limit")]
        public int Limit { get; set; } = 15;

        [JsonPropertyName("lastId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? LastId { get; set; } = default!;
    }
}