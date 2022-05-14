using Robot.Core.Entities;
using Robot.Core.Enums;

namespace Robot.Core.Messaging.Services
{
    public class MovimentarCabecaServiceRequest
    {
        public Cabeca Cabeca { get; set; }
        public DirecaoCabeca Direcao { get; set; }
        public int ProximoEstado { get; set; }
    }
}
