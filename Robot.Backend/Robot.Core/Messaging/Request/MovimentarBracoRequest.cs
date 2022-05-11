using Robot.Core.Enums;

namespace Robot.Core.Messaging.Request
{
    public class MovimentarBracoRequest
    {
        public MembroCorpo MembroCorpo { get; set; }
        public int EstadoAtual { get; set; }
        public int ProximoEstado { get; set; }
    }
}
