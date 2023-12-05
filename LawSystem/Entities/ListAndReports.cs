using System.Collections;

class ListAndReports
{
    public void advogadosFaixaIdade(Advogados advogados)
    {
        Console.WriteLine("Informe a idade míninma: ");
        int min = Convert.ToInt16(Console.ReadLine());

        Console.WriteLine("Informe a idade máxima: ");
        int max = Convert.ToInt16(Console.ReadLine());

        var correspondencias = advogados.Where(x => x.DataNascimento.Year >= DateTime.Now.Year - min && x.DataNascimento.Year <= DateTime.Now.Year - max).ToList();
        if (correspondencias == null)
        {
            Console.WriteLine("Não há advogados com essa faixa de idade.");
        }
        else
        {
            Console.WriteLine("Lista de advogados com essa faixa de idade: ");
            int counter = 1;
            foreach (var x in correspondencias)
            {
                Console.WriteLine(counter + ". " + x);
                counter += 1;
            }
        }

    }
    public void clientesFaixaDeIdade(Cliente cliente)
    {
        Console.WriteLine("Informe a idade míninma: ");
        int min = Convert.ToInt16(Console.ReadLine());

        Console.WriteLine("Informe a idade máxima: ");
        int max = Convert.ToInt16(Console.ReadLine());

        var correspondencias = cliente.Where(x => x.DataNascimento.Year >= DateTime.Now.Year - min && x.DataNascimento.Year <= DateTime.Now.Year - max).ToList();
        if (correspondencias == null)
        {
            Console.WriteLine("Não há clientes com essa faixa de idade.");
        }
        else
        {
            Console.WriteLine("Lista de clientes com esta faixa de idade: ");
            int counter = 1;
            foreach (var x in correspondencias)
            {
                Console.WriteLine(counter + ". " + x);
                counter += 1;
            }
        }
    }
    public void clientesEstadocivilInformado(Cliente cliente)
    {
        var correspondencias = cliente.Any(x => x.EstadoCivil == estadocivil).Tolist();
        if (correspondencias == null)
        {
            Console.WriteLine("Não há clientes com este estado civil.");
        }
        else
        {
            Console.WriteLine("Lista de clientes com o estado civil selecionado: ");
            int counter = 1;
            foreach (var x in correspondencias)
            {
                Console.WriteLine(counter + ". " + x);
                counter += 1;
            }
        }
    }
    public void clientesOrdemAlfabetica(Cliente cliente)
    {

        var listaOrdenada = cliente.Lista;
        listaOrdenada.Sort();

        Console.WriteLine("Lista de clientes em ordem alfabética: ");
        int counter = 1;
        foreach (var x in listaOrdenada)
        {
            Console.WriteLine(counter + ". " + x);
            counter += 1;
        }
    }
    public void clientesProfissaoSelecionada(Cliente cliente)
    {
        Console.WriteLine("Informe a profissão a ser critério de filtro: ");
        string profissao = Console.ReadLine()!.ToLower();
        var correspondencias = cliente.Any(x => x.Profissao.ToLower() == profissao).ToList();
        if (correspondencias == null)
        {
            Console.WriteLine("Não há clientes com essa profissão.");
        }
        else
        {
            Console.WriteLine("Lista de clientes com a profissão selecionada: ");
            int counter = 1;
            foreach (var x in correspondencias)
            {
                Console.WriteLine(counter + ". " + x);
                counter += 1;
            }
        }
    }
    public void MesAniversario(Cliente cliente, Advogado advogado)
    {
        Console.WriteLine("Informe o mês a filtrar: ");
        int mes = Convert.ToInt16(Console.ReadLine());

        var correspondenciasAdvogado = advogado.Any(x => x.DataNascimento.Month == mes).Tolist();
        var correspondenciasCliente = cliente.Any(x => x.DataNascimento.Month == mes).Tolist();
        if (correspondenciasAdvogado == null)
        {
            Console.WriteLine("Não há advogados aniversariando este neste mês.");
        }
        else
        {
            Console.WriteLine("Lista de advogados aniversariando este mês: ");
            int counter = 1;
            foreach (var x in correspondenciasAdvogado)
            {
                Console.WriteLine(counter + ". " + x);
                counter += 1;
            }
        }
        Console.WriteLine();

        if (correspondenciasCliente == null)
        {
            Console.WriteLine("Não há clientes aniversariando este neste mês.");
        }
        else
        {
            Console.WriteLine("Lista de clientes aniversariando este mês: ");
            int counter = 1;
            foreach (var x in correspondenciasCliente)
            {
                Console.WriteLine(counter + ". " + x);
                counter += 1;
            }
        }
    }
    public void casosAbertos(Casos casos)
    {

        List<Casos> listaOrdenada = casos.Lista.OrderBy(x => x.DataInicio).ToList();
        var correspondencias = listaOrdenada.Any(x => x.Status == "Em aberto").Tolist();
        correspondencias = correspondencias.Sort();
        
        if (correspondencias == null)
        {
            Console.WriteLine("Não há casos abertos.");
        }
        else
        {
            Console.WriteLine("Lista de casos em aberto: ");
            int counter = 1;
            foreach (var x in correspondencias)
            {
                Console.WriteLine(counter + ". " + x);
                counter += 1;
            }
        }
    }
    public void advogadosCasosDecrescente(Advogado advogado)
    {

        List<Advogado> listaOrdenada = advogado.Lista.OrderByDescending(x => x.CasosConcluidos).ToList();
        var correspondencias = listaOrdenada.Any(x => x.Status == "Concluído").Tolist();
        
        if (correspondencias == null)
        {
            Console.WriteLine("Não há advogados que concluiram casos.");
        }
        else
        {
            Console.WriteLine("Lista de advogados e a quantidade de casos concluidos por eles: ");
            int counter = 1;
            foreach (var x in correspondencias)
            {
                Console.WriteLine(counter + ". " + x.Nome);
                Console.WriteLine(x.CasosConcluidos);
                Console.WriteLine();
                counter += 1;
            }
        }
    }
}
