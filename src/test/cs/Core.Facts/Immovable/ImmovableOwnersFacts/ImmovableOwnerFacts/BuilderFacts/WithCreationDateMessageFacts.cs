using RI.Novus.Core.Immovable.ImmovableOwners;
using static RI.Novus.Core.Facts.Immovable.ImmovableOwnersFacts.ImmovableOwnerFacts.CreateBuilderHelper;

namespace RI.Novus.Core.Facts.Immovable.ImmovableOwnersFacts.ImmovableOwnerFacts.BuilderFacts;

internal sealed class WithCreationDateMessageFacts : AbstractBuilderRequiredPropertySetterTestFixture<ImmovableOwner.Builder, ImmovableOwner, CreationDate>
{
    protected override Context BuildContext()
    {
        return new Context(
            empty: new ImmovableOwner.Builder(),
            missingTestedProperty: CreateBuilderWithoutCreationDate(), 
            used: CreateUsedBuilder(), 
            toSetTwice: CreateBuilderWithoutCreationDate(), 
            firstValue: CreationDate.From(DateTimeOffset.UtcNow.AddHours(-1)),
            secondValue: CreationDate.From(DateTimeOffset.UtcNow.AddHours(-2))
        ); 
    }

    protected override void SetProperty(ImmovableOwner.Builder builder, CreationDate value)
        => builder.WithCreationDate(value);

    protected override CreationDate GetProperty(ImmovableOwner buildable) => buildable.CreationDate;
}
