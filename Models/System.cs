using Estados;

namespace Models
{
    public class Monitoramento
        {
            public double total { get; set;}
            List<Liquido> historico = new List<Liquido>();

            public Monitoramento(double total = 0.00)
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

}