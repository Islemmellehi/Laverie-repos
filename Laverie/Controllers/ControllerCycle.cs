using Laverie.DTO;
using LaverieEntities.IDAO;
using LaverieEntities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Laverie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerCycle : ControllerBase
    {
        private readonly IDAOCycle _dao;
        public ControllerCycle(IDAOCycle dao)
        {
            _dao = dao;
        }
        [HttpPost("ajouterCycle")]
        public IActionResult AjouterLaverie([FromQuery] DTOCycle dto)
        {
            bool success = _dao.AjouterCycle(dto.IdCycle, dto.NomCycle, dto.DureeCycleHR,dto.coutCycle);

            if (success)
                return Ok("Cycle ajoutée avec succès.");
            else
                return BadRequest("Échec de l'ajout du cycle.");
        }
        [HttpGet("getCycles")]
        public IActionResult GetCycles()
        {
            var cs = _dao.GetCycles();
            if (cs== null || !cs.Any())
                return NotFound("Aucun cycle trouvé.");

            return Ok(cs);
        }

    }
}
