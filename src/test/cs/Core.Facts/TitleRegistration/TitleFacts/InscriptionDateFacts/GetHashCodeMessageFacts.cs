using RI.Novus.Core.TitleRegistration;

namespace RI.Novus.Core.Facts.TitleRegistration.TitleFacts.InscriptionDateFacts;

internal sealed class GetHashCodeMessageFacts : AbstractGetHashCodeTestFixture<InscriptionDate>
{
    protected override Context BuildContext()
    {
        DateTimeOffset asDateTimeOffset = DateTimeOffset.UtcNow.AddMinutes(-1);
        var rawCreatedTimestamp = new PastOrPresentTimestamp(asDateTimeOffset);
        InscriptionDate subject = new(rawCreatedTimestamp);

        return new Context(
            subject: subject,
            subjectCopy: new InscriptionDate(rawCreatedTimestamp),
            other: new InscriptionDate(new PastOrPresentTimestamp(asDateTimeOffset.AddDays(-1))),
            otherSemanticallyEqualsToSubject: new InscriptionDate(new PastOrPresentTimestamp(asDateTimeOffset)));
    }
}
