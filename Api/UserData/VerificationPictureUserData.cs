using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class VerificationPictureUserData
    {

        [JsonPropertyName("requestedAt")]
        public DateTimeOffset? RequestedAt { get; set; }

        [JsonPropertyName("verificationCodeRequired")]
        public bool VerificationCodeRequired { get; set; }

        [JsonPropertyName("currentVerificationCode")]
        public string? CurrentVerificationCode { get; set; }

        [JsonPropertyName("nbVerificationPictures")]
        public int NbVerificationPictures { get; set; }

        //[JsonPropertyName("history")]
        //public ICollection<>? History { get; set; } = new Collection<>();

    }

}
