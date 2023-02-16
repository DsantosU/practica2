namespace RI.Novus.Core.Immovable.ImmovableOwners
{

    /// <summary>
    /// Indicate Id for Immovable Owners
    /// </summary>
    public sealed class Id : AbstractGuidBasedIdPrimitive
    {
        /// <summary>Creates a new instance with a random <see cref="Guid"/>.</summary>
        /// <returns></returns>
        public static Id Generate() => new(Guid.NewGuid());

        /// <summary>
        /// Builds an id or throws an exception
        /// </summary>
        /// <param name="rawValue"></param>
        public static Id From(Guid rawValue) => new(rawValue);

        private Id(Guid rawValue) : base(rawValue)
        {
        }
    }
}
