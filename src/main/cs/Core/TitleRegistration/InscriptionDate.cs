namespace RI.Novus.Core.TitleRegistration;

/// <summary>
/// Title inscription date.
/// </summary>
public sealed class InscriptionDate : IUnwrappableDomainPrimitive<PastOrPresentTimestamp, DateTimeOffset>,
    IEquatable<InscriptionDate>, IComparable<InscriptionDate>
{
    /// <summary>
    /// Validates raw date (that is in the past or the present moment).
    /// </summary>
    /// <param name="rawInscriptionDate"></param>
    public InscriptionDate(PastOrPresentTimestamp rawInscriptionDate)
            => Value = Arguments.NotNull(rawInscriptionDate, nameof(rawInscriptionDate));

    /// <summary>
    /// Tries to create an instance form the raw date.
    /// </summary>
    /// <param name="dateTimeOffset"></param>
    /// <returns></returns>
    public static InscriptionDate From(DateTimeOffset dateTimeOffset)
        => new(new PastOrPresentTimestamp(dateTimeOffset));

    /// <inheritdoc cref="ICoreDomainPrimitive{TRawType}.Value"/>
    public PastOrPresentTimestamp Value { get; }

    /// <inheritdoc cref="IUnwrappableDomainPrimitive{TWrapped,TPrimitive}.AsPrimitive"/>
    public DateTimeOffset AsPrimitive => Value.Value;

    /// <summary>
    /// String representation as ISO 8601 UTC.
    /// </summary>
    /// <returns></returns>
    public override string ToString() => Value.ToISOString();

    /// <summary>
    /// Same as <see cref="Equals(InscriptionDate?)"/> after casting <paramref name="obj"/>.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj) => Equals(obj as InscriptionDate);

    /// <summary>
    /// Checks for equality, first by reference then by value.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(InscriptionDate? other) =>
        RelationalOperatorsOverloadHelper.SelfIsEqualsTo(this, other, o => Value.Equals(o.Value));

    /// <summary>
    /// Categorizes by value.
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode() => Value.GetHashCode();

    /// <summary>
    /// Compares first by reference then by value.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public int CompareTo(InscriptionDate? other) =>
        RelationalOperatorsOverloadHelper.SelfComparedToOther(this, other, o => Value.CompareTo(o.Value));


    #region Relational Operators

    /// <summary>
    /// Indicates if two instances are not equal.
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(InscriptionDate left, InscriptionDate right)
        => RelationalOperatorsOverloadHelper.NotEquals(left, right);

    /// <summary>
    /// Indicates if two instances are equals.
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(InscriptionDate left, InscriptionDate right)
        => RelationalOperatorsOverloadHelper.Equals(left, right);

    /// <summary>
    /// Indicates if <paramref name="left"/> is less than <paramref name="right"/>.
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator <(InscriptionDate left, InscriptionDate right)
        => RelationalOperatorsOverloadHelper.LessThan(left, right);

    /// <summary>
    /// Indicates if <paramref name="left"/> is less than or equals to <paramref name="right"/>.
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator <=(InscriptionDate left, InscriptionDate right)
        => RelationalOperatorsOverloadHelper.LessThanOrEqualsTo(left, right);

    /// <summary>
    /// Indicates if <paramref name="left"/> is greater than <paramref name="right"/>.
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator >(InscriptionDate left, InscriptionDate right)
        => RelationalOperatorsOverloadHelper.GreaterThan(left, right);

    /// <summary>
    /// Indicates if <paramref name="left"/> is greater than or equals to <paramref name="right"/>.
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator >=(InscriptionDate left, InscriptionDate right)
        => RelationalOperatorsOverloadHelper.GreaterThanOrEqualsTo(left, right);

    #endregion //Relational Operators Overload
}
