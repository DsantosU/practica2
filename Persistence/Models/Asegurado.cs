using Optional.Unsafe;
using Triplex.Validations;



namespace Persistence.Models;

/// <summary>
/// Represents the database representation for an asegurado/>.
/// </summary>
public sealed class Asegurado
{

    /// <summary>
    /// Surrogate key.
    /// </summary>
    /// <value></value>
    public Guid Id { get; set; }

    /// <summary>
    ///  Asegurado Name.
    /// </summary>
    /// <value></value>

    public string AseguradoName { get; set; } = string.Empty;

    /// <inheritdoc cref="Core.Asegurados.Asegurado.IdentificationNumber"/>

    public string IdentificationNumber { get; set; } = string.Empty;

    /// <inheritdoc cref="Core.Asegurados.Asegurado.Age"/>
    public int Age { get; set; }


    /// <inheritdoc cref="Core.Asegurados.Asegurado.Birthday"/>
    public DateTimeOffset Birthday { get; set; } = DateTimeOffset.Now;

    /// <summary>
    /// Converts current model to asegurado entity
    /// </summary>
    /// <returns></returns>
    public RI.Novus.Core.Asegurados.Asegurado.Asegurado ToEntity()
    {
        return new RI.Novus.Core.Asegurados.Asegurado.Asegurado.Builder()
                       .WithId(RI.Novus.Core.Asegurados.Asegurado.Id.From(Id))
                       .WithAseguradoName(RI.Novus.Core.Asegurados.Asegurado.AseguradoName.From(AseguradoName))
                       .WithAge(RI.Novus.Core.Asegurados.Asegurado.Age.From(Age))
                       .WithBirthday(RI.Novus.Core.Asegurados.Asegurado.Birthday.From(Birthday))
                       .WithIdentificationNumber(RI.Novus.Core.Asegurados.Asegurado.IdentificationNumber.From(IdentificationNumber))
                       .Build();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="asegurado"></param>
    /// <returns></returns>
    public static Asegurado FromEntity(RI.Novus.Core.Asegurados.Asegurado.Asegurado asegurado)
    {
        Arguments.NotNull(asegurado, nameof(asegurado));

        return new Asegurado
        {
            Id = asegurado.Id.Map(id => id.Value).ValueOrDefault(),
            AseguradoName = asegurado.AseguradoName.AsPrimitive,
            Age = asegurado.Age.AsPrimitive,
            Birthday = asegurado.Birthday.AsPrimitive,
            IdentificationNumber = asegurado.IdentificationNumber.AsPrimitive,

        };

    }
}
