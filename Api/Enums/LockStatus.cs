using System.Runtime.Serialization;

namespace ChasterSharp
{
    public enum LockStatus
    {
        Unknown = -1,
        [EnumMember(Value = "locked")]
        Locked = 0,
        [EnumMember(Value = "unlocked")]
        Unlocked = 1,
        [EnumMember(Value = "deserted")]
        Deserted = 2
    }

}