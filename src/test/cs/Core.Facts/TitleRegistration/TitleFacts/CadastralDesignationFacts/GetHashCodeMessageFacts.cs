using RI.Novus.Core.TitleRegistration;

namespace RI.Novus.Core.Facts.TitleRegistration.TitleFacts.CadastralDesignationFacts;

[TestFixture]
internal sealed class GetHashCodeMessageFacts : AbstractGetHashCodeTestFixture<CadastralDesignation>
{
    protected override Context BuildContext()
    {
        const string rawName = "309389908904 301";
        CadastralDesignation subject = new(rawName);

        return new Context(
            subject: subject,
            subjectCopy: new CadastralDesignation(rawName),
            other: new CadastralDesignation("309389908904 555"),
            otherSemanticallyEqualsToSubject: new CadastralDesignation("309389908904 301"));
    }
}
