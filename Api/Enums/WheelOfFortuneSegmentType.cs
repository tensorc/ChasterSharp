using System.Runtime.Serialization;

namespace ChasterSharp
{
    public enum WheelOfFortuneSegmentType
    {
        Unknown = -1,
        [EnumMember(Value = "set-freeze")]
        Freeze,
        [EnumMember(Value = "set-unfreeze")]
        Unfreeze,
        [EnumMember(Value = "freeze")]
        ToggleFreeze,
        [EnumMember(Value = "add-time")]
        AddTime,
        [EnumMember(Value = "remove-time")]
        RemoveTime,
        [EnumMember(Value = "add-remove-time")]
        AddRemoveTime,
        [EnumMember(Value = "text")]
        Text,
        [EnumMember(Value = "pillory")]
        Pillory
    }

}