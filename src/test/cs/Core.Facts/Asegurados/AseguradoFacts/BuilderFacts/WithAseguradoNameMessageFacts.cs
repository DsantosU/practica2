using RI.Novus.Core.Asegurados.Asegurado;
using static RI.Novus.Core.Facts.Asegurados.AseguradoFacts.CreateBuilderHelper;

namespace RI.Novus.Core.Facts.Asegurados.AseguradoFacts.BuilderFacts;

internal sealed class WithAseguradoNameMessageFacts : AbstractBuilderRequiredPropertySetterTestFixture<Asegurado.Builder, Asegurado, AseguradoName>
{
    protected override Context BuildContext()
    {
        return new Context(
            empty: new Asegurado.Builder(),
            missingTestedProperty: CreateBuilderWithoutAseguradoName(),
            used: CreateUsedBuilder(),
            toSetTwice: CreateBuilderWithoutAseguradoName(),
            firstValue: AseguradoName.From("Onboarding"),
            secondValue: AseguradoName.From("Public Announcement")
        );
    }

 

    protected override AseguradoName GetProperty(Asegurado buildable) => buildable.AseguradoName;

    protected override void SetProperty(Asegurado.Builder builder, AseguradoName value)
    {
        builder.WithAseguradoName(value);
    }
}
