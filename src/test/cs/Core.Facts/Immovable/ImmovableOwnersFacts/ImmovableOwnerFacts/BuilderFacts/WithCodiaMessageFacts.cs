using RI.Novus.Core.Immovable.ImmovableOwners;
using static RI.Novus.Core.Facts.Immovable.ImmovableOwnersFacts.ImmovableOwnerFacts.CreateBuilderHelper;

namespace RI.Novus.Core.Facts.Immovable.ImmovableOwnersFacts.ImmovableOwnerFacts.BuilderFacts;

internal sealed class WithSurfaceMessageFacts : AbstractBuilderRequiredPropertySetterTestFixture<ImmovableOwner.Builder, ImmovableOwner, Codia>
{
    protected override Context BuildContext()
    {
        return new Context(
            empty: new ImmovableOwner.Builder(),
            missingTestedProperty: CreateBuilderWithoutCodia(),
            used: CreateUsedBuilder(),
            toSetTwice: CreateBuilderWithoutCodia(),
            firstValue: Codia.From(1),
            secondValue: Codia.From(3)
        );
    }

    protected override void SetProperty(ImmovableOwner.Builder builder, Codia value)
        => builder.WithCodia(value);

    protected override Codia GetProperty(ImmovableOwner buildable) => buildable.Codia;
}
