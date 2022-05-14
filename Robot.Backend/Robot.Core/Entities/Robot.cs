using Robot.Core.Entities.PartesRobo;
using Robot.Core.Enums;
using Robot.Core.Enums.Estados;

namespace Robot.Core.Entities
{
    public class Robot
    {
        public Cabeca Cabeca { get; set; }
        public Braco BracoEsquerdo { get; set; }
        public Braco BracoDireito { get; set; }

        public Robot()
        {
            Cabeca = new Cabeca(EstadoCabecaVertical.EmRepouso, EstadoCabecaHorizontal.EmRepouso);
            BracoEsquerdo = new Braco(new Cotovelo(EstadoCotovelo.EmRepouso), new Pulso(EstadoPulso.EmRepouso));
            BracoDireito = new Braco(new Cotovelo(EstadoCotovelo.EmRepouso), new Pulso(EstadoPulso.EmRepouso));
        }

        public Cabeca GetCabeca() => Cabeca;
        public Braco GetBraco(DirecaoBraco direcaoBraco)
        {
            return direcaoBraco switch
            {
                DirecaoBraco.Esquerda => BracoEsquerdo,
                DirecaoBraco.Direita => BracoDireito,
                _ => new Braco(new Cotovelo(EstadoCotovelo.EmRepouso), new Pulso(EstadoPulso.EmRepouso))
            };
        }
    }
}
