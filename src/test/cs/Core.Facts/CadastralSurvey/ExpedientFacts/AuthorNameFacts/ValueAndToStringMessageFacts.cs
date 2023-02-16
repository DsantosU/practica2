using RI.Novus.Core.CadastralSurvey.Expedients;

namespace RI.Novus.Core.Facts.CadastralSurvey.ExpedientFacts.AuthorNameFacts;

internal sealed class ValueAndToStringMessageFacts : AbstractPureStringWrapperTestFixture<AuthorName>
{
    protected override (AuthorName subject, string rawValue) CreateSubject()
    {
        const string rawDesignation = "Gonzalo";

        return (new AuthorName(rawDesignation), rawDesignation);
    }
}
