namespace Robot.Core.Entities.PartesRobo
{
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
}
