using Robot.Core.Entities;
using Robot.Core.Enums;

namespace Robot.Core.Messaging.Services
{
    class MovimentarBracoServiceRequest
    {
        public Braco Braco { get; set; }
        public DirecaoBraco Direcao { get; set; }
        public MembroBraco MembroCorpo { get; set; }
        public int ProximoEstado { get; set; }
    }
}
