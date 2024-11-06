using Laverie.DTO;
using LaverieEntities.IDAO;
using LaverieEntities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Laverie.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ControllerLaverie : ControllerBase
    {
        private readonly IDAOLaverie _dao;
        public ControllerLaverie(IDAOLaverie dao)
        {
            _dao = dao;
        }
        [HttpPost("ajouterLav")]
        public IActionResult AjouterLaverie([FromQuery] DTOLaverie dto)
        {
            bool success = _dao.AjouterLaverie(dto.LavID);

            if (success)
                return Ok("Laverie ajoutée avec succès.");
            else
                return BadRequest("Échec de l'ajout du Laverie.");
        }
        [HttpGet("getLavs")]
        public IActionResult GetLaveries()
        {
            var laveries = _dao.GetLaveries();
            if (laveries == null || !laveries.Any())
                return NotFound("Aucun propriétaire trouvé.");

            return Ok(laveries);

        }
        [HttpPost("affecterLavier")]
        public IActionResult AffecterLavierProp([FromQuery] DTOAffectLP dto)
        {
            if (dto == null)
            {
                return BadRequest("Données d'affectation invalides.");
            }

            bool success = _dao.AffecterLavierProp(dto.LavID,dto.ProprietaireId);

            if (success)
                return Ok("Laverie affectée avec succès.");
            else
                return BadRequest("Échec de l'affectation de la laverie.");
        }

    }
    

}
