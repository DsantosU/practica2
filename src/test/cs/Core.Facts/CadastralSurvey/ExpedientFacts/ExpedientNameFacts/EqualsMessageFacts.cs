using RI.Novus.Core.CadastralSurvey.Expedients;

namespace RI.Novus.Core.Facts.CadastralSurvey.ExpedientFacts;

internal sealed class EqualsMessageFacts : AbstractEquatableTestFixture<ExpedientName>
{
    protected override Context BuildContext()
    {
        const string rawExpedientName = "Expedient1";
        ExpedientName subject = new(rawExpedientName);

        return new Context(
            subject: subject,
            subjectCopy: new ExpedientName(rawExpedientName),
            other: new ExpedientName("Expedient2"),
            otherSemanticallyEqualsToSubject: new ExpedientName("Expedient1"));
    }
}
