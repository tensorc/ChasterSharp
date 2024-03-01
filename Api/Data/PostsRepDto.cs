
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class PostsRepDto
    {
        [JsonPropertyName("count")]
        public int Count { get; set; } = 15;

        [JsonPropertyName("hasMore")]
        public bool HasMore { get; set; }

        [JsonPropertyName("results")]
        public List<UserPostForPublic> Results { get; set; } = [];
    }

}