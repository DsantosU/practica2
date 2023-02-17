using RI.Novus.Core.TitleRegistration;

namespace RI.Novus.Core.Facts.TitleRegistration.TitleFacts.CadastralDesignationFacts;

internal sealed class ValueAndToStringMessageFacts : AbstractPureStringWrapperTestFixture<CadastralDesignation>
{
    protected override (CadastralDesignation subject, string rawValue) CreateSubject()
    {
        const string rawDesignation = "309389908904 301";

        return (new CadastralDesignation(rawDesignation), rawDesignation);
    }
}
