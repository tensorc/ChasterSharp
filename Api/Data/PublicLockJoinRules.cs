using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class PublicLockJoinRules
    {
        [JsonPropertyName("canBeJoined")]
        public bool CanBeJoined { get; set; } = default!;
        [JsonPropertyName("containsPremiumExtension")]
        public bool ContainsPremiumExtension { get; set; } = default!;
        [JsonPropertyName("exceedsExtensionLimit")]
        public bool ExceedsExtensionLimit { get; set; } = default!;
        [JsonPropertyName("oneOfExtensionsDisabled")]
        public bool OneOfExtensionsDisabled { get; set; } = default!;

    }

}