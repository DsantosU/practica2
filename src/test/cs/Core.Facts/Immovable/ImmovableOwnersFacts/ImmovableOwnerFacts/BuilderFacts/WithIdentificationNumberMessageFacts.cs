using RI.Novus.Core.Immovable.ImmovableOwners;
using static RI.Novus.Core.Facts.Immovable.ImmovableOwnersFacts.ImmovableOwnerFacts.CreateBuilderHelper;

namespace RI.Novus.Core.Facts.Immovable.ImmovableOwnersFacts.ImmovableOwnerFacts.BuilderFacts;

internal sealed class WithIdentificationNumberMessageFacts : AbstractBuilderRequiredPropertySetterTestFixture<ImmovableOwner.Builder, ImmovableOwner, IdentificationNumber>
{
    protected override Context BuildContext()
    {
        return new Context(
            empty: new ImmovableOwner.Builder(),
            missingTestedProperty: CreateBuilderWithoutIdentificationNumber(),
            used: CreateUsedBuilder(),
            toSetTwice: CreateBuilderWithoutIdentificationNumber(),
            firstValue: IdentificationNumber.From("001-1234567-2"),
            secondValue: IdentificationNumber.From("402-3057803-5")
        );
    }

    protected override void SetProperty(ImmovableOwner.Builder builder, IdentificationNumber value)
        => builder.WithIdentificationNumber(value);

    protected override IdentificationNumber GetProperty(ImmovableOwner buildable) => buildable.IdentificationNumber;
}
