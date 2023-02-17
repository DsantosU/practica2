using RI.Novus.Core.CadastralSurvey.Expedients;

namespace RI.Novus.Core.Facts.CadastralSurvey.ExpedientFacts.AuthorNameFacts;

internal sealed class CompareToMessageFacts : AbstractComparableTestFixture<AuthorName>
{
    protected override Context BuildContext()
    {
        const string rawAuthorName = "Gonzalo";
        AuthorName subject = new(rawAuthorName);

        return new Context(
            lessThanSubject: new AuthorName("Gonzal"),
            subject: subject,
            subjectCopy: new AuthorName(rawAuthorName),
            otherSemanticallyEqualsToSubject: new AuthorName("Gonzalo"),
            greatherThanSubject: new AuthorName("Gonzalo2024"),
            testRelationalOperatorsOverload: true);
    }

    protected override bool ExecuteEqualsOperator(AuthorName left, AuthorName right)
        => left == right;
    protected override bool ExecuteNotEqualsOperator(AuthorName left, AuthorName right)
        => left != right;
    protected override bool ExecuteLessThanOperator(AuthorName left, AuthorName right)
        => left < right;
    protected override bool ExecuteLessThanOrEqualsToOperator(AuthorName left, AuthorName right)
        => left <= right;
    protected override bool ExecuteGreaterThanOperator(AuthorName left, AuthorName right)
        => left > right;
    protected override bool ExecuteGreaterThanOrEqualsToOperator(AuthorName left, AuthorName right)
        => left >= right;
}
