using RI.Novus.Core.Boundaries.Persistence;
using RI.Novus.Core.Asegurados.Asegurado;

namespace Persistence.Repositories;

/// <summary>
/// <see cref="IAseguradoRepository"/> EF implementation.
/// </summary>
public sealed class AseguradoRepository : IAseguradoRepository
{
    
    private static ICollection<Models.Asegurado> asegurados = new List<Models.Asegurado>
    {
        new Models.Asegurado
        {
            AseguradoName = "Daniel",
            Age= 18,
            Birthday = DateTime.UtcNow,
            IdentificationNumber = "001-0000000-1",
            Id = Guid.NewGuid(),


        }
    };
    /// <inheritdoc/>
    public Asegurado GetAseguradoById(Id id)
    {
        Models.Asegurado asegurado = asegurados.FirstOrDefault(asegurado => asegurado.Id == id.Value);

        return asegurado.ToEntity();
    }

    /// <inheritdoc/>\\
    /// 

    public ICollection<Asegurado> GetAsegurados()
    {
        return asegurados.Select(a => a.ToEntity()).ToList();
    }

    /// <inheritdoc/>

    public void SaveAsegurado(Asegurado asegurado)
    {

        var aseguradoDatabaseModel = Models.Asegurado.FromEntity(asegurado);
        asegurados.Add(aseguradoDatabaseModel);
    }
}


