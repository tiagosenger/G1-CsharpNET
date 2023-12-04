using System.Diagnostics.Metrics;

class ListAndReports{
    public void advogadosFaixaIdade(Advogados advogados)
    {
        Console.WriteLine("Informe a idade míninma: ");
        int min = Convert.ToInt16(Console.ReadLine());

        Console.WriteLine("Informe a idade máxima: ");
        int max = Convert.ToInt16(Console.ReadLine());
        
        var correspondencias = advogados.Where(x => x.DataNascimento >= DateTime.Now.Year - min && x <= DateTime.Now.Year - max).ToList();
        if (correspondencias == null)
        {
            Console.WriteLine("Não há advogados com essa faixa de idade.");
        }
        else
        {
            foreach (var x in correspondencias)
            {
                Console.WriteLine(x);
            }
        }
        
    }
    public void clientesFaixaDeIdade(Cliente cliente)
    {
        Console.WriteLine("Informe a idade míninma: ");
        int min = Convert.ToInt16(Console.ReadLine());

        Console.WriteLine("Informe a idade máxima: ");
        int max = Convert.ToInt16(Console.ReadLine());

        var correspondencias = cliente.Where(x => x.DataNascimento >= DateTime.Now.Year - min && x <= DateTime.Now.Year - max).ToList();
        if (correspondencias == null)
        {
            Console.WriteLine("Não há clientes com essa faixa de idade.");
        }
        else
        {
            foreach (var x in correspondencias)
            {
                Console.WriteLine(x);
            }
        }
    }
    

}