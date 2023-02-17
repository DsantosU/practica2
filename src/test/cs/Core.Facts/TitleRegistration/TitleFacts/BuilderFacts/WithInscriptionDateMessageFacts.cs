using static RI.Novus.Core.Facts.TitleRegistration.TitleFacts.CreateBuilderHelper;

using RI.Novus.Core.TitleRegistration;

namespace RI.Novus.Core.Facts.TitleRegistration.TitleFacts.BuilderFacts;

internal class WithCreatedMessageFacts : 
    AbstractBuilderRequiredPropertySetterTestFixture<Title.Builder, Title, InscriptionDate>
{
    protected override Context BuildContext()
    {
        return new Context(empty: new Title.Builder(),
            missingTestedProperty: CreateBuilderWithoutInscriptionDate(),
            used: CreateUsedBuilder(),
            toSetTwice: CreateBuilderWithoutInscriptionDate(),
            firstValue: InscriptionDate.From(DateTimeOffset.UtcNow.AddHours(-1)),
            secondValue: InscriptionDate.From(DateTimeOffset.UtcNow.AddHours(-2)));
    }

    protected override void SetProperty(Title.Builder builder, InscriptionDate value)
        => builder.WithInscriptionDate(value);

    protected override InscriptionDate GetProperty(Title buildable) => buildable.InscriptionDate;
}
