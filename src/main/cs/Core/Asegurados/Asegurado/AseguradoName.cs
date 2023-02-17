using System.Linq;


namespace RI.Novus.Core.Asegurados.Asegurado;

/// <summary>
/// Indicate the name of asegurado
/// </summary>
public sealed class AseguradoName : AbstractSimpleStringValue
{
    /// <summary>Minimum allowed length.</summary>
    public const int MinLength = 4;

    /// <summary>Maximum allowed length. </summary>
    public const int MaxLength = 128;

    private static readonly Message _genericMessage = new("Invalid Asegurado Name.");

    private static readonly StringLengthRange _lengthRange =
        new(new StringLength(MinLength), new StringLength(MaxLength));

    /// <summary>Shortcut for constructor.</summary>
    /// <param name="rawAseguradoName"></param>
    /// <returns></returns>
    public static AseguradoName From(string rawAseguradoName) => new(rawAseguradoName);

    /// <summary>Builds instances of this class, applies all known validations to raw title.</summary>
    /// <param name="rawAseguradoName"></param>
    private AseguradoName(string rawAseguradoName)
    {
        var builder = new ConfigurableString.Builder(_genericMessage, useSingleMessage: true)
            .WithRequiresTrimmed(true)
            .WithComparisonStrategy(StringComparison.OrdinalIgnoreCase)
            .WithLengthRange(_lengthRange, _genericMessage, _genericMessage);

        InnerValue = builder.Build(rawAseguradoName, rn =>
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
