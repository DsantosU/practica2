using RI.Novus.Core.Asegurados.Asegurado;
using static RI.Novus.Core.Facts.Asegurados.AseguradoFacts.CreateBuilderHelper;

namespace RI.Novus.Core.Facts.Asegurados.AseguradoFacts.BuilderFacts;

internal sealed class WithBirthdayMessageFacts : AbstractBuilderRequiredPropertySetterTestFixture<Asegurado.Builder, Asegurado, Birthday>
{
    protected override Context BuildContext()
    {
        return new Context(
            empty: new Asegurado.Builder(),
            missingTestedProperty: CreateBuilderWithoutBirthday(), 
            used: CreateUsedBuilder(), 
            toSetTwice: CreateBuilderWithoutBirthday(), 
            firstValue: Birthday.From(DateTimeOffset.UtcNow.AddHours(-1)),
            secondValue: Birthday.From(DateTimeOffset.UtcNow.AddHours(-2))
        ); 
    }

    protected override void SetProperty(Asegurado.Builder builder, Birthday value)
        => builder.WithBirthday(value);

    protected override Birthday GetProperty(Asegurado buildable) => buildable.Birthday;
}
