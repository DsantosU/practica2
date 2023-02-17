
using RI.Novus.Core.Immovable.ImmovableOwners;

namespace RI.Novus.Core.Facts.Immovable.ImmovableOwnersFacts.CodiaFacts;

[TestFixture]
internal sealed class ConstructorFacts
{
    [TestCase(1)]
    [TestCase(1_024)]
    [TestCase(int.MaxValue)]
    public void With_Positive_Values_Throws_Nothing(int codiaAsInt)
        => Assert.That(() => Codia.From(codiaAsInt), Throws.Nothing);
}
