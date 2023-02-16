using RI.Novus.Core.Asegurados.Asegurado;

namespace RI.Novus.Core.Facts.Asegurados.BirthdayFacts;

[TestFixture]
internal sealed class NowMessage
{
    [Test]
    public void Returns_Close_To_Now()
        => Assert.That(Birthday.Now().AsPrimitive, Is.EqualTo(DateTimeOffset.UtcNow).Within(TimeSpan.FromSeconds(5)));
}
