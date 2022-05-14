using Robot.Core.Entities.PartesRobo;

namespace Robot.Core.Messaging.Controllers.Response
{
    public class GetRobotResponse
    {
        public Cabeca Cabeca { get; set; }
        public Braco BracoEsquerdo { get; set; }
        public Braco BracoDireito { get; set; }
    }
}
