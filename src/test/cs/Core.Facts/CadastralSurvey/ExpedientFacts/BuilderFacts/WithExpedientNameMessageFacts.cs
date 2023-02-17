using static RI.Novus.Core.Facts.CadastralSurvey.ExpedientsFacts.CreateBuilderHelper;

using RI.Novus.Core.CadastralSurvey.Expedients;

namespace RI.Novus.Core.Facts.CadastralSurvery.ExpedientFacts.BuilderFacts;

internal class WithExpedientNameMessageFacts :
    AbstractBuilderRequiredPropertySetterTestFixture<Expedient.Builder, Expedient, ExpedientName>
{
    protected override Context BuildContext()
    {
        return new Context(empty: new Expedient.Builder(),
            missingTestedProperty: CreateBuilderWithoutExpedientName(),
            used: CreateExpedientNameBuilder(),
            toSetTwice: CreateBuilderWithoutExpedientName(),
            firstValue: ExpedientName.From("Expedient1"),
            secondValue: ExpedientName.From("Expedient2"));
    }

    protected override void SetProperty(Expedient.Builder builder, ExpedientName value)
        => builder.WithExpedientName(value);

    protected override ExpedientName GetProperty(Expedient buildable) => buildable.ExpedientName;
}
