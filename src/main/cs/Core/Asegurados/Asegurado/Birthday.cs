namespace RI.Novus.Core.Asegurados.Asegurado;

/// <summary>
/// Indicate the birthday of Asegurado
/// </summary>
public sealed class Birthday : AbstractPastOrPresentTimestampPrimitive
{
    /// <summary>Creates a new instance with the system current time as UTC.</summary>
    /// <returns></returns>
    public static Birthday Now()
        => new(new PastOrPresentTimestamp(DateTimeOffset.UtcNow));

    /// <summary>Shortcut for create a created</summary>
    /// <param name="dateTimeOffset"></param>
    /// <returns></returns>
    public static Birthday From(DateTimeOffset dateTimeOffset)
        => new(new PastOrPresentTimestamp(dateTimeOffset));

    private Birthday(PastOrPresentTimestamp rawBirthdayTimestamp) : base(rawBirthdayTimestamp) { }
}
