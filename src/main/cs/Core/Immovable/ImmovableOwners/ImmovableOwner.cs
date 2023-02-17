using RI.Novus.Core.Boundaries.Persistence;
using RI.Novus.Core.Immovable.ImmovableProperties;
using System.Collections.Generic;

namespace RI.Novus.Core.Immovable.ImmovableOwners
{
    public sealed class ImmovableOwner
    {

        private ImmovableOwner(Builder builder)
        {
            Arguments.NotNull(builder, nameof(builder));

            Id = builder.IdOption.ValueOr(Id.Generate());
            Codia = builder.CodiaOption.ValueOrFailure();
            Name = builder.NameOption.ValueOrFailure();
            IdentificationNumber = builder.IdentificationNumberOption.ValueOrFailure();
            CreationDate = builder.CreationDateOption.ValueOrFailure();
            ImmovableProperties = builder.ImmovablePropertiesOption.ValueOrFailure();


        }


        /// <summary>Asegurado ID</summary>
        public Id Id { get; }

        /// <summary>Immovable Codia</summary>
        public Codia Codia { get; }

        /// <summary> Name</summary>
        public Name Name { get; }

        /// <summary>List of immovable property</summary>
        public IEnumerable<ImmovableProperty> ImmovableProperties { get; }

        /// <summary>Immovable Identification Number</summary>
        public IdentificationNumber IdentificationNumber { get; }

        /// <summary>Immovable creation Date</summary>
        public CreationDate CreationDate { get; }



        /// <summary>
        /// Immovable Builder
        /// </summary>
        public sealed class Builder : AbstractEntityBuilder<ImmovableOwner>
        {
            /// <inheritdoc />
            protected override Option<string> AlreadyBuiltErrorMessage => Option.None<string>();

            /// <inheritdoc />
            protected override Option<string> MustBeBuiltErrorMessage => Option.None<string>();

            internal Option<Codia> CodiaOption { get; private set; }
            internal Option<Name> NameOption { get; private set; }
            internal Option<IdentificationNumber> IdentificationNumberOption { get; set; }
            internal Option<CreationDate> CreationDateOption { get; set; }
            internal Option<Id> IdOption { get; private set; }
            internal Option<IEnumerable<ImmovableProperty>> ImmovablePropertiesOption { get; private set; }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            
            protected override ImmovableOwner DoBuild()
            {
                State.IsTrue(CodiaOption.HasValue, nameof(CodiaOption));
                State.IsTrue(NameOption.HasValue, nameof(NameOption));
                State.IsTrue(IdentificationNumberOption.HasValue, nameof(IdentificationNumberOption));
                State.IsTrue(ImmovablePropertiesOption.HasValue, nameof(ImmovablePropertiesOption));
                State.IsTrue(CreationDateOption.HasValue, nameof(CreationDateOption));

                return new ImmovableOwner(this);
            }

            /// <summary>Adds a valid ID</summary>
            /// <param name="id"></param>
            /// <returns></returns>
            public Builder WithId(Id id)
                => SetProperty(() => IdOption = Arguments.NotNull(id, nameof(id)).SomeNotNull());

            /// <summary>Adds a valid Description</summary>
            /// <param name="codia"></param>
            /// <returns></returns>
            public Builder WithCodia(Codia codia)
                => SetProperty(() =>
                    CodiaOption = Arguments.NotNull(codia, nameof(codia)).SomeNotNull());


            /// <summary>Adds a valid created on date</summary>
            /// <param name="creationDate"></param>
            /// <returns></returns>
            public Builder WithCreationDate(CreationDate creationDate)
                => SetProperty(() => CreationDateOption = Arguments.NotNull(creationDate, nameof(creationDate)).SomeNotNull());

            /// <summary>Adds a valid title</summary>
            /// <param name="name"></param>
            /// <returns></returns>
            public Builder WithName(Name name)
                => SetProperty(() => NameOption = Arguments.NotNull(name, nameof(name)).SomeNotNull());

            /// <summary>Adds a valid modification date</summary>
            /// <param name="identificationNumber"></param>
            /// <returns></returns>
            public Builder WithIdentificationNumber(IdentificationNumber identificationNumber)
                => SetProperty(() => IdentificationNumberOption = Arguments.NotNull(identificationNumber, nameof(identificationNumber)).SomeNotNull());

            /// <summary>Adds a valid modification date</summary>
            /// <param name="immovableProperties"></param>
            /// <returns></returns>
            public Builder WithList(IEnumerable<ImmovableProperty> immovableProperties)
               => SetProperty(() => ImmovablePropertiesOption = Arguments.NotNull(immovableProperties, nameof(immovableProperties)).SomeNotNull());
            private new Builder SetProperty(Action setter) => (Builder)base.SetProperty(setter);
        }

        /// <summary>
        /// Persists entity
        /// </summary>
        /// <param name="immovableOwnerRepository"> an implementation of <see cref="IImmovableOwnersRepository"/></param>


        public void Persist(IImmovableOwnersRepository immovableOwnerRepository)
        {

            Arguments.NotNull(immovableOwnerRepository, nameof(immovableOwnerRepository));
            immovableOwnerRepository.SaveImmovableOwner(this);
        }

        public void DeleteProperty(IImmovablePropertyRepository immovablePropertyRepository, Guid id)
        {
            Arguments.NotNull(immovablePropertyRepository, nameof(immovablePropertyRepository));

            immovablePropertyRepository.DeleteProperty(id);
        }

        public void Update(IImmovablePropertyRepository immovablePropertyRepository, Guid propertyId, ImmovableProperty property)
        {
            Arguments.NotNull(immovablePropertyRepository, nameof(immovablePropertyRepository));
            immovablePropertyRepository.UpdateRepository(this, propertyId, property);

        }
    }
}
