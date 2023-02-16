using RI.Novus.Core.Boundaries.Persistence;

namespace RI.Novus.Core.CadastralSurvey.Expedients
{
    /// <summary>
    /// Expedient (initial dummy class).
    /// </summary>
    public sealed class Expedient
    {
        private Expedient(Builder builder)
        {
            Arguments.NotNull(builder, nameof(builder));

            ExpedientName = builder.ExpedientNameOption.ValueOrFailure();
            AuthorName = builder.AuthorNameOption;

        }

        /// <summary>
        /// Expedient's name
        /// </summary>
        public ExpedientName ExpedientName { get; }

        /// <summary>
        /// Expedient's author name
        /// </summary>
        public Option<AuthorName> AuthorName { get; }

        /// <summary>
        /// Persists entity.
        /// </summary>
        /// <param name="expedientRepositoryDummy">An implementation of <see cref="IExpedientRepositoryDummy"/></param>
        public void Persist(IExpedientRepositoryDummy expedientRepositoryDummy)
        {
            Arguments.NotNull(expedientRepositoryDummy, nameof(expedientRepositoryDummy));
           
            expedientRepositoryDummy.Save(this);
        }

        public void Update(IExpedientRepositoryDummy expedientRepositoryDummy)
        {
            Arguments.NotNull(expedientRepositoryDummy, nameof(expedientRepositoryDummy));

            expedientRepositoryDummy.Save(this);
        }

        /// <summary>
        /// Expedient's builder.
        /// </summary>
        public sealed class Builder : AbstractEntityBuilder<Expedient>
        {
            /// <inheritdoc />
            protected override Option<string> AlreadyBuiltErrorMessage => Option.None<string>();

            /// <inheritdoc />
            protected override Option<string> MustBeBuiltErrorMessage => Option.None<string>();

            internal Option<ExpedientName> ExpedientNameOption { private set; get; }

            internal Option<AuthorName> AuthorNameOption { private set; get; }

            /// <inheritdoc />
            protected override Expedient DoBuild()
            {
                State.IsTrue(ExpedientNameOption.HasValue, "ExpedientName.Missing");

                return new Expedient(this);
            }

            /// <summary>
            /// Sets ExpedientName.
            /// </summary>
            /// <param name="expedientName"></param>
            /// <returns>self</returns>
            public Builder WithExpedientName(ExpedientName expedientName)
                => SetProperty(() => ExpedientNameOption
                    = Arguments.NotNull(expedientName, nameof(expedientName)).SomeNotNull());            
            
            /// <summary>
            /// Sets ExpedientName.
            /// </summary>
            /// <param name="authorName"></param>
            /// <returns>self</returns>
            public Builder WithAuthorName(AuthorName authorName)
                => SetProperty(() => AuthorNameOption
                    = Arguments.NotNull(authorName, nameof(authorName)).SomeNotNull());

            private new Builder SetProperty(Action setter) => (Builder)base.SetProperty(setter);
        }

    }
}
