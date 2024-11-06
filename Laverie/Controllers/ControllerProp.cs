using Laverie.DTO;
using LaverieEntities.IDAO;
using LaverieEntities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Laverie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerProp : ControllerBase
    {

          private readonly IDAOProprietaire _dao;
          public ControllerProp(IDAOProprietaire dao)
          {
              _dao = dao;
          }
        [HttpPost("ajouterProp")]
        public IActionResult AjouterProprietaire([FromQuery] DTOProprietaire dto)
        {
            bool success = _dao.AjouterProp(dto.ProprietaireId, dto.ProprietaireSurnom);

            if (success)
                return Ok("Propriétaire ajouté avec succès.");
            else
                return BadRequest("Échec de l'ajout du propriétaire.");
        }
        [HttpGet("getProps")]
        public IActionResult GetProprietaires()
        {
            var proprietaires = _dao.GetProprietaires();
            if (proprietaires == null || !proprietaires.Any())
                return NotFound("Aucun propriétaire trouvé.");

            return Ok(proprietaires);
        }
    }
    
}
