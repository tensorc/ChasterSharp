using System.Runtime.Serialization;

namespace ChasterSharp
{
    public enum TaskActionStatus
    {
        Unknown = -1,
        [EnumMember(Value = "start")]
        Start = 0,
        [EnumMember(Value = "pending")]
        Pending = 1,
        [EnumMember(Value = "vote")]
        Vote = 2
    }

}