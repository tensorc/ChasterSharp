using System.Runtime.Serialization;

namespace ChasterSharp
{
    public enum SetConversationStatusDtoStatus
    {
        Unknown = -1,
        [EnumMember(Value = "approved")]
        Approved = 0,
        [EnumMember(Value = "ignored")]
        Ignored = 1
    }

}