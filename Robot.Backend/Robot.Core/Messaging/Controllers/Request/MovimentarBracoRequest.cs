using Robot.Core.Enums;

namespace Robot.Core.Messaging.Controllers.Request
{
    public class MovimentarBracoRequest
    {
        public DirecaoBraco DirecaoBraco { get; set; }
        public MembroBraco MembroBraco { get; set; }
        public int ProximoEstado { get; set; }
    }
}
