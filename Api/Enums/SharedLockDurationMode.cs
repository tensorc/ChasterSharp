using System.Runtime.Serialization;

namespace ChasterSharp
{
    public enum SharedLockDurationMode
    {
        Unknown = -1,
        [EnumMember(Value = "duration")]
        Duration = 0,
        [EnumMember(Value = "date")]
        Date = 1
    }

}