using System.Runtime.Serialization;

namespace ChasterSharp
{
    public enum ActionLogForPublicRole
    {
        Unknown = -1,
        [EnumMember(Value = "user")]
        User = 0,
        [EnumMember(Value = "keyholder")]
        Keyholder = 1,
        [EnumMember(Value = "extension")]
        Extension = 2,
        [EnumMember(Value = "admin")]
        Admin = 3
    }

}