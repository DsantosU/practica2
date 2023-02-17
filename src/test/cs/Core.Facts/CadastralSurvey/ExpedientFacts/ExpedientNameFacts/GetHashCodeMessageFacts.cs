using RI.Novus.Core.CadastralSurvey.Expedients;

namespace RI.Novus.Core.Facts.CadastralSurvey.ExpedientFacts;

[TestFixture]
internal sealed class GetHashCodeMessageFacts : AbstractGetHashCodeTestFixture<ExpedientName>
{
    protected override Context BuildContext()
    {
        const string rawName = "Expedient1";
        ExpedientName subject = new(rawName);

        return new Context(
            subject: subject,
            subjectCopy: new ExpedientName(rawName),
            other: new ExpedientName("Expedient2"),
            otherSemanticallyEqualsToSubject: new ExpedientName("Expedient1"));
    }
}
