using Robot.Core.Enums.Estados;

namespace Robot.Core.Entities.PartesRobo
{
    public class Cotovelo
    {
        public EstadoCotovelo Estado { get; set; }

        public Cotovelo(EstadoCotovelo estado)
        {
            Estado = estado;
        }

        public void SetEstadoCotovelo(int estado)
        {
            Estado = (EstadoCotovelo)estado;
        }
    }
}
