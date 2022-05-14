using Robot.Core.Enums;
using Robot.Core.FluentValidation.Validations;
using Robot.Core.Messaging.Services;

namespace Robot.Core.Services
{
    public class RobotService
    {
        private Entities.Robot _robot;
        private readonly MovimentarCabecaValidation _movimentarCabecaValidation;

        public RobotService()
        {
            _robot = new Entities.Robot();
            _movimentarCabecaValidation = new MovimentarCabecaValidation();
        }

        public Entities.Robot GetRobot()
        {
            return _robot;
        }

        public void MovimentarCabeca(MovimentarCabecaServiceRequest request)
        {
            request.Cabeca = _robot.Cabeca;
            _movimentarCabecaValidation.ValidateAsync(request);

            switch (request.Direcao)
            {
                case DirecaoCabeca.Vertical:
                    _robot.Cabeca.EixoVertical = (EstadoCabecaVertical)request.ProximoEstado;
                    break;
                case DirecaoCabeca.Horizontal:
                    _robot.Cabeca.EixoHorizontal = request.ProximoEstado;
                    break;
            }
        }

        public void MovimentarBraco()
        {

        }
    }
}
