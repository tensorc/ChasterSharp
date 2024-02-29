using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class UserPrivateMetadata
    {
        [JsonPropertyName("locktoberPlusModalPending")]
        public bool LocktoberPlusModalPending { get; set; } = default!;

    }

}