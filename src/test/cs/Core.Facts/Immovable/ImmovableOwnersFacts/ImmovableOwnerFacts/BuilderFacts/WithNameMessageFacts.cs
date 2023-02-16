using RI.Novus.Core.Immovable.ImmovableOwners;
using static RI.Novus.Core.Facts.Immovable.ImmovableOwnersFacts.ImmovableOwnerFacts.CreateBuilderHelper;

namespace RI.Novus.Core.Facts.Immovable.ImmovableOwnersFacts.ImmovableOwnerFacts.BuilderFacts;

internal sealed class WithNameMessageFacts : AbstractBuilderRequiredPropertySetterTestFixture<ImmovableOwner.Builder, ImmovableOwner, Name>
{
    protected override Context BuildContext()
    {
        return new Context(
            empty: new ImmovableOwner.Builder(),
            missingTestedProperty: CreateBuilderWithoutName(),
            used: CreateUsedBuilder(),
            toSetTwice: CreateBuilderWithoutName(),
            firstValue: Name.From("Daniel"),
            secondValue: Name.From("Daniel Santos")
        );
    }

 

    protected override Name GetProperty(ImmovableOwner buildable) => buildable.Name;

    protected override void SetProperty(ImmovableOwner.Builder builder, Name value)
    {
        builder.WithName(value);
    }
}
