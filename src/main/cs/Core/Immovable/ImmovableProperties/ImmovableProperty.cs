using RI.Novus.Core.Boundaries.Persistence;

namespace RI.Novus.Core.Immovable.ImmovableProperties
{

    /// <summary>
    /// Immovable Property Entity
    /// </summary>
    public sealed class ImmovableProperty
    {
        public ImmovableProperty(Builder builder)
        {
            Arguments.NotNull(builder, nameof(builder));

            Id = builder.IdOption.ValueOr(Id.Generate());
            Area = builder.AreaOption;
            Region = builder.RegionOption;
            Surface = builder.SurfaceOption.ValueOrFailure();
            Type = builder.TypeOption.ValueOrFailure();
            ImmovableOwnerId = builder.ImmovableOwnerIdOption.ValueOrFailure();

        }


        /// <summary>Immovable Property ID</summary>
        public Id Id { get; }

        /// <summary>Areas</summary>
        public Option<Area> Area { get; }

        /// <summary>Region</summary>
        public Option<Region> Region { get; }

        /// <summary>Surface</summary>
        public Surface Surface { get; }

        /// <summary>Immovable Owner Id</summary>
        public Guid ImmovableOwnerId { get; }

        /// <summary>
        /// Type
        /// </summary>

        public Type Type { get; }

        public void DeleteProperty(IImmovablePropertyRepository immovablePropertyRepository, Guid id)
        {
            Arguments.NotNull(immovablePropertyRepository, nameof(immovablePropertyRepository));

            immovablePropertyRepository.DeleteProperty(id);
        }




        /// <summary>
        /// Immovable Property Builder
        /// </summary>
        public sealed class Builder : AbstractEntityBuilder<ImmovableProperty>
        {
            /// <inheritdoc />
            protected override Option<string> AlreadyBuiltErrorMessage => Option.None<string>();

            /// <inheritdoc />
            protected override Option<string> MustBeBuiltErrorMessage => Option.None<string>();

            internal Option<Area> AreaOption { private set; get; }
            internal Option<Region> RegionOption { private set; get; }
            internal Option<Surface> SurfaceOption { private set; get; }
            internal Option<Type> TypeOption { private set; get; }
            internal Option<Id> IdOption { private set; get; }
            internal Option<Guid> ImmovableOwnerIdOption { private set; get; }



            /// <inheritdoc />
            protected override ImmovableProperty DoBuild()
            {
                State.IsTrue(SurfaceOption.HasValue, nameof(SurfaceOption));
                State.IsTrue(TypeOption.HasValue, nameof(TypeOption));


                return new ImmovableProperty(this);
            }

            /// <summary>Adds a valid ID</summary>
            /// <param name="id"></param>
            /// <returns></returns>
            public Builder WithId(Id id)
                => SetProperty(() => IdOption = Arguments.NotNull(id, nameof(id)).SomeNotNull());

            /// <summary>Adds a valid Region</summary>
            /// <param name="region"></param>
            /// <returns></returns>
            public Builder WithRegion(Region region)
                => SetProperty(() =>
                    RegionOption = region.Some());


            /// <summary>Adds a valid Surface</summary>
            /// <param name="surface"></param>
            /// <returns></returns>
            public Builder WithSurface(Surface surface)
                => SetProperty(() => SurfaceOption = Arguments.NotNull(surface, nameof(surface)).SomeNotNull());

            /// <summary>Adds a valid Area</summary>
            /// <param name="area"></param>
            /// <returns></returns>
            public Builder WithArea(Area area)
                => SetProperty(() => AreaOption = area.Some());

            /// <summary>Adds a valid immovableOwnerId</summary>
            /// <param name="immovableOwnerId"></param>
            /// <returns></returns>
            public Builder WithImmovableOwnerId(Guid immovableOwnerId)
                => SetProperty(() => ImmovableOwnerIdOption = immovableOwnerId.Some());

            /// <summary>Adds a valid Type</summary>
            /// <param name="type"></param>
            /// <returns></returns>
            public Builder WithType(Type type)
               => SetProperty(() => TypeOption = Arguments.ValidEnumerationMember(type, nameof(type)).SomeNotNull());
            private new Builder SetProperty(Action setter) => (Builder)base.SetProperty(setter);
        }
    }
}
