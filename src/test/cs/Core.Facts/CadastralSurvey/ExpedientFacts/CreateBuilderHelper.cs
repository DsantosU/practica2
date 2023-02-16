using RI.Novus.Core.CadastralSurvey.Expedients;

namespace RI.Novus.Core.Facts.CadastralSurvey.ExpedientsFacts;

internal static class CreateBuilderHelper
{
    internal enum BuilderProperty
    {
        None,
        ExpedientName,

    }
    internal static Expedient.Builder CreateExpedientNameBuilder()
    {
        Expedient.Builder builder = CreateFullBuilder();

        _ = builder.Build();

        return builder;
    }

    internal static Expedient.Builder CreateFullBuilder() => CreateBuilderWithout(BuilderProperty.None);
    internal static Expedient.Builder CreateBuilderWithoutExpedientName()
        => CreateBuilderWithout(BuilderProperty.ExpedientName);

    internal static Expedient.Builder CreateBuilderWithout(BuilderProperty propertyToSkip)
    {
        IDictionary<BuilderProperty, Action<Expedient.Builder>> setters
            = new Dictionary<BuilderProperty, Action<Expedient.Builder>>
        {
            [BuilderProperty.ExpedientName] = b
                => b.WithExpedientName(new ExpedientName("Expedient1")),     
            


        };

        var builder = new Expedient.Builder();
        foreach (BuilderProperty key in setters.Keys.Where(k => k != propertyToSkip))
        {
            setters[key](builder);
        }

        return builder;
    }
}
