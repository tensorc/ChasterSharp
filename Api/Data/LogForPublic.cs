using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class LogForPublic
    {
        /// <summary>
        /// The action log id
        /// </summary>
        [JsonPropertyName("_id")]
        [Required(AllowEmptyStrings = true)]
        public string Id { get; set; } = default!;
        /// <summary>
        /// The action log type
        /// <br/>When comparing the type, make sure to also compare the prefix
        /// <br/>Read more on https://docs.chaster.app/api/reference/action-logs
        /// </summary>
        [JsonPropertyName("type")]
        [Required(AllowEmptyStrings = true)]
        public string Type { get; set; } = default!;
        /// <summary>
        /// The action log payload
        /// </summary>
        [JsonPropertyName("payload")]
        [Required]
        public JsonElement Payload { get; set; } = default!;
        /// <summary>
        /// The lock id
        /// </summary>
        [JsonPropertyName("lock")]
        [Required(AllowEmptyStrings = true)]
        public string LockId { get; set; } = default!;
        /// <summary>
        /// The role of the user who performed the action
        /// </summary>
        [JsonPropertyName("role")]
        [Required(AllowEmptyStrings = true)]
        [JsonConverter(typeof(CustomStringEnumConverter<ActionLogForPublicRole>))]
        public ActionLogForPublicRole Role { get; set; } = default!;
        /// <summary>
        /// The extension which performed the action
        /// </summary>
        [JsonPropertyName("extension")]
        public string? Extension { get; set; } = default!;
        /// <summary>
        /// The title of the action log
        /// <br/>The title can contain the string '%USER%', which can be replaced with the user's name
        /// </summary>
        [JsonPropertyName("title")]
        [Required(AllowEmptyStrings = true)]
        public string Title { get; set; } = default!;
        /// <summary>
        /// The description of the action log
        /// <br/>The description can contain the string '%USER%', which can be replaced with the user's name
        /// </summary>
        [JsonPropertyName("description")]
        [Required(AllowEmptyStrings = true)]
        public string Description { get; set; } = default!;
        /// <summary>
        /// The color of the action log
        /// </summary>
        [JsonPropertyName("color")]
        public string? Color { get; set; } = default!;
        /// <summary>
        /// Created at
        /// </summary>
        [JsonPropertyName("createdAt")]
        [Required(AllowEmptyStrings = true)]
        public DateTimeOffset CreatedAt { get; set; } = default!;
        /// <summary>
        /// The FontAwesome v5 icon of the action log, with the fa prefix
        /// </summary>
        [JsonPropertyName("icon")]
        public string? Icon { get; set; } = default!;
        /// <summary>
        /// The prefix of the action log
        /// <br/>For common action logs, the prefix is `default`. Action logs created by a partner extension have their own prefix.
        /// </summary>
        [JsonPropertyName("prefix")]
        [Required(AllowEmptyStrings = true)]
        public string Prefix { get; set; } = default!;
        /// <summary>
        /// The user who performed the action
        /// </summary>
        [JsonPropertyName("user")]
        public UserForPublic? User { get; set; } = default!;

        public LogType GetLogType()
        {
            return Prefix == "default" ? (LogType)EnumStringConverter.GetEnumFromMemberValue(typeof(LogType), Type) : LogType.Unknown;
        }

    }

}