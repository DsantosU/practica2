using Microsoft.AspNetCore.Mvc;
using Triplex.Validations;
using RI.Novus.Core.Asegurados.Asegurado;
using RI.Novus.Core.Boundaries.Persistence;
using WebApiExample.ViewModels;

namespace RI.Novus.WebApiExample.Controllers;


/// <summary>
/// Asegurados Controller
/// </summary>
[Route("api/asegurados")]
[ApiController]
public sealed class AseguradosController : ControllerBase
{
    private readonly IAseguradoRepository _Aseguradorepository;

    /// <summary>
    /// Set Repository
    /// </summary>
    /// <param name="aseguradoRepository"></param>
    public AseguradosController(IAseguradoRepository aseguradoRepository)
    {
        _Aseguradorepository = aseguradoRepository;
    }
    /// <summary>
    /// Get by name EndPoint
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {

        Arguments.NotEmpty(id, nameof(id));
        Asegurado asegurado = _Aseguradorepository.GetAseguradoById(Id.From(id));

        return Ok(AseguradoModel.FromEntity(asegurado));
    }

    /// <summary>
    /// Get all asegurados endpoint
    /// </summary>
    /// <returns></returns>

    [HttpGet]

    public IActionResult GetAsegurados()
    {
        ICollection<Asegurado> asegurados = _Aseguradorepository.GetAsegurados();

        return Ok(asegurados.Select(a => AseguradoModel.FromEntity(a)).ToList());
    }

    /// <summary>
    /// Persist controller
    /// </summary>
    /// <param name="aseguradoModel"></param>
    /// <returns></returns>

    [HttpPost]
    public IActionResult SaveAsegurado([FromBody] AseguradoModel aseguradoModel)
    {
        Asegurado asegurado = aseguradoModel.ToEntity();
        asegurado.Persist(_Aseguradorepository);

        return Ok();

    }
}
