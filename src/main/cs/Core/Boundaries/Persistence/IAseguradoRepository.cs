using System.Collections.Generic;
using RI.Novus.Core.Asegurados.Asegurado;

namespace RI.Novus.Core.Boundaries.Persistence;

/// <summary>Repository to work with <see cref="Asegurado"/>s.</summary>

public interface IAseguradoRepository
{

    /// <summary>
    /// Gets asegurado by name
    /// </summary>
    /// <param id="id">Expedient name</param>
    /// <returns>An instance of <see cref="Asegurado"></returns>
   Asegurado GetAseguradoById(Id Id);

    /// <summary>
    /// Get all asegurados
    /// </summary>
    /// <returns></returns>
   ICollection<Asegurado> GetAsegurados();

    /// <summary>
    /// Persist a given Asegurado
    /// </summary>
    /// <param name="Asegurado">Asegurado to be persistent</param>
   void SaveAsegurado(Asegurado Asegurado);

}
