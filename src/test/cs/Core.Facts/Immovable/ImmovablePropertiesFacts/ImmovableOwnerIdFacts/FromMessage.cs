using RI.Novus.Core.Immovable.ImmovableProperties;

namespace RI.Novus.Core.Facts.Immovable.ImmovablePropertiesFacts.ImmovableOwnerIdFacts;

[TestFixture]
internal sealed class FromMessage
{
    [Test]
    public void With_Empty_Throws_ArgumentException()
        => Assert.That(() => ImmovableOwnerId.From(Guid.Empty), Throws.ArgumentException);

    [TestCase("000000000000-0000-0000-000000000001")]
    [TestCase("00000000_0000-0000-0000-000000000002")]
    [TestCase("ffffffff-ffff-zffz-ffff-ffffffffffff")]
    public void With_Invalid_Formatted_Values_Throws_FormatException(string idAsString)
        => Assert.That(() => ImmovableOwnerId.From(new Guid(idAsString)), Throws.InstanceOf<FormatException>());

    [TestCase("00000000-0000-0000-0000-000000000001")]
    [TestCase("00000000-0000-0000-0000-000000000002")]
    [TestCase("ffffffff-ffff-ffff-ffff-ffffffffffff")]
    public void With_Valid_Values_Throws_Nothing(string idAsString)
        => Assert.That(() => ImmovableOwnerId.From(new Guid(idAsString)), Throws.Nothing);

    [Test]
    public void With_Valid_Guid_Throws_Nothing()
        => Assert.That(() => ImmovableOwnerId.From(Guid.NewGuid()), Throws.Nothing);
}
