using System.Runtime.Serialization;

namespace ChasterSharp
{
    public enum ConversationType
    {
        Unknown = -1,
        [EnumMember(Value = "private")]
        Private = 0,
        [EnumMember(Value = "group")]
        Group = 1
    }

}