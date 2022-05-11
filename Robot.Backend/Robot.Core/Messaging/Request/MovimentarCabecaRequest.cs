using Robot.Core.Enums;

namespace Robot.Core.Messaging.Request
{
    public class MovimentarCabecaRequest
    {
        public MembroCorpo MembroCorpo { get; set; }
        public Direcao Direcao { get; set; }
        public int EstadoAtual { get; set; }
        public int ProximoEstado { get; set; }
    }
}
