using Models;

namespace Main
{
    public class Program
    {

        public static void Main()
        {
            // Cria um sistema de monitoramento
            var system = new Monitoramento();

            // Liquidos administrados no periodo de 24 horas
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

            // Insere todos os elementos
            foreach (var item in lista)
            {
                system.incluir(item);
            }


            // Verifica o balanço
            Console.WriteLine(system.total);
            // Verifica o estado do balanço
            Console.WriteLine(system.estado());
            // Verifica todos os liquidos adminstrados
            foreach (var liquido in system.administrados())
            {
                Console.WriteLine(liquido.dosagem);
            }

            // Verifica todos os liquidos perdidos
            foreach (var liquido in system.perdidos())
            {
                Console.WriteLine(liquido.dosagem);
            }

        }
    }
}