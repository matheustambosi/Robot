using Robot.Core.Enums;

namespace Robot.Core.Entities
{
    public class Robot
    {
        public Cabeca Cabeca { get; set; }
        public Braco BracoEsquerdo { get; set; }
        public Braco BracoDireito { get; set; }

        public Robot()
        {
            Cabeca = new Cabeca(EstadoCabecaVertical.Repouso, 0);
            BracoEsquerdo = new Braco(new Cotovelo { Estado = EstadoCotovelo.EmRepouso }, new Pulso { });
            BracoDireito = new Braco(new Cotovelo { Estado = EstadoCotovelo.EmRepouso }, new Pulso { });
        }
    }

    public class Cabeca
    {
        public EstadoCabecaVertical EixoVertical { get; set; }
        public int EixoHorizontal { get; set; }

        public Cabeca(EstadoCabecaVertical eixoVertical, int eixoHorizontal)
        {
            EixoVertical = eixoVertical;
            EixoHorizontal = eixoHorizontal;
        }
    }

    public class Braco
    {
        public Cotovelo Cotovelo { get; set; }
        public Pulso Pulso { get; set; }

        public Braco(Cotovelo cotovelo, Pulso pulso)
        {
            Cotovelo = cotovelo;
            Pulso = pulso;
        }
    }

    public class Cotovelo
    {
        public EstadoCotovelo Estado { get; set; }
    }

    public class Pulso
    {
        public EstadoPulso Estado { get; set; }
    }
}
