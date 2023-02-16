using RI.Novus.Core.CadastralSurvey.Expedients;

namespace RI.Novus.Core.Facts.CadastralSurvey.ExpedientFacts;

internal sealed class CompareToMessageFacts : AbstractComparableTestFixture<ExpedientName>
{
    protected override Context BuildContext()
    {
        const string rawExpedientName = "Expedient1";
        ExpedientName subject = new(rawExpedientName);

        return new Context(
            lessThanSubject: new ExpedientName("Expedient"),
            subject: subject,
            subjectCopy: new ExpedientName(rawExpedientName),
            otherSemanticallyEqualsToSubject: new ExpedientName("Expedient1"),
            greatherThanSubject: new ExpedientName("Expedient12"),
            testRelationalOperatorsOverload: true);
    }

    protected override bool ExecuteEqualsOperator(ExpedientName left, ExpedientName right)
        => left == right;
    protected override bool ExecuteNotEqualsOperator(ExpedientName left, ExpedientName right)
        => left != right;
    protected override bool ExecuteLessThanOperator(ExpedientName left, ExpedientName right)
        => left < right;
    protected override bool ExecuteLessThanOrEqualsToOperator(ExpedientName left, ExpedientName right)
        => left <= right;
    protected override bool ExecuteGreaterThanOperator(ExpedientName left, ExpedientName right)
        => left > right;
    protected override bool ExecuteGreaterThanOrEqualsToOperator(ExpedientName left, ExpedientName right)
        => left >= right;
}
