using RI.Novus.Core.Immovable.ImmovableOwners;

namespace Wepsys.PoluxBPM.Core.Facts.Immovable.ImmovableOwnersFacts.CreationDateFacts;

[TestFixture]
internal sealed class NowMessage
{
    [Test]
    public void Returns_Close_To_Now()
        => Assert.That(CreationDate.Now().AsPrimitive, Is.EqualTo(DateTimeOffset.UtcNow).Within(TimeSpan.FromSeconds(5)));
}
