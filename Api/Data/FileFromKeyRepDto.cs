using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class FileFromKeyRepDto
    {
        /// <summary>
        /// The file url
        /// </summary>
        [JsonPropertyName("url")]
        [Required(AllowEmptyStrings = true)]
        public Uri? Url { get; set; } = default!;

    }

}