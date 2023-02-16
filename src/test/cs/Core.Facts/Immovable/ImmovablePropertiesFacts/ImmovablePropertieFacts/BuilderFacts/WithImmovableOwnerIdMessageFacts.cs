using Optional.Unsafe;
using RI.Novus.Core.Immovable.ImmovableProperties;
using static RI.Novus.Core.Facts.Immovable.ImmovablePropertiesFacts.ImmovablePropertieFacts.CreateBuilderHelper;


namespace RI.Novus.Core.Facts.Immovable.ImmovablePropertiesFacts.ImmovablePropertieFacts.BuilderFacts
{
    internal class WithImmovableOwnerIdMessageFacts : AbstractBuilderRequiredPropertySetterTestFixture<ImmovableProperty.Builder, ImmovableProperty, ImmovableOwnerId>
    {
        protected override Context BuildContext()
        {
            return new Context(
                empty: new ImmovableProperty.Builder(),
                missingTestedProperty: CreateBuilderWithoutImmovableOwnerId(),
                used: CreateUsedBuilder(),
                toSetTwice: CreateBuilderWithoutImmovableOwnerId(),
                firstValue: ImmovableOwnerId.From(Guid.NewGuid()),
                secondValue: ImmovableOwnerId.From(Guid.NewGuid())
            );
        }

        protected override void SetProperty(ImmovableProperty.Builder builder, ImmovableOwnerId value)
            => builder.WithImmovableOwnerId(value);

        protected override ImmovableOwnerId GetProperty(ImmovableProperty buildable) => buildable.ImmovableOwnerId.ValueOrDefault();
    }

}
