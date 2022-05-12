using Robot.Core.Enums;

namespace Robot.Core.Messaging.Request
{
    public class MovimentarCabecaRequest
    {
        public Direcao Direcao { get; set; }
        public int EstadoAtual { get; set; }
        public int ProximoEstado { get; set; }
    }
}
