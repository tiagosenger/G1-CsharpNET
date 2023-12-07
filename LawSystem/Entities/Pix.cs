namespace Payments;
public class Pix : IPagamento
{
    public string Descricao {get; set;}
    public double ValorBruto {get; set;}
    public double Desconto {get; set;}
    public DateTime DataHora {get; set;}

    public Pix(string descricao, double valor){
        Descricao = descricao;
        ValorBruto = valor;
        Desconto = 10.0;
        DataHora = DateTime.Now;
    }

    public void RealizarPagamento(){
        Console.WriteLine("Pagamento via pix realizado com sucesso!");
    }

    public void toString(){
        Console.WriteLine($"Descrição: {Descricao}");
        Console.WriteLine($"Valor bruto: {ValorBruto}");
        Console.WriteLine($"Desconto: {Desconto}");
        Console.WriteLine($"Data e hora: {DataHora:dd/MM/yyyy}");
    }
}
