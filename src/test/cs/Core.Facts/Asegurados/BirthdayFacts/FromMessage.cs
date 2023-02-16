using RI.Novus.Core.Asegurados.Asegurado;

namespace RI.Novus.Core.Facts.Asegurados.BirthdayFacts;

[TestFixture]
internal sealed class FromMessage
{
    [Test]
    public void With_Past_Date_Throws_Nothing()
        => Assert.That(() => Birthday.From(DateTimeOffset.UtcNow.AddDays(-1)), Throws.Nothing);
}
