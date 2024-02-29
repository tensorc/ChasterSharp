using System.Runtime.Serialization;

namespace ChasterSharp
{
    public enum LogType
    {
        Unknown = -1,
        [EnumMember(Value = "locked")]
        Locked,
        [EnumMember(Value = "unlocked")]
        Unlocked,
        [EnumMember(Value = "keyholder_trusted")]
        KeyholderTrusted,
        [EnumMember(Value = "session_offer_accepted")]
        SessionOfferAccepted,
        [EnumMember(Value = "max_limit_date_removed")]
        MaxLimitDateRemoved,
        [EnumMember(Value = "max_limit_date_increased")] //Payload
        MaxLimitDateIncreased,
        [EnumMember(Value = "lock_frozen")]
        LockFrozen,
        [EnumMember(Value = "lock_unfrozen")]
        LockUnfrozen,
        [EnumMember(Value = "timer_revealed")]
        TimerHidden,
        [EnumMember(Value = "timer_revealed")]
        TimerRevealed,
        [EnumMember(Value = "time_logs_hidden")]
        TimeLogsHidden,
        [EnumMember(Value = "time_logs_revealed")]
        TimeLogsRevealed,
        [EnumMember(Value = "extension_updated")] //Payload
        ExtensionUpdated,
        [EnumMember(Value = "extension_enabled")] //Payload
        ExtensionEnabled,
        [EnumMember(Value = "extension_disabled")] //Payload
        ExtensionDisabled,
        [EnumMember(Value = "time_changed")] //Payload
        TimeChanged,
        [EnumMember(Value = "link_time_changed")] //Payload
        LinkTimeChanged,
        [EnumMember(Value = "dice_rolled")] //Payload
        DiceRolled,
        [EnumMember(Value = "tasks_task_assigned")] //Payload
        TaskAssigned,
        [EnumMember(Value = "tasks_task_completed")] //Payload
        TaskCompleted,
        [EnumMember(Value = "tasks_task_failed")] //Payload
        TaskFailed,
        [EnumMember(Value = "tasks_vote_ended")] //Payload
        TasksVoteEnded,
        [EnumMember(Value = "temporary_opening_opened")] //Payload
        TemporaryOpeningOpened,
        [EnumMember(Value = "temporary_opening_locked")] //Payload
        TemporaryOpeningLocked,
        [EnumMember(Value = "temporary_opening_locked_late")] //Payload
        TemporaryOpeningLockedLate,
        [EnumMember(Value = "verification_picture_submitted")] //Payload
        VerificationPictureSubmitted,
        [EnumMember(Value = "pillory_in")] //Payload
        PilloryStarted,
        [EnumMember(Value = "pillory_out")] //Payload
        PilloryEnded,
        [EnumMember(Value = "wheel_of_fortune_turned")] //Payload
        WheelOfFortuneTurned
    }

}