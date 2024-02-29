using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class UnsplashPhoto
    {
        [JsonPropertyName("id")]
        [Required(AllowEmptyStrings = true)]
        public string Id { get; set; } = default!;
        [JsonPropertyName("username")]
        [Required(AllowEmptyStrings = true)]
        public string Username { get; set; } = default!;
        [JsonPropertyName("name")]
        [Required(AllowEmptyStrings = true)]
        public string Name { get; set; } = default!;
        [JsonPropertyName("url")]
        [Required(AllowEmptyStrings = true)]
        public Uri? Url { get; set; } = default!;

    }

}