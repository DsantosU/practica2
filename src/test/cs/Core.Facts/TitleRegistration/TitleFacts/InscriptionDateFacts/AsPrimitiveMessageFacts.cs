using RI.Novus.Core.TitleRegistration;

namespace RI.Novus.Core.Facts.TitleRegistration.TitleFacts.InscriptionDateFacts;

[TestFixture]
internal sealed class AsPrimitiveMessageFacts :
    AbstractAsPrimitiveTestFixture<InscriptionDate, PastOrPresentTimestamp, DateTimeOffset>
{
    protected override (InscriptionDate subject, DateTimeOffset primitiveValue) CreateSubject()
    {
        DateTimeOffset primitive = DateTimeOffset.UtcNow.AddMinutes(-1);

        return (new InscriptionDate(new PastOrPresentTimestamp(primitive)), primitive);
    }
}
