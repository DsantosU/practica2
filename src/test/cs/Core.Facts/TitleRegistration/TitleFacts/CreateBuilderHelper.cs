using RI.Novus.Core.TitleRegistration; 

namespace RI.Novus.Core.Facts.TitleRegistration.TitleFacts;

internal static class CreateBuilderHelper
{
    internal enum BuilderProperty
    {
        None,
        InscriptionDate,
    }
    internal static Title.Builder CreateUsedBuilder()
    {
        Title.Builder builder = CreateFullBuilder();

        _ = builder.Build();

        return builder;
    }

    internal static Title.Builder CreateFullBuilder() => CreateBuilderWithout(BuilderProperty.None);
    internal static Title.Builder CreateBuilderWithoutInscriptionDate()
        => CreateBuilderWithout(BuilderProperty.InscriptionDate);

    internal static Title.Builder CreateBuilderWithout(BuilderProperty propertyToSkip)
    {
        IDictionary<BuilderProperty, Action<Title.Builder>> setters
            = new Dictionary<BuilderProperty, Action<Title.Builder>>
        {
            [BuilderProperty.InscriptionDate] = b
                => b.WithInscriptionDate(new InscriptionDate(new PastOrPresentTimestamp(DateTimeOffset.UtcNow))),
        };

        var builder = new Title.Builder();
        foreach (BuilderProperty key in setters.Keys.Where(k => k != propertyToSkip))
        {
            setters[key](builder);
        }

        return builder;
    }
}
