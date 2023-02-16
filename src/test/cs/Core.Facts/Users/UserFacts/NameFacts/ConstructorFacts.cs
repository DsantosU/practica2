//using RI.Novus.Core.TitleRegistration;

//namespace RI.Novus.Core.Facts.TitleRegistration.TitleFacts.CadastralDesignationFacts;

//[TestFixture]
//internal sealed class ConstructorFacts
//{
//    private static readonly string[] ValidDesignations = {
//            "309389908904 301",
//            "309389908904 000",
//            "309389908904 999"
//        };

//    [Test]
//    public void With_Null_Throws_ArgumentNullException()
//        => Assert.That(() => new CadastralDesignation(null!), Throws.ArgumentNullException);

//    [TestCase("")]
//    [TestCase(" ")]
//    [TestCase("  ")]
//    public void With_Empty_And_Less_Than_Minimum_Whitespaces_Throws_ArgumentOutOfRangeException(string rawEmail)
//        => Assert.That(() => new CadastralDesignation(rawEmail), Throws.InstanceOf<ArgumentOutOfRangeException>());

//    [TestCase(" 309389908904 301")]
//    [TestCase("309389908904 301 ")]
//    [TestCase(" 309389908904 301 ")]
//    public void With_Leading_And_Trailing_Whitespaces_Throws_FormatException(string rawEmail)
//        => Assert.That(() => new CadastralDesignation(rawEmail), Throws.InstanceOf<ArgumentOutOfRangeException>());

//    [TestCase("309389908904 30")]
//    [TestCase("309389908904")]
//    public void With_Shorter_Than_Minimum_Throws_ArgumentOutOfRangeException(string rawEmail)
//        => Assert.That(() => new CadastralDesignation(rawEmail), Throws.InstanceOf<ArgumentOutOfRangeException>());

//    [Test]
//    public void With_Larger_Than_Maximum_Throws_ArgumentOutOfRangeException([Values(17, 32, 64, 128)] in int length)
//    {
//        string rawEmail = $"309389908904 301{new string('9', length - 16)}";

//        Assert.That(() => new CadastralDesignation(rawEmail), Throws.InstanceOf<ArgumentOutOfRangeException>());
//    }

//    [Test]
//    public void With_Valid_Pattern_Throws_Nothing([ValueSource(nameof(ValidDesignations))] string rawDesignation)
//        => Assert.That(() => new CadastralDesignation(rawDesignation), Throws.Nothing);

//    [TestCase("309389908904a301")]
//    [TestCase("e09389908904 301")]
//    [TestCase("309389908904_301")]
//    [TestCase("309389908904-301")]
//    public void With_Invalid_Pattern_Throws_FormatException(string rawEmail)
//        => Assert.That(() => new CadastralDesignation(rawEmail), Throws.InstanceOf<FormatException>());
//}
