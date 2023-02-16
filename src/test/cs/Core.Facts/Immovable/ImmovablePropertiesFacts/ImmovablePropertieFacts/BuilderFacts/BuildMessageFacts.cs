﻿using RI.Novus.Core.Immovable.ImmovableProperties;
using static RI.Novus.Core.Facts.Immovable.ImmovablePropertiesFacts.ImmovablePropertieFacts.CreateBuilderHelper;

namespace RI.Novus.Core.Facts.Immovable.ImmovablePropertiesFacts.ImmovablePropertieFacts.BuilderFacts;

[TestFixture]
internal sealed class BuildMessageFacts
{
    [Test]
    public void With_Missing_Required_Property_Throws_InvalidOperationException([Values] BuilderProperty missingProperty) {
        Assume.That(missingProperty, Is.Not.EqualTo(BuilderProperty.None)
                                   .And.Not.EqualTo(BuilderProperty.Id));

        ImmovableProperty.Builder builder = CreateBuilderWithout(missingProperty);

        Assert.That(() => builder.Build(), Throws.InvalidOperationException);
    }

    [Test]
    public void With_All_Required_Throws_Nothing([Values(BuilderProperty.None, BuilderProperty.Id)] in BuilderProperty missingProperty) {
        ImmovableProperty.Builder builder = CreateBuilderWithout(missingProperty);

        Assert.That(() => builder.Build(), Throws.Nothing);
    }
}
