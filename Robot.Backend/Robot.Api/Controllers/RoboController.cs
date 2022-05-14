using Microsoft.AspNetCore.Mvc;
using Robot.Core.Exceptions;
using Robot.Core.FluentValidation.Validations;
using Robot.Core.Messaging.Controllers.Request;
using Robot.Core.Messaging.Controllers.Response;
using Robot.Core.Messaging.Request;
using Robot.Core.Messaging.Services;
using Robot.Core.Services;
using System;

namespace Robot.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoboController : ControllerBase
    {
        private readonly RobotService _robotService;

        public RoboController(RobotService robotService, MovimentarCabecaValidation movimentarCabecaValidation)
        {
            _robotService = robotService;
        }

        [HttpGet]
        public GetRobotResponse GetRobot()
        {
            return _robotService.GetRobot();
        }

        [HttpPost("Movimentar/Cabeca")]
        public IActionResult MovimentarCabeca(MovimentarCabecaRequest request)
        {
            try
            {
                _robotService.MovimentarCabeca(new MovimentarCabecaServiceRequest(request));

                return NoContent();
            }
            catch (RobotException robotEx)
            {
                return BadRequest(robotEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Movimentar/Braco")]
        public IActionResult MovimentarBraco([FromBody] MovimentarBracoRequest request)
        {
            try
            {
                _robotService.MovimentarBraco(new MovimentarBracoServiceRequest(request));

                return NoContent();
            }
            catch (RobotException robotEx)
            {
                return BadRequest(robotEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
