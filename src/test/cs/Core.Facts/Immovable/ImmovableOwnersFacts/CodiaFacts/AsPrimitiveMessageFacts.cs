
using RI.Novus.Core.Immovable.ImmovableOwners;

namespace RI.Novus.Core.Facts.Immovable.ImmovableOwnersFacts.CodiaFacts;

/// <summary>
/// Primitive Age test
/// </summary>

[TestFixture]
public sealed class AsPrimitiveMessageFacts
{
    [TestCase(1)]
    [TestCase(2)]
    public void Returns_Wrapped_Value_Using_From(int wrappedValue)
    {
        Codia codia = Codia.From(wrappedValue);

        Assert.That(codia.AsPrimitive, Is.EqualTo(wrappedValue));
    }
    
    [TestCase(1)]
    [TestCase(2)]
    public void Returns_Wrapped_Value_Using_Constructor(int wrappedValue)
    {
        Codia codia = Codia.From(wrappedValue);

        Assert.That(codia.AsPrimitive, Is.EqualTo(wrappedValue));
    }
}
