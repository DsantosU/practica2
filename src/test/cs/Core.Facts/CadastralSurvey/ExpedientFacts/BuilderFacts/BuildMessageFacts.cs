using RI.Novus.Core.CadastralSurvey.Expedients;
using static RI.Novus.Core.Facts.CadastralSurvey.ExpedientsFacts.CreateBuilderHelper;

namespace RI.Novus.Core.Facts.CadastralSurvey.ExpedientFacts.BuilderFacts;

[TestFixture]
internal sealed class BuildMessageFacts
{
    [Test]
    public void With_Missing_Required_Property_Throws_InvalidOperationException([Values] BuilderProperty missingProperty)
    {
        Assume.That(missingProperty, Is.Not.EqualTo(BuilderProperty.None));

        Expedient.Builder builder = CreateBuilderWithout(missingProperty);

        Assert.That(() => builder.Build(), Throws.InvalidOperationException);
    }

    [Test]
    public void With_All_Required_Throws_Nothing([Values(BuilderProperty.None)] BuilderProperty missingProperty)
    {
        Expedient.Builder builder = CreateBuilderWithout(missingProperty);

        Assert.That(() => builder.Build(), Throws.Nothing);
    }
}
