using RI.Novus.Core.CadastralSurvey.Expedients;

namespace RI.Novus.Core.Facts.CadastralSurvey.ExpedientFacts.AuthorNameFacts;

[TestFixture]
internal sealed class GetHashCodeMessageFacts : AbstractGetHashCodeTestFixture<AuthorName>
{
    protected override Context BuildContext()
    {
        const string rawName = "Gonzalo";
        AuthorName subject = new(rawName);

        return new Context(
            subject: subject,
            subjectCopy: new AuthorName(rawName),
            other: new AuthorName("Leonel"),
            otherSemanticallyEqualsToSubject: new AuthorName("Gonzalo"));
    }
}
