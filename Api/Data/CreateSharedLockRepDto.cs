using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class CreateSharedLockRepDto
    {
        /// <summary>
        /// The created shared lock id
        /// </summary>
        [JsonPropertyName("id")]
        [Required(AllowEmptyStrings = true)]
        public string Id { get; set; } = default!;

    }

}