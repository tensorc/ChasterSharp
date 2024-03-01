using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class EditLockExtensionsDto
    {
        [JsonPropertyName("extensions")]
        [Required]
        public List<LockExtensionConfigDto> Extensions { get; set; } = [];

    }

}