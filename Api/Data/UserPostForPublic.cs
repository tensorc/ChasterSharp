using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class UserPostForPublic
    {
        [JsonPropertyName("_id")]
        [Required(AllowEmptyStrings = true)]
        public string Id { get; set; } = default!;

        [JsonPropertyName("content")]
        [Required(AllowEmptyStrings = true)]
        public string? Content { get; set; } = default!;

        [JsonPropertyName("expiresAt")]
        public DateTimeOffset ExpiresAt { get; set; } = default!;

        [JsonPropertyName("lock")]
        public LockForPublic Lock { get; set; } = new();

        [JsonPropertyName("extensionParty")]
        public ExtensionPartyForPublic ExtensionParty { get; set; } = new();

        [JsonPropertyName("type")]
        public string Type { get; set; } = default!;

        [JsonPropertyName("payload")]
        public JsonElement Payload { get; set; } = default!;

        [JsonPropertyName("archivedAt")]
        public DateTimeOffset? ArchivedAt { get; set; } = default!;

        [JsonPropertyName("createdAt")]
        public DateTimeOffset CreatedAt { get; set; } = default!;

        [JsonPropertyName("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; } = default!;

        [JsonPropertyName("user")]
        public UserForPublic User { get; set; } = new();

        [JsonPropertyName("actionText")]
        [Required(AllowEmptyStrings = true)]
        public string? ActionText { get; set; } = default!;

        [JsonPropertyName("data")]
        public JsonElement Data { get; set; } = default!;

    }

}