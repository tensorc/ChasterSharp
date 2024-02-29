using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class CombinationForPublic
    {
        /// <summary>
        /// Use imageFullUrl instead
        /// </summary>
        [JsonPropertyName("imageUrl")]
        [Obsolete("This property is obsolete, use ImageFullUrl instead.")]
        public Uri? ImageUrl { get; set; } = default!;
        /// <summary>
        /// The combination id
        /// </summary>
        [JsonPropertyName("_id")]
        [Required(AllowEmptyStrings = true)]
        public string Id { get; set; } = default!;
        /// <summary>
        /// The user id
        /// </summary>
        [JsonPropertyName("user")]
        [Required(AllowEmptyStrings = true)]
        public string User { get; set; } = default!;
        /// <summary>
        /// The review status, if the combination requires a manual review
        /// <br/>from the moderators
        /// </summary>
        [JsonPropertyName("checkStatus")]
        [Required(AllowEmptyStrings = true)]
        [JsonConverter(typeof(CustomStringEnumConverter<CombinationForPublicCheckStatus>))]
        public CombinationForPublicCheckStatus CheckStatus { get; set; } = default!;
        /// <summary>
        /// The combination type
        /// </summary>
        [JsonPropertyName("type")]
        [Required(AllowEmptyStrings = true)]
        [JsonConverter(typeof(CustomStringEnumConverter<CombinationForPublicType>))]
        public CombinationForPublicType Type { get; set; } = default!;
        /// <summary>
        /// The combination code, if the type is `code`
        /// </summary>
        [JsonPropertyName("code")]
        public string? Code { get; set; } = default!;
        /// <summary>
        /// The combination image, if the type is `image`
        /// </summary>
        [JsonPropertyName("imageFullUrl")]
        public Uri? ImageFullUrl { get; set; } = default!;
        /// <summary>
        /// Created at
        /// </summary>
        [JsonPropertyName("createdAt")]
        [Required(AllowEmptyStrings = true)]
        public string CreatedAt { get; set; } = default!;
        /// <summary>
        /// Updated at
        /// </summary>
        [JsonPropertyName("updatedAt")]
        [Required(AllowEmptyStrings = true)]
        public string UpdatedAt { get; set; } = default!;
        /// <summary>
        /// Whether the combination requires a manual review from the moderators
        /// </summary>
        [JsonPropertyName("enableManualCheck")]
        public bool EnableManualCheck { get; set; } = default!;

    }

}