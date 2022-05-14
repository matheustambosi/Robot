using Microsoft.AspNetCore.Mvc;
using Robot.Core.Exceptions;
using Robot.Core.FluentValidation.Validations;
using Robot.Core.Messaging.Controllers.Request;
using Robot.Core.Messaging.Request;
using Robot.Core.Services;
using System;

namespace Robot.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovimentarController : ControllerBase
    {
        private readonly RobotService _robotService;

        public MovimentarController(RobotService robotService, MovimentarCabecaValidation movimentarCabecaValidation)
        {
            _robotService = robotService;
        }

        [HttpGet]
        public Core.Entities.Robot GetRobot()
        {
            return _robotService.GetRobot();
        }

        [HttpPost("Cabeca")]
        public IActionResult MovimentarCabeca(MovimentarCabecaRequest request)
        {
            try
            {
                _robotService.MovimentarCabeca(new Core.Messaging.Services.MovimentarCabecaServiceRequest
                {
                    Direcao = request.Direcao,
                    ProximoEstado = request.ProximoEstado
                });

                return Ok();
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

        [HttpPost("Braco")]
        public IActionResult MovimentarBraco(MovimentarBracoRequest request)
        {
            try
            {
                _robotService.MovimentarBraco();
                return Ok();
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
