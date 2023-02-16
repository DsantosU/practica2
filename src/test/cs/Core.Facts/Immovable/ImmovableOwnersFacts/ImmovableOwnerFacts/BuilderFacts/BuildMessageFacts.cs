using RI.Novus.Core.Immovable.ImmovableOwners;
using static RI.Novus.Core.Facts.Immovable.ImmovableOwnersFacts.ImmovableOwnerFacts.CreateBuilderHelper;

namespace RI.Novus.Core.Facts.Immovable.ImmovableOwnersFacts.ImmovableOwnerFacts.BuilderFacts;

[TestFixture]
internal sealed class BuildMessageFacts
{
    [Test]
    public void With_Missing_Required_Property_Throws_InvalidOperationException([Values] BuilderProperty missingProperty) {
        Assume.That(missingProperty, Is.Not.EqualTo(BuilderProperty.None)
                                   .And.Not.EqualTo(BuilderProperty.Id));

        ImmovableOwner.Builder builder = CreateBuilderWithout(missingProperty);

        Assert.That(() => builder.Build(), Throws.InvalidOperationException);
    }

    [Test]
    public void With_All_Required_Throws_Nothing([Values(BuilderProperty.None, BuilderProperty.Id)] in BuilderProperty missingProperty) {
        ImmovableOwner.Builder builder = CreateBuilderWithout(missingProperty);

        Assert.That(() => builder.Build(), Throws.Nothing);
    }
}
