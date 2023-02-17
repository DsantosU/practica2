using RI.Novus.Core.Asegurados.Asegurado;

namespace RI.Novus.Core.Facts.Asegurados.AseguradoFacts;

internal static class CreateBuilderHelper
{
    internal enum BuilderProperty
    {
        None,
        Id,
        AseguradoName,
        Age,
        Birthday,
        IdentificationNumber
    }
    internal static Asegurado.Builder CreateUsedBuilder()
    {
        Asegurado.Builder builder = CreateFullBuilder();

        _ = builder.Build();

        return builder;
    }

    internal static Asegurado.Builder CreateFullBuilder() => CreateBuilderWithout(BuilderProperty.None);
    internal static Asegurado.Builder CreateBuilderWithoutId() => CreateBuilderWithout(BuilderProperty.Id);
    internal static Asegurado.Builder CreateBuilderWithoutBirthday() => CreateBuilderWithout(BuilderProperty.Birthday);
    internal static Asegurado.Builder CreateBuilderWithoutAseguradoName() => CreateBuilderWithout(BuilderProperty.AseguradoName);
    internal static Asegurado.Builder CreateBuilderWithoutIdentificationNumber() => CreateBuilderWithout(BuilderProperty.IdentificationNumber);
    internal static Asegurado.Builder CreateBuilderWithoutAge() => CreateBuilderWithout(BuilderProperty.Age);

    internal static Asegurado.Builder CreateBuilderWithout(BuilderProperty propertyToSkip)
    {
        IDictionary<BuilderProperty, Action<Asegurado.Builder>> setters = new Dictionary<BuilderProperty, Action<Asegurado.Builder>>
        {
            [BuilderProperty.Id] = b => b.WithId(Id.Generate()),
            [BuilderProperty.AseguradoName] = b => b.WithAseguradoName(AseguradoName.From("Daniel Alberto")),
            [BuilderProperty.IdentificationNumber] = b => b.WithIdentificationNumber(IdentificationNumber.From("001-0000000-1")),
            [BuilderProperty.Birthday] = b => b.WithBirthday(Birthday.From(DateTimeOffset.UtcNow)),
            [BuilderProperty.Age] = b => b.WithAge(Age.From(1))
        };

        var builder = new Asegurado.Builder();
        foreach (BuilderProperty key in setters.Keys.Where(k => k != propertyToSkip))
        {
            setters[key](builder);
        }

        return builder;
    }
}
