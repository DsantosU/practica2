using RI.Novus.Core.Immovable.ImmovableProperties;

namespace RI.Novus.Core.Facts.Immovable.ImmovablePropertiesFacts.AreaFacts
{
    [TestFixture]
    internal sealed class FromMessage
    {
        private static readonly decimal[] ValidArea = {
        0.01M,
        49_999.51M,
        99_999    };
        [Test]
        public void With_Valid_Values_Throws_Nothing([ValueSource(nameof(ValidArea))] decimal rawArea)
            => Assert.That(() => Area.From(rawArea), Throws.Nothing);

        [TestCase(-0.01)]
        [TestCase(0)]
        public void With_Below_Minimum_Throws_ArgumentOutOfRangeException(decimal rawArea)
            => Assert.That(() => Area.From(rawArea), Throws.InstanceOf<ArgumentOutOfRangeException>());

        [TestCase(99_999.01)]
        [TestCase(100_000)]
        public void With_Above_Maximum_Throws_ArgumentOutOfRangeException(decimal rawArea)
            => Assert.That(() => Area.From(rawArea), Throws.InstanceOf<ArgumentOutOfRangeException>());
    }
}
