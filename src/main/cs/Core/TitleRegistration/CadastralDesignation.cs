using System.Text.RegularExpressions;

namespace RI.Novus.Core.TitleRegistration;

/// <summary>
/// TBD
/// </summary>
public sealed class CadastralDesignation : ICoreDomainPrimitive<string>,
    IEquatable<CadastralDesignation>, IComparable<CadastralDesignation>
{
    /// <summary>
    /// Minimum allowed length.
    /// </summary>
    public const int MinLength = 16;

    /// <summary>
    /// Maximum allowed length.
    /// </summary>
    public const int MaxLength = 16;

    private static readonly Regex ValidFormatRegex = new("^[0-9]{12} [0-9]{3}$",
        RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);

    private readonly ConfigurableString _innerValue;

    /// <summary>
    /// Validates raw designation and creates a valid instance or throw exceptions.
    /// </summary>
    /// <param name="rawDesignation"></param>
    public CadastralDesignation(string rawDesignation)
    {
        Message genericMessage = new("Invalid value or format for cadastral designation.");
        ConfigurableString.Builder builder = new(genericMessage, useSingleMessage: true);

        StringLengthRange range = new(new StringLength(MinLength), new StringLength(MaxLength));

        builder.WithRequiresTrimmed()
            .WithLengthRange(range, genericMessage, genericMessage)
            .WithValidFormatRegex(ValidFormatRegex)
            .WithComparisonStrategy(StringComparison.OrdinalIgnoreCase);

        _innerValue = builder.Build(rawDesignation);
    }
    
    /// <inheritdoc cref="ICoreDomainPrimitive{TRawType}.Value"/>
    public string Value => _innerValue.Value;

    /// <summary>
    /// Compare values using <see cref="StringComparison.OrdinalIgnoreCase"/> strategy.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public int CompareTo(CadastralDesignation? other)
        => RelationalOperatorsOverloadHelper.SelfComparedToOther(this, other,
            o => _innerValue.CompareTo(o._innerValue));

    /// <inheritdoc cref="ConfigurableString.Equals(object?)"/>
    public override bool Equals(object? obj)
        => Equals(obj as CadastralDesignation);

    /// <inheritdoc cref="ConfigurableString.Equals(ConfigurableString?)"/>
    public bool Equals(CadastralDesignation? other)
        => RelationalOperatorsOverloadHelper.SelfIsEqualsTo(this, other, o => _innerValue.Equals(o._innerValue));

    /// <inheritdoc cref="ConfigurableString.GetHashCode"/>
    public override int GetHashCode() => _innerValue.GetHashCode();

    /// <summary>
    /// Same as <see cref="Value"/>.
    /// </summary>
    /// <returns></returns>
    public override string ToString() => Value;


    #region Relational Operators

    /// <summary>
    /// Indicates if two instances are not equal.
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(CadastralDesignation left, CadastralDesignation right)
        => RelationalOperatorsOverloadHelper.NotEquals(left, right);

    /// <summary>
    /// Indicates if two instances are equals.
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(CadastralDesignation left, CadastralDesignation right)
        => RelationalOperatorsOverloadHelper.Equals(left, right);

    /// <summary>
    /// Indicates if <paramref name="left"/> is less than <paramref name="right"/>.
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator <(CadastralDesignation left, CadastralDesignation right)
        => RelationalOperatorsOverloadHelper.LessThan(left, right);

    /// <summary>
    /// Indicates if <paramref name="left"/> is less than or equals to <paramref name="right"/>.
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator <=(CadastralDesignation left, CadastralDesignation right)
        => RelationalOperatorsOverloadHelper.LessThanOrEqualsTo(left, right);

    /// <summary>
    /// Indicates if <paramref name="left"/> is greater than <paramref name="right"/>.
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator >(CadastralDesignation left, CadastralDesignation right)
        => RelationalOperatorsOverloadHelper.GreaterThan(left, right);

    /// <summary>
    /// Indicates if <paramref name="left"/> is greater than or equals to <paramref name="right"/>.
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator >=(CadastralDesignation left, CadastralDesignation right)
        => RelationalOperatorsOverloadHelper.GreaterThanOrEqualsTo(left, right);

    #endregion //Relational Operators Overload
}
