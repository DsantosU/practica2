using RI.Novus.Core.CadastralSurvey.Expedients;

namespace RI.Novus.Core.Facts.CadastralSurvey.ExpedientFacts;

internal sealed class ValueAndToStringMessageFacts : AbstractPureStringWrapperTestFixture<ExpedientName>
{
    protected override (ExpedientName subject, string rawValue) CreateSubject()
    {
        const string rawDesignation = "Expediente1";

        return (new ExpedientName(rawDesignation), rawDesignation);
    }
}
