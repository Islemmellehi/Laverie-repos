using Laverie.DTO;
using LaverieEntities.IDAO;
using LaverieEntities.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.PortableExecutable;

namespace Laverie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerMachine: ControllerBase
    {
        private readonly IDAOMachine _dao;
        public ControllerMachine(IDAOMachine dao)
        {
            _dao = dao;
        }
        [HttpPost("ajouterMachine")]
        public IActionResult AjouterLaverie([FromQuery] DTOMachine dto)
        {
            bool success = _dao.AjouterMachine(dto.IDMA,dto.marque,dto.etat);

            if (success)
                return Ok("Machine ajoutée avec succès.");
            else
                return BadRequest("Échec de l'ajout de la machine.");
        }
        [HttpGet("getMachines")]
        public IActionResult GetMachines()
        {
            var machines= _dao.GetMachines();
            if (machines == null || !machines.Any())
                return NotFound("Aucun propriétaire trouvé.");

            return Ok(machines);
        }
        [HttpPost("affecterMachine")]
        public IActionResult AffecterMachineLav([FromQuery] DTOAffectML dto)
        {
            if (dto == null)
            {
                return BadRequest("Données d'affectation invalides.");
            }

            bool success = _dao.AffecterMachineLav(dto.IdMachine, dto.IdLaverie);

            if (success)
                return Ok("Machine affectée avec succès.");
            else
                return BadRequest("Échec de l'affectation de la machine.");
        }
    }

}
