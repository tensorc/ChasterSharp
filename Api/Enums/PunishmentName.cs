using System.Runtime.Serialization;

namespace ChasterSharp
{
    public enum PunishmentName
    {
        Unknown = -1,
        [EnumMember(Value = "freeze")]
        Freeze,
        [EnumMember(Value = "pillory")]
        Pillory,
        [EnumMember(Value = "add_time")]
        AddTime
    }

}