namespace RI.Novus.Core.Immovable.ImmovableProperties
{

    /// <summary>
    /// Represents Immovable Surface
    /// </summary>
    public sealed class Surface : ICoreDomainPrimitive<decimal>
    {

#pragma warning disable CA1802 // Use literals where appropriate
        private static readonly decimal MinValue = 0.01M;

        private static readonly decimal MaxValue = 99.999M;

#pragma warning restore CA1802 // Use literals where appropriate

        /// <summary>
        /// Represent a surface
        /// </summary>
        /// <param name="surface"></param>
        /// <returns>An instance of <see cref="Surface"/></returns>
        public static Surface From(decimal surface) => new(surface);

        private Surface(decimal rawSurface)
            => Value = Arguments.Between(rawSurface, MinValue, MaxValue, nameof(rawSurface), "Invalid value or format for Immovable surface");

        /// <summary>
        /// Gets property value
        /// </summary>
        public decimal Value { get; }

    }
}
