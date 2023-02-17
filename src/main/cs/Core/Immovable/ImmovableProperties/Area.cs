namespace RI.Novus.Core.Immovable.ImmovableProperties
{

    /// <summary>
    /// Represents Immovable Area
    /// </summary>
    public sealed class Area : ICoreDomainPrimitive<decimal>
    {

#pragma warning disable CA1802 // Use literals where appropriate
        private static readonly decimal MinValue = 0.01M;

        private static readonly decimal MaxValue = 99.999M;

#pragma warning restore CA1802 // Use literals where appropriate

        /// <summary>
        /// Represent a area
        /// </summary>
        /// <param name="area"></param>
        /// <returns>An instance of <see cref="Area"/></returns>
        public static Area From(decimal area) => new(area);

        private Area(decimal rawArea)
            => Value = Arguments.Between(rawArea, MinValue, MaxValue, nameof(rawArea), "Invalid value or format for Immovable area");

        /// <summary>
        /// Gets property value
        /// </summary>
        public decimal Value { get; }

    }
}
