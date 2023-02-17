using RI.Novus.Core.Immovable.ImmovableOwners;
using static RI.Novus.Core.Facts.Immovable.ImmovableOwnersFacts.ImmovableOwnerFacts.CreateBuilderHelper;

namespace RI.Novus.Core.Facts.Immovable.ImmovableOwnersFacts.ImmovableOwnerFacts.BuilderFacts;

internal sealed class WithIdMessageFacts : AbstractBuilderRequiredPropertySetterTestFixture<ImmovableOwner.Builder, ImmovableOwner, Id>
{
    protected override Context BuildContext()
    {
        return new Context(
            empty: new ImmovableOwner.Builder(),
            missingTestedProperty: CreateBuilderWithoutId(),
            used: CreateUsedBuilder(),
            toSetTwice: CreateBuilderWithoutId(),
            firstValue: Id.From(Guid.NewGuid()),
            secondValue: Id.From(Guid.NewGuid())
        );
    }

    protected override void SetProperty(ImmovableOwner.Builder builder, Id value)
        => builder.WithId(value);

    protected override Id GetProperty(ImmovableOwner buildable) => buildable.Id;
}
