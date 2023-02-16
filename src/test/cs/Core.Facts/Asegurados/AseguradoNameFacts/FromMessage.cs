using RI.Novus.Core.Asegurados.Asegurado;

namespace RI.Novus.Core.Facts.Asegurados.AseguradoNameFacts;

[TestFixture]
internal sealed class FromMessage
{
    [TestCase("Amaury")]
    [TestCase("Daniel Santos")]
    [TestCase("Daniel Alberto De Los Santos")]
    public void With_Valid_Titles_Throws_Nothing(string rawAsegurado)
        => Assert.That(() => AseguradoName.From(rawAsegurado), Throws.Nothing);

    [Test]
    public void With_Null_Throws_ArgumentNullException()
        => Assert.That(() => AseguradoName.From(null), Throws.ArgumentNullException);

    [TestCase("")]
    [TestCase(" ")]
    [TestCase("  ")]
    public void With_Empty_Throws_ArgumentOutOfRangeException(string rawAsegurado)
        => Assert.That(() => AseguradoName.From(rawAsegurado), Throws.InstanceOf<ArgumentOutOfRangeException>());

    [TestCase("     ")]
    [TestCase("          ")]
    public void With_Empty_And_Larger_Than_Minimum_Throws_FormatException(string rawAsegurado)
        => Assert.That(() => AseguradoName.From(rawAsegurado), Throws.InstanceOf<FormatException>());

    [TestCase(1)]
    [TestCase(3)]
    [TestCase(129)]
    [TestCase(256)]
    public void With_Titles_Length_Outside_Boundaries_Throws_ArgumentOutOfRangeException(int length)
    {
        string rawAsegurado = new('a', length);

        Assert.That(() => AseguradoName.From(rawAsegurado), Throws.InstanceOf<ArgumentOutOfRangeException>());
    }

    [TestCase(" Daniel Alberto")]
    [TestCase("Daniel Alberto ")]
    [TestCase(" Daniel Alberto ")]
    public void With_Leading_Or_Trailing_White_Spaces_Throws_FormatException(string rawAsegurado)
        => Assert.That(() => AseguradoName.From(rawAsegurado), Throws.InstanceOf<FormatException>());

    [Test]
    [TestCaseSource(typeof(OneTimeSetupFixture), nameof(OneTimeSetupFixture.ControlCharacters))]
    public void With_Control_Characters_Throws_FormatException(char value)
    {
        string rawValue = $"This a title {value}";

        Assert.That(() => AseguradoName.From(rawValue), Throws.InstanceOf<FormatException>());
    }
}
