using Optional.Unsafe;
using RI.Novus.Core.Asegurados.Asegurado;
using static RI.Novus.Core.Facts.Asegurados.AseguradoFacts.CreateBuilderHelper;

namespace RI.Novus.Core.Facts.Asegurados.AseguradoFacts.BuilderFacts;

internal sealed class WithIdMessageFacts : AbstractBuilderRequiredPropertySetterTestFixture<Asegurado.Builder, Asegurado, Id>
{
    protected override Context BuildContext()
    {
        return new Context(
            empty: new Asegurado.Builder(),
            missingTestedProperty: CreateBuilderWithoutId(),
            used: CreateUsedBuilder(),
            toSetTwice: CreateBuilderWithoutId(),
            firstValue: Id.From(Guid.NewGuid()),
            secondValue: Id.From(Guid.NewGuid())
        );
    }

    protected override void SetProperty(Asegurado.Builder builder, Id value)
        => builder.WithId(value);

    protected override Id GetProperty(Asegurado buildable) => buildable.Id.ValueOrFailure();
}
