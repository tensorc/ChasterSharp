using System.Runtime.Serialization;

namespace ChasterSharp
{
    public enum MessageForPublicType
    {
        Unknown = -1,
        [EnumMember(Value = "message")]
        Message = 0,
        [EnumMember(Value = "log")]
        Log = 1
    }

}