using RI.Novus.Core.Asegurados.Asegurado;

namespace RI.Novus.Core.Facts.Asegurados.AgeFacts;

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
        Age age = Age.From(wrappedValue);

        Assert.That(age.AsPrimitive, Is.EqualTo(wrappedValue));
    }
    
    [TestCase(1)]
    [TestCase(2)]
    public void Returns_Wrapped_Value_Using_Constructor(int wrappedValue)
    {
        Age age = Age.From(wrappedValue);

        Assert.That(age.AsPrimitive, Is.EqualTo(wrappedValue));
    }
}
