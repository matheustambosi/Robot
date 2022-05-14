using Robot.Core.Enums;
using Robot.Core.FluentValidation.Validations;
using Robot.Core.Messaging.Controllers.Response;
using Robot.Core.Messaging.Services;

namespace Robot.Core.Services
{
    public class RobotService
    {
        private Entities.Robot _robot;
        private readonly MovimentarCabecaValidation _movimentarCabecaValidation;
        private readonly MovimentarBracoValidation _movimentarBracoValidation;

        public RobotService()
        {
            _robot = new Entities.Robot();
            _movimentarCabecaValidation = new MovimentarCabecaValidation();
            _movimentarBracoValidation = new MovimentarBracoValidation();
        }

        public GetRobotResponse GetRobot()
        {
            return new GetRobotResponse
            {
                Cabeca = _robot.GetCabeca(),
                BracoEsquerdo = _robot.GetBraco(DirecaoBraco.Esquerda),
                BracoDireito = _robot.GetBraco(DirecaoBraco.Direita)
            };
        }

        public void MovimentarCabeca(MovimentarCabecaServiceRequest request)
        {
            request.Cabeca = _robot.GetCabeca();
            _movimentarCabecaValidation.ValidateAsync(request);

            switch (request.Direcao)
            {
                case DirecaoCabeca.Vertical:
                    _robot.Cabeca.SetEixoVertical(request.ProximoEstado);
                    break;
                case DirecaoCabeca.Horizontal:
                    _robot.Cabeca.SetEixoHorizontal(request.ProximoEstado);
                    break;
            }
        }

        public void MovimentarBraco(MovimentarBracoServiceRequest request)
        {
            var braco = _robot.GetBraco(request.Direcao);
            request.Braco = braco;
            _movimentarBracoValidation.ValidateAsync(request);

            switch (request.MembroBraco)
            {
                case MembroBraco.Cotovelo:
                    braco.Cotovelo.SetEstadoCotovelo(request.ProximoEstado);
                    break;
                case MembroBraco.Pulso:
                    braco.Pulso.SetEstadoPulso(request.ProximoEstado);
                    break;
            }
        }
    }
}
