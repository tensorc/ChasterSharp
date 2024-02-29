using System.Runtime.Serialization;

namespace ChasterSharp
{
    public enum ReportType
    {
        Unknown = -1,
        [EnumMember(Value = "message")]
        Message = 0,
        [EnumMember(Value = "post")]
        Post = 1,
        [EnumMember(Value = "shared_lock")]
        SharedLock = 2,
        [EnumMember(Value = "user")]
        User = 3
    }

}