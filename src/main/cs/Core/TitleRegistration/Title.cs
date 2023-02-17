namespace RI.Novus.Core.TitleRegistration;

/// <summary>
/// Property title (initial dummy class).
/// </summary>
public sealed class Title
{
    private Title(Builder builder)
    {
        Arguments.NotNull(builder, nameof(builder));

        InscriptionDate = builder.InscriptionDateOption.ValueOrFailure();
    }

    /// <summary>
    /// Title inscription date.
    /// </summary>
    public InscriptionDate InscriptionDate { get; }

    /// <summary>
    /// Title's builder.
    /// </summary>
    public sealed class Builder : AbstractEntityBuilder<Title>
    {
        /// <inheritdoc />
        protected override Option<string> AlreadyBuiltErrorMessage => Option.None<string>();

        /// <inheritdoc />
        protected override Option<string> MustBeBuiltErrorMessage => Option.None<string>();

        internal Option<InscriptionDate> InscriptionDateOption { private set; get; }

        /// <inheritdoc />
        protected override Title DoBuild()
        {
            State.IsTrue(InscriptionDateOption.HasValue, "InscriptionDate.Missing");

            return new Title(this);
        }

        /// <summary>
        /// Sets inscription date.
        /// </summary>
        /// <param name="inscriptionDate"></param>
        /// <returns>self</returns>
        public Builder WithInscriptionDate(InscriptionDate inscriptionDate)
            => SetProperty(() => InscriptionDateOption
                = Arguments.NotNull(inscriptionDate, nameof(inscriptionDate)).SomeNotNull());

        private new Builder SetProperty(Action setter) => (Builder)base.SetProperty(setter);
    }
}

/*
    Superficie (mts2): [1 - 12,112] //desde 1 metro hasta 1/4 de la superficie del pais (48,448)
    Fecha de Inscripcion: Fecha en el pasado
    Designacion Catastral: 309389908904 301: regex: "[0-9]{12} {0-9}{3}"

    Done: InscriptionDate
    CadastralDesignation regex: "[0-9]{12} {0-9}{3}"
    Surface (decimal Decimal.Round(decimal d, int decimals)) 
*/
