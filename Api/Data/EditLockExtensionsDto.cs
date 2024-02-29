using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class EditLockExtensionsDto
    {
        [JsonPropertyName("extensions")]
        [Required]
        public ICollection<LockExtensionConfigDto> Extensions { get; set; } = new Collection<LockExtensionConfigDto>();

    }

}