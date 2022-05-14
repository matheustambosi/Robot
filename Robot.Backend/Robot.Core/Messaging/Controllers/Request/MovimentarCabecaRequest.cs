using Robot.Core.Enums;

namespace Robot.Core.Messaging.Request
{
    public class MovimentarCabecaRequest
    {
        public DirecaoCabeca Direcao { get; set; }
        public int ProximoEstado { get; set; }
    }
}
