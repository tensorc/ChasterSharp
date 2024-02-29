using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class AppFileForPublic
    {
        /// <summary>
        /// The file URL
        /// </summary>
        [JsonPropertyName("url")]
        [Required(AllowEmptyStrings = true)]
        public Uri? Url { get; set; } = default!;

    }

}