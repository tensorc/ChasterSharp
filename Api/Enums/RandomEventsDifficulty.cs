using System.Runtime.Serialization;

namespace ChasterSharp
{
    public enum RandomEventsDifficulty
    {
        Unknown = -1,
        [EnumMember(Value = "easy")]
        Easy,
        [EnumMember(Value = "normal")]
        Normal,
        [EnumMember(Value = "hard")]
        Hard,
        [EnumMember(Value = "expert")]
        Expert
    }

}