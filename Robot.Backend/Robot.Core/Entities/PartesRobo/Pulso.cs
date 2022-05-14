using Robot.Core.Enums.Estados;

namespace Robot.Core.Entities.PartesRobo
{
    public class Pulso
    {
        public EstadoPulso Estado { get; set; }

        public Pulso(EstadoPulso estado)
        {
            Estado = estado;
        }

        public void SetEstadoPulso(int estado)
        {
            Estado = (EstadoPulso)estado;
        }
    }
}
