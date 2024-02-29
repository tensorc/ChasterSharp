using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class LockCreatedRepDto
    {
        /// <summary>
        /// The created lock id
        /// </summary>
        [JsonPropertyName("lockId")]
        [Required(AllowEmptyStrings = true)]
        public string LockId { get; set; } = default!;

    }

}