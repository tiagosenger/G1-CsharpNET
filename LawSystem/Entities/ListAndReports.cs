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
            Console.WriteLine("Lista de advogados com essa faixa de idade: ");
            int counter = 1;
            foreach (var x in correspondencias)
            {
                Console.WriteLine(counter+". "+x);
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

        var correspondencias = cliente.Where(x => x.DataNascimento >= DateTime.Now.Year - min && x <= DateTime.Now.Year - max).ToList();
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
                Console.WriteLine(counter+". "+x);
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
                Console.WriteLine(counter+". "+x);
                counter += 1;
            }
        }
    }
    public void clientesOrdemAlfabetica(Cliente cliente){
        var listaOrdenada =  new List<string>();
        listaOrdenada = cliente.Lista;
        listaOrdenada.Sort();

        Console.WriteLine("Lista de clientes em ordem alfabética: ");
        int counter = 1;
        foreach (var x in listaOrdenada)
        {
            Console.WriteLine(counter+". "+x);
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
                Console.WriteLine(counter+". "+x);
                counter += 1;
            }
        }
    }

}