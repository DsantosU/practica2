using Optional.Unsafe;
using RI.Novus.Core.Immovable.ImmovableProperties;
using static RI.Novus.Core.Facts.Immovable.ImmovablePropertiesFacts.ImmovablePropertieFacts.CreateBuilderHelper;


namespace RI.Novus.Core.Facts.Immovable.ImmovablePropertiesFacts.ImmovablePropertieFacts.BuilderFacts
{
    internal class WithRegionMessageFacts : AbstractBuilderRequiredPropertySetterTestFixture<ImmovableProperty.Builder, ImmovableProperty, Region>
    {
        protected override Context BuildContext()
        {
            return new Context(empty: new ImmovableProperty.Builder(),
                missingTestedProperty: CreateBuilderWithoutRegion(),
                used: CreateUsedBuilder(),
                toSetTwice: CreateBuilderWithoutRegion(),
                firstValue: Region.From((123.45M)),
                secondValue: Region.From(123.3M));
        }
        protected override void SetProperty(ImmovableProperty.Builder builder, Region value)
            => builder.WithRegion(value);
        protected override Region GetProperty(ImmovableProperty buildable) => buildable.Region.ValueOrDefault();
   
    }
}
