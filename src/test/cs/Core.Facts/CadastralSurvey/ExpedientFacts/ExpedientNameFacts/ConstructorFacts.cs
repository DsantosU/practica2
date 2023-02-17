using RI.Novus.Core.CadastralSurvey.Expedients;

namespace RI.Novus.Core.Facts.CadastralSurvey.ExpedientFacts;

[TestFixture]
internal sealed class ConstructorFacts
{
    private static readonly string[] ValidExpedientName = {
            "Expedient1",
            "Expedient2",
            "Expedient3"
        };

    [Test]
    public void With_Null_Throws_ArgumentNullException()
        => Assert.That(() => new ExpedientName(null!), Throws.ArgumentNullException);

    [TestCase("")]
    [TestCase(" ")]
    [TestCase("  ")]
    public void With_Empty_And_Less_Than_Minimum_Whitespaces_Throws_ArgumentOutOfRangeException(string rawEmail)
        => Assert.That(() => new ExpedientName(rawEmail), Throws.InstanceOf<ArgumentOutOfRangeException>());

    [TestCase(" Expedient1")]
    [TestCase("Expedient1 ")]
    [TestCase(" Expedient1 ")]
    public void With_Leading_And_Trailing_Whitespaces_Throws_FormatException(string rawEmail)
        => Assert.That(() => new ExpedientName(rawEmail), Throws.InstanceOf<FormatException>());

    [TestCase("Pe")]
    [TestCase("P")]
    public void With_Shorter_Than_Minimum_Throws_ArgumentOutOfRangeException(string rawEmail)
        => Assert.That(() => new ExpedientName(rawEmail), Throws.InstanceOf<ArgumentOutOfRangeException>());


    [TestCase("PedroPedroPedroPedroPedro")]
    public void With_Larger_Than_Maximum_Throws_ArgumentOutOfRangeException(string rawExpedientName)
    {
        Assert.That(() => new ExpedientName(rawExpedientName), Throws.InstanceOf<ArgumentOutOfRangeException>());
    }

    [Test]
    public void With_Valid_Pattern_Throws_Nothing([ValueSource(nameof(ValidExpedientName))] string rawDesignation)
        => Assert.That(() => new ExpedientName(rawDesignation), Throws.Nothing);

}
