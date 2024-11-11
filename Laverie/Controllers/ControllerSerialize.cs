using Laverie.Infrastructure.DAOImp;
using LaverieEntities.IDAO;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ControllerSerialize : ControllerBase
{
    private readonly IDAOSerialize _dao;
    public ControllerSerialize(IDAOSerialize dao)
    {
        _dao = dao;
    }
    [HttpGet("GetAllData")]
    public IActionResult GetAllData()
    {
        try
        {
            var data = _dao.GetAllData();
            return Ok(data);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
