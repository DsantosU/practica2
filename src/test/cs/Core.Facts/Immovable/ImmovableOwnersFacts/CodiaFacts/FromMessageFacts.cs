using RI.Novus.Core.Immovable.ImmovableOwners;

namespace RI.Novus.Core.Facts.Immovable.ImmovableOwnersFacts.CodiaFacts;

[TestFixture]
internal sealed class FromMessageFacts
{
    [TestCase(-1)]
    [TestCase(0)]
    public void With_Non_Positive_Integer_Throws_ArgumentOutOfRangeException(int codiaAsInt)
        => Assert.That(() => Codia.From(codiaAsInt), Throws.InstanceOf<ArgumentOutOfRangeException>());

    [TestCase(1)]
    [TestCase(10)]
    public void With_Positive_Integer_Throws_Nothing(int codiaAsInt)
        => Assert.That(() => Codia.From(codiaAsInt), Throws.Nothing);

    [Test]
    public void AsPrimitive_Returns_Same_Value_Provided()
    {
        const int codiaAsInt = 1_024;
        var codia = Codia.From(codiaAsInt);

        Assert.That(codia.AsPrimitive, Is.EqualTo(codiaAsInt));
    }
}
