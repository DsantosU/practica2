using Optional.Unsafe;
using RI.Novus.Core.Immovable.ImmovableProperties;
using static RI.Novus.Core.Facts.Immovable.ImmovablePropertiesFacts.ImmovablePropertieFacts.CreateBuilderHelper;

namespace RI.Novus.Core.Facts.Immovable.ImmovablePropertiesFacts.ImmovablePropertieFacts.BuilderFacts;

internal sealed class WithIdMessageFacts : AbstractBuilderRequiredPropertySetterTestFixture<ImmovableProperty.Builder, ImmovableProperty, Id>
{
    protected override Context BuildContext()
    {
        return new Context(
            empty: new ImmovableProperty.Builder(),
            missingTestedProperty: CreateBuilderWithoutId(),
            used: CreateUsedBuilder(),
            toSetTwice: CreateBuilderWithoutId(),
            firstValue: Id.From(Guid.NewGuid()),
            secondValue: Id.From(Guid.NewGuid())
        );
    }

    protected override void SetProperty(ImmovableProperty.Builder builder, Id value)
        => builder.WithId(value);

    protected override Id GetProperty(ImmovableProperty buildable) => buildable.Id;
}
