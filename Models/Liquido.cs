namespace Models
{
    public abstract class Liquido
        {
            public double dosagem { get; set; }

            public Liquido(double dosagem)
            {
                this.dosagem = dosagem;
            }
        }
}