using System.Runtime.Serialization;

namespace ChasterSharp
{
    public enum UserRole
    {
        Unknown = -1,
        [EnumMember(Value = "keyholder")]
        Keyholder = 0,
        [EnumMember(Value = "wearer")]
        Wearer = 1,
        [EnumMember(Value = "switch")]
        Switch = 2,
        [EnumMember(Value = "unspecified")]
        Unspecified = 3
    }

}