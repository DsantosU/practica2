using RI.Novus.Core.TitleRegistration;

namespace RI.Novus.Core.Facts.TitleRegistration.TitleFacts.InscriptionDateFacts;

[TestFixture]
internal sealed class ConstructorFacts
{
    [Test]
    public void With_Null_Throws_ArgumentNullException()
        => Assert.That(() => new InscriptionDate(null!), Throws.ArgumentNullException);
}
