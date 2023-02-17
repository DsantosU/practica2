using RI.Novus.Core.Boundaries.Persistence;

namespace RI.Novus.Core.Asegurados.Asegurado;

/// <summary>
/// Asegurado Entity
/// </summary>
public sealed class Asegurado
{
    private Asegurado(Builder builder)
    {
        Arguments.NotNull(builder, nameof(builder));

        Id = builder.IdOption;
        Age = builder.AgeOption.ValueOrFailure();
        AseguradoName = builder.AseguradoNameOption.ValueOrFailure();
        IdentificationNumber = builder.IdentificationNumberOption.ValueOrFailure();
        Birthday = builder.BirthdayOption.ValueOrFailure();

    }


    /// <summary>Asegurado ID</summary>
    public Option<Id> Id { get; }

    /// <summary>Asegurado age</summary>
    public Age Age { get; }

    /// <summary>Asegurado Name</summary>
    public AseguradoName AseguradoName { get; }

    /// <summary>Asegurado Identification Number</summary>
    public IdentificationNumber IdentificationNumber { get; }

    /// <summary>Asegurado Birthday</summary>
    public Birthday Birthday { get; }



    /// <summary>
    /// Asegurado Builder
    /// </summary>
    public sealed class Builder : AbstractEntityBuilder<Asegurado>
    {
        /// <inheritdoc />
        protected override Option<string> AlreadyBuiltErrorMessage => Option.None<string>();

        /// <inheritdoc />
        protected override Option<string> MustBeBuiltErrorMessage => Option.None<string>();

        internal Option<Age> AgeOption { get; private set; }
        internal Option<AseguradoName> AseguradoNameOption { get; private set; }
        internal Option<IdentificationNumber> IdentificationNumberOption { get; set; }
        internal Option<Birthday> BirthdayOption { get; set; }
        internal Option<Id> IdOption { get; private set; }


        /// <inheritdoc />
        protected override Asegurado DoBuild()
        {
            State.IsTrue(AgeOption.HasValue, nameof(AgeOption));
            State.IsTrue(AseguradoNameOption.HasValue, nameof(AseguradoNameOption));
            State.IsTrue(IdentificationNumberOption.HasValue, nameof(IdentificationNumberOption));
            State.IsTrue(BirthdayOption.HasValue, nameof(BirthdayOption));


            return new Asegurado(this);
        }

        /// <summary>Adds a valid ID</summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Builder WithId(Id id)
            => SetProperty(() => IdOption = Arguments.NotNull(id, nameof(id)).SomeNotNull());

        /// <summary>Adds a valid Description</summary>
        /// <param name="age"></param>
        /// <returns></returns>
        public Builder WithAge(Age age)
            => SetProperty(() =>
                AgeOption = Arguments.NotNull(age, nameof(age)).SomeNotNull());


        /// <summary>Adds a valid created on date</summary>
        /// <param name="birthday"></param>
        /// <returns></returns>
        public Builder WithBirthday(Birthday birthday)
            => SetProperty(() => BirthdayOption = Arguments.NotNull(birthday, nameof(birthday)).SomeNotNull());

        /// <summary>Adds a valid title</summary>
        /// <param name="aseguradoName"></param>
        /// <returns></returns>
        public Builder WithAseguradoName(AseguradoName aseguradoName)
            => SetProperty(() => AseguradoNameOption = Arguments.NotNull(aseguradoName, nameof(aseguradoName)).SomeNotNull());

        /// <summary>Adds a valid modification date</summary>
        /// <param name="identificationNumber"></param>
        /// <returns></returns>
        public Builder WithIdentificationNumber(IdentificationNumber identificationNumber)
            => SetProperty(() => IdentificationNumberOption = Arguments.NotNull(identificationNumber, nameof(identificationNumber)).SomeNotNull());


        private new Builder SetProperty(Action setter) => (Builder)base.SetProperty(setter);
    }

    /// <summary>
    /// Persists entity
    /// </summary>
    /// <param name="aseguradoRepository"> an implementation of <see cref="IAseguradoRepository"/></param>
    public void Persist(IAseguradoRepository aseguradoRepository)
    {

        Arguments.NotNull(aseguradoRepository, nameof(aseguradoRepository));
        aseguradoRepository.SaveAsegurado(this);
    }

}





