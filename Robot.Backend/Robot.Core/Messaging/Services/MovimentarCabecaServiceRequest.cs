using Robot.Core.Entities.PartesRobo;
using Robot.Core.Enums;
using Robot.Core.Messaging.Request;

namespace Robot.Core.Messaging.Services
{
    public class MovimentarCabecaServiceRequest
    {
        public Cabeca Cabeca { get; set; }
        public DirecaoCabeca Direcao { get; set; }
        public int ProximoEstado { get; set; }

        public MovimentarCabecaServiceRequest(MovimentarCabecaRequest request)
        {
            Direcao = request.Direcao;
            ProximoEstado = request.ProximoEstado;
        }

        public MovimentarCabecaServiceRequest(MovimentarCabecaRequest request, Cabeca cabeca)
        {
            Direcao = request.Direcao;
            ProximoEstado = request.ProximoEstado;
            Cabeca = cabeca;
        }
    }
}
