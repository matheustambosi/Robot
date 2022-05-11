using Microsoft.AspNetCore.Mvc;
using Robot.Core.Messaging.Request;

namespace Robot.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovimentarController : ControllerBase
    {
        [HttpPost("Cabeca")]
        public IActionResult MovimentarCabeca(MovimentarCabecaRequest request)
        {
            return Ok();
        }

        [HttpPost("Braco")]
        public IActionResult MovimentarBraco(MovimentarBracoRequest request)
        {
            return Ok();
        }
    }
}
