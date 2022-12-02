namespace Main
{
    public class Program
    {
        // resultado do estado paciente
        public enum EstadoBalanco{
            NEUTRO,
            POSITIVO,
            NEGATIVO
        }
        // liquido referente ao paciente
        public abstract class Liquido
        {
            public double dosagem { get; set; }

            public Liquido(double dosagem)
            {
                this.dosagem = dosagem;
            }
        }
        // liquido adquirido no paciente
        public class EntradaLiquido : Liquido
        {
            public EntradaLiquido(double dosagem) : base(dosagem) { }
        }
        // liquido perdido no paciente

        public class SaidaLiquido : Liquido
        {
            public SaidaLiquido(double dosagem) : base(dosagem) { }
        }

        // sistema

        public class System
        {
            public double total { get; set;}
            List<Liquido> historico = new List<Liquido>();

            public System(double total = 0.00)
            {
                this.total = total;
            }

            public void incluir(Liquido liquido)
            {
                if(liquido is EntradaLiquido){
                    total += liquido.dosagem;
                } else if(liquido is SaidaLiquido){
                    total -= liquido.dosagem;
                } else{
                    throw new Exception("Invalido!");
                }
                historico.Add(liquido);
            }

            public EstadoBalanco estado(){
                if(this.total > 0)
                    return EstadoBalanco.POSITIVO;
                if(this.total < 0)
                    return EstadoBalanco.NEGATIVO;
                
                return EstadoBalanco.NEUTRO;
            }
        
            List<Liquido> administrados() => historico.FindAll(e => e is EntradaLiquido);
            List<Liquido> perdidos() => historico.FindAll(e => e is SaidaLiquido);

        }

        // Main
        public static void Main()
        {

            var system = new System();

            var lista = new List<Liquido>{
                new EntradaLiquido(10.0),
                new SaidaLiquido(9.0),
                new SaidaLiquido(20.0),
                new SaidaLiquido(1.0),
                new EntradaLiquido(12.9),
                new EntradaLiquido(7.4),
                new SaidaLiquido(3.2),
                new EntradaLiquido(4.6),
                new SaidaLiquido(1.7),
                new SaidaLiquido(9.1),
                new EntradaLiquido(9.1),
            };

            foreach (var item in lista)
            {
                system.incluir(item);
            }

            Console.WriteLine(system.total);
            Console.WriteLine(system.estado());

        }
    }
}