namespace RI.Novus.Core.Immovable.ImmovableOwners
{

    /// <summary>
    /// Indicates creation date of immovable owner
    /// </summary>
    public sealed class CreationDate : AbstractPastOrPresentTimestampPrimitive
    {
        /// <summary>Creates a new instance with the system current time as UTC.</summary>
        /// <returns></returns>
        public static CreationDate Now()
            => CreationDate.From(DateTimeOffset.UtcNow);

        /// <summary>Shortcut for create a created</summary>
        /// <param name="dateTimeOffset"></param>
        /// <returns></returns>
        public static CreationDate From(DateTimeOffset dateTimeOffset)
            => new(new PastOrPresentTimestamp(dateTimeOffset));

        private CreationDate(PastOrPresentTimestamp rawCreatedTimestamp) : base(rawCreatedTimestamp) { }

    }
}
