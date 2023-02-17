using RI.Novus.Core.Immovable.ImmovableProperties;
using static RI.Novus.Core.Facts.Immovable.ImmovablePropertiesFacts.ImmovablePropertieFacts.CreateBuilderHelper;

namespace RI.Novus.Core.Facts.Immovable.ImmovablePropertiesFacts.ImmovablePropertieFacts.BuilderFacts;

internal sealed class WithSurfaceMessageFacts : AbstractBuilderRequiredPropertySetterTestFixture<ImmovableProperty.Builder, ImmovableProperty, Surface>
{
        protected override Context BuildContext()
    {
        return new Context(empty: new ImmovableProperty.Builder(),
            missingTestedProperty: CreateBuilderWithoutSurface(),
            used: CreateUsedBuilder(),
            toSetTwice: CreateBuilderWithoutSurface(),
            firstValue: Surface.From((123.45M)),
            secondValue: Surface.From(123.3M));
    }
    protected override void SetProperty(ImmovableProperty.Builder builder, Surface value)
        => builder.WithSurface(value);
    protected override Surface GetProperty(ImmovableProperty buildable) => buildable.Surface;
}

