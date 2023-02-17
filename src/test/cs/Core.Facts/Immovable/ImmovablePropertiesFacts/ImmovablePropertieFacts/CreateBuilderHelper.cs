using RI.Novus.Core.Immovable.ImmovableProperties;

namespace RI.Novus.Core.Facts.Immovable.ImmovablePropertiesFacts.ImmovablePropertieFacts;

internal static class CreateBuilderHelper
{
    internal enum BuilderProperty
    {
        None,
        Id,
        ImmovableOwnerId,
        Surface,
        Type,
        Area,
        Region

    }
    internal static ImmovableProperty.Builder CreateUsedBuilder()
    {
        ImmovableProperty.Builder builder = CreateFullBuilder();

        _ = builder.Build();

        return builder;
    }

    internal static ImmovableProperty.Builder CreateFullBuilder() => CreateBuilderWithout(BuilderProperty.None);
    internal static ImmovableProperty.Builder CreateBuilderWithoutId() => CreateBuilderWithout(BuilderProperty.Id);
    internal static ImmovableProperty.Builder CreateBuilderWithoutImmovableOwnerId() => CreateBuilderWithout(BuilderProperty.ImmovableOwnerId);
    internal static ImmovableProperty.Builder CreateBuilderWithoutType() => CreateBuilderWithout(BuilderProperty.Type);
    internal static ImmovableProperty.Builder CreateBuilderWithoutSurface() => CreateBuilderWithout(BuilderProperty.Surface);
    internal static ImmovableProperty.Builder CreateBuilderWithoutArea() => CreateBuilderWithout(BuilderProperty.Area);
    internal static ImmovableProperty.Builder CreateBuilderWithoutRegion() => CreateBuilderWithout(BuilderProperty.Region);
    internal static ImmovableProperty.Builder CreateBuilderWithout(BuilderProperty propertyToSkip)
    {
        IDictionary<BuilderProperty, Action<ImmovableProperty.Builder>> setters = new Dictionary<BuilderProperty, Action<ImmovableProperty.Builder>>
        {
            [BuilderProperty.Id] = b => b.WithId(Id.Generate()),
            [BuilderProperty.Surface] = b => b.WithSurface(Surface.From(12.2M)),
            [BuilderProperty.Area] = b => b.WithArea(Area.From(12.4M)),
            [BuilderProperty.Region] = b => b.WithRegion(Region.From(12.5M))
        };

        var builder = new ImmovableProperty.Builder();
        foreach (BuilderProperty key in setters.Keys.Where(k => k != propertyToSkip))
        {
            setters[key](builder);
        }

        return builder;
    }
}
