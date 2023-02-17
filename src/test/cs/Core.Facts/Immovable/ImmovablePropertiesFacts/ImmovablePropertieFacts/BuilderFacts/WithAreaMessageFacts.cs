using Optional.Unsafe;
using RI.Novus.Core.Immovable.ImmovableProperties;
using static RI.Novus.Core.Facts.Immovable.ImmovablePropertiesFacts.ImmovablePropertieFacts.CreateBuilderHelper;


namespace RI.Novus.Core.Facts.Immovable.ImmovablePropertiesFacts.ImmovablePropertieFacts.BuilderFacts
{
    internal class WithAreaMessageFacts : AbstractBuilderRequiredPropertySetterTestFixture<ImmovableProperty.Builder, ImmovableProperty, Area>
    {
        protected override Context BuildContext()
        {
            return new Context(empty: new ImmovableProperty.Builder(),
                missingTestedProperty: CreateBuilderWithoutArea(),
                used: CreateUsedBuilder(),
                toSetTwice: CreateBuilderWithoutArea(),
                firstValue: Area.From((123.45M)),
                secondValue: Area.From(123.3M));
        }
        protected override void SetProperty(ImmovableProperty.Builder builder, Area value)
            => builder.WithArea(value);
        protected override Area GetProperty(ImmovableProperty buildable) => buildable.Area.ValueOrDefault();

    }
}
