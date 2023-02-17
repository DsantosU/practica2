using RI.Novus.Core.CadastralSurvey.Expedients;

namespace RI.Novus.Core.Facts.CadastralSurvey.ExpedientFacts.AuthorNameFacts;

[TestFixture]
internal sealed class ConstructorFacts
{
    private static readonly string[] ValidAuthorName = {
            "Gonzalo",
            "Leonel",
            "Danilo"
        };

    [Test]
    public void With_Null_Throws_ArgumentNullException()
        => Assert.That(() => new AuthorName(null!), Throws.ArgumentNullException);

    [TestCase("")]
    [TestCase(" ")]
    [TestCase("  ")]
    public void With_Empty_And_Less_Than_Minimum_Whitespaces_Throws_ArgumentOutOfRangeException(string rawAuthorName)
        => Assert.That(() => new AuthorName(rawAuthorName), Throws.InstanceOf<ArgumentOutOfRangeException>());

    [TestCase(" Gonzalo")]
    [TestCase("Gonzalo ")]
    [TestCase(" Gonzalo ")]
    public void With_Leading_And_Trailing_Whitespaces_Throws_FormatException(string rawAuthorName)
        => Assert.That(() => new AuthorName(rawAuthorName), Throws.InstanceOf<FormatException>());

    [TestCase("Go")]
    [TestCase("G")]
    public void With_Shorter_Than_Minimum_Throws_ArgumentOutOfRangeException(string rawAuthorName)
        => Assert.That(() => new AuthorName(rawAuthorName), Throws.InstanceOf<ArgumentOutOfRangeException>());


    [TestCase("GonzaloGonzaloGonzaloGonzaloGonzaloGonzalo")]
    public void With_Larger_Than_Maximum_Throws_ArgumentOutOfRangeException(string rawAuthorName)
    {
        Assert.That(() => new AuthorName(rawAuthorName), Throws.InstanceOf<ArgumentOutOfRangeException>());
    }

    [Test]
    public void With_Valid_Pattern_Throws_Nothing([ValueSource(nameof(ValidAuthorName))] string rawAuthorName)
        => Assert.That(() => new AuthorName(rawAuthorName), Throws.Nothing);

}
