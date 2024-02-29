


using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class VerificationPictureConfig
    {
        [JsonPropertyName("visibility")]
        [JsonConverter(typeof(CustomStringEnumConverter<VerificationPictureVisibility>))]
        public VerificationPictureVisibility Visibility { get; set; }

        [JsonPropertyName("peerVerification")]
        public VerificationPictureConfigParams? PeerVerification { get; set; } = new();
    }

}