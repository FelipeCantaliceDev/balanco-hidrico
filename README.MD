# Modelagem para realizar o monitoramento do balanço hidrico no paciente

Balanço hidrico é a quantidade de água adquirida ou perdida do paciente. 

Existem três casos:
* Balanço com saldo positivo > 0
* Balanço com saldo negativo < 0
* Balanço equilibrado == 0


## Resumo

Todo liquido seja entrada ou saida possui uma dosagem que é padrão, medida em mL.

```csharp
public abstract class Liquido
{
    public double dosagem { get; set; }

    public Liquido(double dosagem)
    {
        this.dosagem = dosagem;
    }
}
```

Existem dois tipos de liquidos
* Liquido de entrada
* Liquido de saida

```csharp

public class EntradaLiquido : Liquido
{
    public EntradaLiquido(double dosagem) : base(dosagem) { }
}


public class SaidaLiquido : Liquido
{
    public SaidaLiquido(double dosagem) : base(dosagem) { }
}

```


Sistema de monitoramento que armazena o balanço e o historico

```csharp
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
```