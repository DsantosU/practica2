namespace RI.Novus.Core.CadastralSurvey.Expedients
{
    /// <summary>
    /// Represents a expedient's name.
    /// </summary>
    public sealed class ExpedientName : ICoreDomainPrimitive<string>,
    IEquatable<ExpedientName>, IComparable<ExpedientName>
    {
        /// <summary>
        /// Minimum allowed length.
        /// </summary>
        public const int MinLength = 4;

        /// <summary>
        /// Maximum allowed length.
        /// </summary>
        public const int MaxLength = 20;

        private readonly ConfigurableString _innerValue;

        /// <summary>
        /// Validates raw expedient name and creates a valid instance or throw exceptions.
        /// </summary>
        /// <param name="rawExpedientName"></param>
        public ExpedientName(string rawExpedientName)
        {
            Message genericMessage = new("Invalid value or format for expedient Name.");
            ConfigurableString.Builder builder = new(genericMessage, useSingleMessage: true);

            StringLengthRange range = new(new StringLength(MinLength), new StringLength(MaxLength));

            builder.WithRequiresTrimmed()
                   .WithLengthRange(range, genericMessage, genericMessage)
                   .WithComparisonStrategy(StringComparison.OrdinalIgnoreCase);

            _innerValue = builder.Build(rawExpedientName);

        }

        /// <inheritdoc cref="ICoreDomainPrimitive{TRawType}.Value"/>
        public string Value => _innerValue.Value;

        /// <summary>
        /// Compare values using <see cref="StringComparison.OrdinalIgnoreCase"/> strategy.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(ExpedientName? other)
            => RelationalOperatorsOverloadHelper.SelfComparedToOther(this, other,
                o => _innerValue.CompareTo(o._innerValue));

        /// <inheritdoc cref="ConfigurableString.Equals(object?)"/>
        public override bool Equals(object? obj)
            => Equals(obj as ExpedientName);

        /// <inheritdoc cref="ConfigurableString.Equals(ConfigurableString?)"/>
        public bool Equals(ExpedientName? other)
            => RelationalOperatorsOverloadHelper.SelfIsEqualsTo(this, other, o => _innerValue.Equals(o._innerValue));

        /// <inheritdoc cref="ConfigurableString.GetHashCode"/>
        public override int GetHashCode() => _innerValue.GetHashCode();

        /// <summary>
        /// Same as <see cref="Value"/>.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Value;

        /// <summary>
        /// Tries to create an instance from the raw name.
        /// </summary>
        /// <param name="expedientName"></param>
        /// <returns></returns>
        public static ExpedientName From(string expedientName)
            => new(expedientName);

        #region Relational Operators

        /// <summary>
        /// Indicates if two instances are not equal.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(ExpedientName left, ExpedientName right)
            => RelationalOperatorsOverloadHelper.NotEquals(left, right);

        /// <summary>
        /// Indicates if two instances are equals.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(ExpedientName left, ExpedientName right)
            => RelationalOperatorsOverloadHelper.Equals(left, right);

        /// <summary>
        /// Indicates if <paramref name="left"/> is less than <paramref name="right"/>.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <(ExpedientName left, ExpedientName right)
            => RelationalOperatorsOverloadHelper.LessThan(left, right);

        /// <summary>
        /// Indicates if <paramref name="left"/> is less than or equals to <paramref name="right"/>.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <=(ExpedientName left, ExpedientName right)
            => RelationalOperatorsOverloadHelper.LessThanOrEqualsTo(left, right);

        /// <summary>
        /// Indicates if <paramref name="left"/> is greater than <paramref name="right"/>.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >(ExpedientName left, ExpedientName right)
            => RelationalOperatorsOverloadHelper.GreaterThan(left, right);

        /// <summary>
        /// Indicates if <paramref name="left"/> is greater than or equals to <paramref name="right"/>.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >=(ExpedientName left, ExpedientName right)
            => RelationalOperatorsOverloadHelper.GreaterThanOrEqualsTo(left, right);

        #endregion //Relational Operators Overload
    }
}