using RI.Novus.Core.Asegurados.Asegurado;

namespace RI.Novus.Core.Facts.Asegurados.AgeFacts;

[TestFixture]
internal sealed class FromMessageFacts
{
    [TestCase(-1)]
    [TestCase(0)]
    public void With_Non_Positive_Integer_Throws_ArgumentOutOfRangeException(int ageAsInt)
        => Assert.That(() => Age.From(ageAsInt), Throws.InstanceOf<ArgumentOutOfRangeException>());

    [TestCase(1)]
    [TestCase(10)]
    public void With_Positive_Integer_Throws_Nothing(int ageAsInt)
        => Assert.That(() => Age.From(ageAsInt), Throws.Nothing);

    [Test]
    public void AsPrimitive_Returns_Same_Value_Provided()
    {
        const int ageAsInt = 1_024;
        var age = Age.From(ageAsInt);

        Assert.That(age.AsPrimitive, Is.EqualTo(ageAsInt));
    }
}
