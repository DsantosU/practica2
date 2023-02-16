using RI.Novus.Core.Immovable.ImmovableOwners;
using RI.Novus.Core.Immovable.ImmovableProperties;

namespace RI.Novus.Core.Facts.Immovable.ImmovableOwnersFacts.ListFacts;

[TestFixture]
internal sealed class FromMessage
{

    [Test]
    public void With_Null_Throws_ArgumentNullException()
        => Assert.That(() => new ImmovableProperty(null), Throws.ArgumentNullException);


}
