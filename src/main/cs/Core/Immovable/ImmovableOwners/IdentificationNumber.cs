using System.Linq;

namespace RI.Novus.Core.Immovable.ImmovableOwners
{

    /// <summary>
    /// Indicate the identification number of Immovable Owner
    /// </summary>
    public sealed class IdentificationNumber : AbstractSimpleStringValue
    {
        /// <summary>Minimum allowed length.</summary>
        public const int MinLength = 4;

        /// <summary>Maximum allowed length. </summary>
        public const int MaxLength = 25;

        private static readonly Message _genericMessage = new("Invalid Identification Number.");

        private static readonly StringLengthRange _lengthRange =
            new(new StringLength(MinLength), new StringLength(MaxLength));

        /// <summary>Shortcut for constructor.</summary>
        /// <param name="rawIdentificationNumber"></param>
        /// <returns></returns>
        public static IdentificationNumber From(string rawIdentificationNumber) => new(rawIdentificationNumber);

        /// <summary>Builds instances of this class, applies all known validations to raw title.</summary>
        /// <param name="rawIdentificationNumber"></param>
        private IdentificationNumber(string rawIdentificationNumber)
        {
            var builder = new ConfigurableString.Builder(_genericMessage, useSingleMessage: true)
                .WithRequiresTrimmed(true)
                .WithComparisonStrategy(StringComparison.OrdinalIgnoreCase)
                .WithLengthRange(_lengthRange, _genericMessage, _genericMessage);

            InnerValue = builder.Build(rawIdentificationNumber, rn =>
            {
                bool hasSomeControlCharacter = rn.Any(char.IsControl);
                if (hasSomeControlCharacter)
                {
                    throw new FormatException(_genericMessage.Value);
                }
            });
        }

        /// <summary>Represents the inner value</summary>
        protected override ConfigurableString InnerValue { get; }
    
    }
}
