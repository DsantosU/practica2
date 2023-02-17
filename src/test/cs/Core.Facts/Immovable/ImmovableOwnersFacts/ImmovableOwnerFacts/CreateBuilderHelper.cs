using RI.Novus.Core.Immovable.ImmovableOwners;

namespace RI.Novus.Core.Facts.Immovable.ImmovableOwnersFacts.ImmovableOwnerFacts;

internal static class CreateBuilderHelper
{
    internal enum BuilderProperty
    {
        None,
        Id,
        Name,
        IdentificationNumber,
        List,
        Codia,
        CreationDate

    }
    internal static ImmovableOwner.Builder CreateUsedBuilder()
    {
        ImmovableOwner.Builder builder = CreateFullBuilder();

        _ = builder.Build();

        return builder;
    }

    internal static ImmovableOwner.Builder CreateFullBuilder() => CreateBuilderWithout(BuilderProperty.None);
    internal static ImmovableOwner.Builder CreateBuilderWithoutId() => CreateBuilderWithout(BuilderProperty.Id);
    internal static ImmovableOwner.Builder CreateBuilderWithoutCreationDate() => CreateBuilderWithout(BuilderProperty.CreationDate);
    internal static ImmovableOwner.Builder CreateBuilderWithoutName() => CreateBuilderWithout(BuilderProperty.Name);
    internal static ImmovableOwner.Builder CreateBuilderWithoutIdentificationNumber() => CreateBuilderWithout(BuilderProperty.IdentificationNumber);
    internal static ImmovableOwner.Builder CreateBuilderWithoutList() => CreateBuilderWithout(BuilderProperty.List);
    internal static ImmovableOwner.Builder CreateBuilderWithoutCodia() => CreateBuilderWithout(BuilderProperty.Codia);
    internal static ImmovableOwner.Builder CreateBuilderWithout(BuilderProperty propertyToSkip)
    {
        IDictionary<BuilderProperty, Action<ImmovableOwner.Builder>> setters = new Dictionary<BuilderProperty, Action<ImmovableOwner.Builder>>
        {
            [BuilderProperty.Id] = b => b.WithId(Id.Generate()),
            [BuilderProperty.Name] = b => b.WithName(Name.From("Daniel Alberto")),
            [BuilderProperty.IdentificationNumber] = b => b.WithIdentificationNumber(IdentificationNumber.From("001-0000000-1")),
            [BuilderProperty.CreationDate] = b => b.WithCreationDate(CreationDate.From(DateTimeOffset.UtcNow)),
            [BuilderProperty.Codia] = b => b.WithCodia(Codia.From(1)),

        };

        var builder = new ImmovableOwner.Builder();
        foreach (BuilderProperty key in setters.Keys.Where(k => k != propertyToSkip))
        {
            setters[key](builder);
        }

        return builder;
    }
}
