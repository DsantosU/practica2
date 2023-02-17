using Microsoft.AspNetCore.Mvc;
using RI.Novus.Core.Boundaries.Persistence;
using Triplex.Validations;
using WebApiExample.ViewModels;

namespace WebApiExample.Controllers
{
    [Route("api/expedients")]
    [ApiController]
    public class ExpedientsController : ControllerBase
    {
        private readonly IExpedientRepositoryDummy _expedientRepositoryDummy;

        public ExpedientsController(IExpedientRepositoryDummy expedientRepositoryDummy)
        {
            _expedientRepositoryDummy = expedientRepositoryDummy;
        }

        [HttpGet]
        public IActionResult GetByName(string expedientName)
        {
            Arguments.NotNull(expedientName, nameof(expedientName));

            RI.Novus.Core.CadastralSurvey.Expedients.Expedient expedient = _expedientRepositoryDummy.GetExpedientByName(expedientName);

            return Ok(ExpedientModel.FromEntity(expedient));
        }

        [HttpPost]

        public IActionResult SaveExpedient([FromBody] ExpedientModel expedientModel)
        {
            RI.Novus.Core.CadastralSurvey.Expedients.Expedient expedient = expedientModel.ToEntity();

            expedient.Persist(_expedientRepositoryDummy);

            return Ok();
        }

        [HttpPatch]

        public IActionResult UpdateExpedientName([FromBody] ExpedientModel expedientModel)
        {
            RI.Novus.Core.CadastralSurvey.Expedients.Expedient expedient = expedientModel.ToEntity();

            expedient.Update(_expedientRepositoryDummy);

            return Ok();
        }
    }
}
