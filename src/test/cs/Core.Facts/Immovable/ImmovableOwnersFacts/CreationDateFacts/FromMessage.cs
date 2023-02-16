using RI.Novus.Core.Immovable.ImmovableOwners;

namespace Wepsys.PoluxBPM.Core.Facts.Immovable.ImmovableOwnersFacts.CreationDateFacts;

[TestFixture]
internal sealed class FromMessage
{
    [Test]
    public void With_Past_Date_Throws_Nothing()
        => Assert.That(() => CreationDate.From(DateTimeOffset.UtcNow.AddDays(-1)), Throws.Nothing);
}
