using RI.Novus.Core.Asegurados.Asegurado;

namespace RI.Novus.Core.Facts.Asegurados.AgeFacts;

[TestFixture]
internal sealed class ConstructorFacts
{
    [TestCase(1)]
    [TestCase(1_024)]
    [TestCase(int.MaxValue)]
    public void With_Positive_Values_Throws_Nothing(int ageAsInt)
        => Assert.That(() => Age.From(ageAsInt), Throws.Nothing);
}
