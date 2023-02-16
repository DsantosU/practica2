using Triplex.Validations;
using RI.Novus.Core.Asegurados.Asegurado;
using Optional.Unsafe;

namespace WebApiExample.ViewModels;

/// <summary>
/// Asegurado Model
/// </summary>
public sealed class AseguradoModel
{
    /// <summary>
    /// Represents an identification.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Indicates asegurado name
    /// </summary>
    public string AseguradoName { get; set; }

    /// <summary>
    /// Indicates Identification Number
    /// </summary>

    public string IdentificationNumber { get; set; }

    /// <summary>
    /// Indicates Age
    /// </summary>
    public int Age { get; set; }

    /// <summary>
    /// Indicates Birthday
    /// </summary>
    public DateTimeOffset Birthday { get; set; }

    /// <summary>
    /// Converts to expedient entity
    /// </summary>
    /// <returns>An instance of <see cref="Asegurado"/></returns>

    public Asegurado ToEntity()
    {
        return new Asegurado.Builder()
               .WithId(RI.Novus.Core.Asegurados.Asegurado.Id.From(Id))
               .WithAseguradoName(RI.Novus.Core.Asegurados.Asegurado.AseguradoName.From(AseguradoName))
               .WithAge(RI.Novus.Core.Asegurados.Asegurado.Age.From(Age))
               .WithBirthday(RI.Novus.Core.Asegurados.Asegurado.Birthday.From(Birthday))
               .WithIdentificationNumber(RI.Novus.Core.Asegurados.Asegurado.IdentificationNumber.From(IdentificationNumber))
               .Build();
    }

    public static AseguradoModel FromEntity(Asegurado asegurado)
    {
        Arguments.NotNull(asegurado, nameof(asegurado));

        return new AseguradoModel()
        {
            Id = asegurado.Id.Map(id => id.Value).ValueOrDefault(),
            AseguradoName = asegurado.AseguradoName.AsPrimitive,
            Age = asegurado.Age.AsPrimitive,
            Birthday = asegurado.Birthday.AsPrimitive,
            IdentificationNumber = asegurado.IdentificationNumber.AsPrimitive,

        };
    }
}
