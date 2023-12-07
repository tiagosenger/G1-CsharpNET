namespace Payments;
public class Dinheiro : IPagamento
{
    public string Descricao {get; set;}
    public double ValorBruto {get; set;}
    public double Desconto {get; set;}
    public DateTime DataHora {get; set;}

    public Dinheiro(string descricao, double valor) {
        Descricao = descricao;
        ValorBruto = valor;
        DataHora = DateTime.Now;
        Desconto = 5.0;
    }

    public void RealizarPagamento(){
        Console.WriteLine("Pagameto por dinheiro realizado com sucesso!");
    }

    public void toString(){
        Console.WriteLine($"Descrição: {Descricao}");
        Console.WriteLine($"Valor bruto: {ValorBruto}");
        Console.WriteLine($"Desconto: {Desconto}");
        Console.WriteLine($"Data e hora: {DataHora:dd/MM/yyyy}");
    }
}
