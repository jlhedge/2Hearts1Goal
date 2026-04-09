using Microsoft.AspNetCore.Mvc;

namespace _2Hearts1Goal.Api.Controllers;

[ApiController]
[Route("api/meta")]
public sealed class MetaController : ControllerBase
{
    [HttpGet("info")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<object> GetInfo()
    {
        return Ok(new
        {
            application = "2Hearts1Goal",
            architecture = "Modular monolith",
            backend = ".NET 10 Web API",
            database = "SQL Server",
            cloudTargets = new[] { "Azure SQL", "AWS RDS for SQL Server" }
        });
    }
}
