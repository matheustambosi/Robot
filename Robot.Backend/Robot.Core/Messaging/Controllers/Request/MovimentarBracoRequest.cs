using Robot.Core.Enums;

namespace Robot.Core.Messaging.Controllers.Request
{
    public class MovimentarBracoRequest
    {
        public MembroBraco MembroCorpo { get; set; }
        public int EstadoAtual { get; set; }
        public int ProximoEstado { get; set; }
    }
}
