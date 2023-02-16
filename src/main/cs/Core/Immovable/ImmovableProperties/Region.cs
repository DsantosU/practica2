namespace RI.Novus.Core.Immovable.ImmovableProperties
{
    /// <summary>
    /// Represents Immovable Region
    /// </summary>
    public sealed class Region : ICoreDomainPrimitive<decimal>
    {

#pragma warning disable CA1802 // Use literals where appropriate
        private static readonly decimal MinValue = 0.01M;

        private static readonly decimal MaxValue = 99.999M;

#pragma warning restore CA1802 // Use literals where appropriate

        /// <summary>
        /// Represent a region
        /// </summary>
        /// <param name="region"></param>
        /// <returns>An instance of <see cref="Region"/></returns>
        public static Region From(decimal region) => new(region);

        private Region(decimal rawRegion)
            => Value = Arguments.Between(rawRegion, MinValue, MaxValue, nameof(rawRegion), "Invalid value or format for Immovable region");

        /// <summary>
        /// Gets property value
        /// </summary>
        public decimal Value { get; }

    }
}
