using RI.Novus.Core.CadastralSurvey.Expedients;

namespace RI.Novus.Core.Facts.CadastralSurvey.ExpedientFacts.AuthorNameFacts;

internal sealed class EqualsMessageFacts : AbstractEquatableTestFixture<AuthorName>
{
    protected override Context BuildContext()
    {
        const string rawAuthorName = "Gonzalo";
        AuthorName subject = new(rawAuthorName);

        return new Context(
            subject: subject,
            subjectCopy: new AuthorName(rawAuthorName),
            other: new AuthorName("Leonel"),
            otherSemanticallyEqualsToSubject: new AuthorName("Gonzalo"));
    }
}
