using System.Runtime.Serialization;

namespace ChasterSharp
{
    public enum ConversationStatus
    {
        Unknown = -1,
        [EnumMember(Value = "pending")]
        Pending = 0,
        [EnumMember(Value = "approved")]
        Approved = 1,
        [EnumMember(Value = "ignored")]
        Ignored = 2
    }

}