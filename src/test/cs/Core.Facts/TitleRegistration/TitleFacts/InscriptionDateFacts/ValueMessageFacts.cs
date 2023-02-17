using RI.Novus.Core.TitleRegistration;

namespace RI.Novus.Core.Facts.TitleRegistration.TitleFacts.InscriptionDateFacts;

internal sealed class ValueMessageFacts : AbstractDomainPrimitiveTestFixture<InscriptionDate, PastOrPresentTimestamp>
{
    protected override (InscriptionDate subject, PastOrPresentTimestamp rawValue) CreateSubject()
    {
        PastOrPresentTimestamp rawCreatedTimestamp = new(DateTimeOffset.UtcNow.AddMinutes(-1));

        return (new InscriptionDate(rawCreatedTimestamp), rawCreatedTimestamp);
    }
}
