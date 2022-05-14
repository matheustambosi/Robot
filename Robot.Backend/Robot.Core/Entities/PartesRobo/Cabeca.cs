using Robot.Core.Enums.Estados;

namespace Robot.Core.Entities.PartesRobo
{
    public class Cabeca
    {
        public EstadoCabecaVertical EixoVertical { get; set; }
        public EstadoCabecaHorizontal EixoHorizontal { get; set; }

        public Cabeca(EstadoCabecaVertical eixoVertical, EstadoCabecaHorizontal eixoHorizontal)
        {
            EixoVertical = eixoVertical;
            EixoHorizontal = eixoHorizontal;
        }

        public void SetEixoVertical(int estado)
        {
            EixoVertical = (EstadoCabecaVertical)estado;
        }

        public void SetEixoHorizontal(int estado)
        {
            EixoHorizontal = (EstadoCabecaHorizontal)estado;
        }
    }
}
