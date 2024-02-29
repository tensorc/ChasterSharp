using System.Runtime.Serialization;

namespace ChasterSharp
{
    public enum UserLockStatus
    {
        Unknown = -1,
        [EnumMember(Value = "active")]
        Active = 0,
        [EnumMember(Value = "archived")]
        Archived = 1,
        [EnumMember(Value = "all")]
        All = 2
    }

}