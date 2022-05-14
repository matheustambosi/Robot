using Robot.Core.Entities.PartesRobo;
using Robot.Core.Enums;
using Robot.Core.Messaging.Controllers.Request;

namespace Robot.Core.Messaging.Services
{
    public class MovimentarBracoServiceRequest
    {
        public Braco Braco { get; set; }
        public DirecaoBraco Direcao { get; set; }
        public MembroBraco MembroBraco { get; set; }
        public int ProximoEstado { get; set; }

        public MovimentarBracoServiceRequest(MovimentarBracoRequest request)
        {
            Direcao = request.DirecaoBraco;
            MembroBraco = request.MembroBraco;
            ProximoEstado = request.ProximoEstado;
        }

        public MovimentarBracoServiceRequest(MovimentarBracoRequest request, Braco braco)
        {
            Direcao = request.DirecaoBraco;
            MembroBraco = request.MembroBraco;
            ProximoEstado = request.ProximoEstado;
            Braco = braco;
        }
    }
}
