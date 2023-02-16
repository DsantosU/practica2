using RI.Novus.Core.TitleRegistration;

namespace RI.Novus.Core.Facts.TitleRegistration.TitleFacts.InscriptionDateFacts;

internal sealed class CompareToMessageFacts : AbstractComparableTestFixture<InscriptionDate>
{
    protected override Context BuildContext()
    {
        DateTimeOffset asDateTimeOffset = DateTimeOffset.UtcNow.AddYears(-2);
        var rawCreatedTimestamp = new PastOrPresentTimestamp(asDateTimeOffset);
        InscriptionDate subject = new(rawCreatedTimestamp);

        return new Context(
            lessThanSubject: new InscriptionDate(new PastOrPresentTimestamp(asDateTimeOffset.AddDays(-1))),
            subject: subject,
            subjectCopy: new InscriptionDate(new PastOrPresentTimestamp(asDateTimeOffset)),
            otherSemanticallyEqualsToSubject: new InscriptionDate(new PastOrPresentTimestamp(asDateTimeOffset)),
            greatherThanSubject: new InscriptionDate(new PastOrPresentTimestamp(asDateTimeOffset.AddDays(1))),
            testRelationalOperatorsOverload: true);
    }

    protected override bool ExecuteEqualsOperator(InscriptionDate left, InscriptionDate right) => left == right;
    protected override bool ExecuteNotEqualsOperator(InscriptionDate left, InscriptionDate right) => left != right;
    protected override bool ExecuteLessThanOperator(InscriptionDate left, InscriptionDate right) => left < right;
    protected override bool ExecuteLessThanOrEqualsToOperator(InscriptionDate left, InscriptionDate right)
        => left <= right;
    protected override bool ExecuteGreaterThanOperator(InscriptionDate left, InscriptionDate right) => left > right;
    protected override bool ExecuteGreaterThanOrEqualsToOperator(InscriptionDate left, InscriptionDate right)
        => left >= right;
}
