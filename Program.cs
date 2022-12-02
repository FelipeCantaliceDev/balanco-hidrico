using Models;

namespace Main
{
    public class Program
    {        
    
        public static void Main()
        {

            var system = new Monitoramento();

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