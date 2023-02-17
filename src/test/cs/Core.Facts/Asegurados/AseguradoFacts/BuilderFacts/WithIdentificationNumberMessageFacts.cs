using RI.Novus.Core.Asegurados.Asegurado;
using static RI.Novus.Core.Facts.Asegurados.AseguradoFacts.CreateBuilderHelper;

namespace RI.Novus.Core.Facts.Asegurados.AseguradoFacts.BuilderFacts;

internal sealed class WithIdentificationNumberMessageFacts : AbstractBuilderRequiredPropertySetterTestFixture<Asegurado.Builder, Asegurado, IdentificationNumber>
{
    protected override Context BuildContext()
    {
        return new Context(
            empty: new Asegurado.Builder(),
            missingTestedProperty: CreateBuilderWithoutIdentificationNumber(),
            used: CreateUsedBuilder(),
            toSetTwice: CreateBuilderWithoutIdentificationNumber(),
            firstValue: IdentificationNumber.From("001-1234567-2"),
            secondValue: IdentificationNumber.From("402-3057803-5")
        );
    }

    protected override void SetProperty(Asegurado.Builder builder, IdentificationNumber value)
        => builder.WithIdentificationNumber(value);

    protected override IdentificationNumber GetProperty(Asegurado buildable) => buildable.IdentificationNumber;
}
