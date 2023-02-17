using RI.Novus.Core.Asegurados.Asegurado;

namespace RI.Novus.Core.Facts.Asegurados.IdentificationNumberFacts;

[TestFixture]
internal sealed class FromMessage
{
    [TestCase("001-0000000-1")]
    [TestCase("00100000001")]
    [TestCase("402-3057173-5")]
    public void With_Valid_Titles_Throws_Nothing(string rawIdentificationNumber)
        => Assert.That(() => IdentificationNumber.From(rawIdentificationNumber), Throws.Nothing);

    [Test]
    public void With_Null_Throws_ArgumentNullException()
        => Assert.That(() => IdentificationNumber.From(null), Throws.ArgumentNullException);

    [TestCase("")]
    [TestCase(" ")]
    [TestCase("  ")]
    public void With_Empty_Throws_ArgumentOutOfRangeException(string rawIdentificationNumber)
        => Assert.That(() => IdentificationNumber.From(rawIdentificationNumber), Throws.InstanceOf<ArgumentOutOfRangeException>());

    [TestCase("     ")]
    [TestCase("          ")]
    public void With_Empty_And_Larger_Than_Minimum_Throws_FormatException(string rawIdentificationNumber)
        => Assert.That(() => IdentificationNumber.From(rawIdentificationNumber), Throws.InstanceOf<FormatException>());

    [TestCase(1)]
    [TestCase(3)]
    [TestCase(129)]
    [TestCase(256)]
    public void With_Titles_Length_Outside_Boundaries_Throws_ArgumentOutOfRangeException(int length)
    {
        string rawIdentificationNumber = new('a', length);

        Assert.That(() => IdentificationNumber.From(rawIdentificationNumber), Throws.InstanceOf<ArgumentOutOfRangeException>());
    }

    [TestCase(" 001-0000000-1")]
    [TestCase("001-0000000-1 ")]
    [TestCase(" 001-0000000-1 ")]
    public void With_Leading_Or_Trailing_White_Spaces_Throws_FormatException(string rawIdentificationNumber)
        => Assert.That(() => IdentificationNumber.From(rawIdentificationNumber), Throws.InstanceOf<FormatException>());

    [Test]
    [TestCaseSource(typeof(OneTimeSetupFixture), nameof(OneTimeSetupFixture.ControlCharacters))]
    public void With_Control_Characters_Throws_FormatException(char value)
    {
        string rawValue = $"This a Identification Number {value}";

        Assert.That(() => IdentificationNumber.From(rawValue), Throws.InstanceOf<FormatException>());
    }
}
