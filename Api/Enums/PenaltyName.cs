using System.Runtime.Serialization;

namespace ChasterSharp
{
    public enum PenaltyName
    {
        Unknown = -1,
        [EnumMember(Value = "dice_roll")]
        DiceRoll,
        [EnumMember(Value = "temporary_opening_open")]
        TemporaryOpeningOpen,
        [EnumMember(Value = "temporary_opening_time_limit")]
        TemporaryOpeningTimeLimit,
        [EnumMember(Value = "tasks")]
        Tasks,
        [EnumMember(Value = "tasks_do_task")]
        TasksDoTask,
        [EnumMember(Value = "verification_picture_verify")]
        VerificationPictureVerify,
        [EnumMember(Value = "wheel_of_fortune_turns")]
        WheelOfFortuneTurns
    }

}