namespace Domain.Enums
{
    public enum ApplicationTypeId
    {
        NewLocalLicense = 1,
        RenewLicense = 2,
        ReplaceLostLicense = 3,
        ReplaceDamagedLicense = 4,
        ReleaseDetainedLicense = 5,
        NewInternationalLicense = 6,
        RetakeTest = 7
    }

    public enum ApplicationStatus
    {
        New = 1,
        Cancelled = 2,
        Completed = 3
    }

    public enum IssueReason
    {
        FirstTime = 1,
        Renew = 2,
        ReplacementForDamaged = 3,
        ReplacementForLost = 4
    }

    public enum TestTypeId
    {
        Vision = 1,
        Written = 2,
        Street = 3
    }
}
