using RI.Novus.Core.Immovable.ImmovableProperties;

namespace RI.Novus.Core.Facts.Immovable.ImmovablePropertiesFacts.ImmovableOwnerIdFacts;

[TestFixture]
internal sealed class GenerateMessage
{
    [TestCase(2)]
    [TestCase(4)]
    [TestCase(8)]
    public void All_Are_Distinct(int count)
    {
        ISet<ImmovableOwnerId> ids = Enumerable.Range(0, count).Select(_ => ImmovableOwnerId.Generate()).ToHashSet();

        Assert.That(ids, Has.Count.EqualTo(count));
    }
}
