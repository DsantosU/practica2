using RI.Novus.Core.TitleRegistration;

namespace RI.Novus.Core.Facts.TitleRegistration.TitleFacts.InscriptionDateFacts;

internal sealed class ToStringMessageFacts
{
    [Test]
    public void Formats_String_Using_Full_Date_And_Time_ISO_8601_With_UTC_Z_Indicator()
    {
        int lastYear = DateTimeOffset.UtcNow.Year - 1;
        var rawCreatedTimestamp = new DateTimeOffset(year: lastYear, month: 01, day: 02, hour: 03, minute: 04,
            second: 05, millisecond: 006, offset: TimeSpan.Zero);

        InscriptionDate createdTimestamp = new(new PastOrPresentTimestamp(rawCreatedTimestamp));

        Assert.That(createdTimestamp.ToString(), Is.EqualTo($"{lastYear}-01-02T03:04:05.006Z"));
    }
}
