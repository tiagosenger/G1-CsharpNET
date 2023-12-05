#region Métodos relacionados à geração de listas e relatórios. 

namespace LawSystem.Entities{
    class ListAndReports
    {
        private List<Pessoa.Advogado> ListaDeAdvogados = new List<Pessoa.Advogado>();
        private List<Pessoa.Cliente> ListaDeClientes = new List<Pessoa.Cliente>();
        private List<CasoJuridico> ListaDeCasos = new List<CasoJuridico>();

        public void adicionarAdvogadoParaLista(Pessoa.Advogado advogado){
            ListaDeAdvogados.Add(advogado);
        }
        public void adicionarClientesParaLista(Pessoa.Cliente cliente){
            ListaDeClientes.Add(cliente);
        }
        public void adicionarCasoParaLista(CasoJuridico caso){
            ListaDeCasos.Add(caso);
        }
        public void advogadosFaixaIdade(List<Pessoa.Advogado> advogado)
        {
            Console.WriteLine("Informe a idade míninma: ");
            int min = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Informe a idade máxima: ");
            int max = Convert.ToInt16(Console.ReadLine());

            var correspondencias = advogado.Where(x => x.DataNascimento.Year >= DateTime.Now.Year - min && x.DataNascimento.Year <= DateTime.Now.Year - max).ToList();
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
        public void clientesFaixaDeIdade(List<Pessoa.Cliente> cliente)
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
        public void clientesEstadocivilInformado(List<Pessoa.Cliente> cliente)
        {
            Console.WriteLine("Informe a estado civil a ser critério de filtro: ");
            string estadocivil = Console.ReadLine()!.ToLower();
            var correspondencias = cliente.Where(x => x.EstadoCivil == estadocivil);
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
                    Console.WriteLine(counter + ". " + x.Nome);
                    counter += 1;
                }
            }
        }
        public void clientesOrdemAlfabetica(List<Pessoa.Cliente> cliente)
        {

            var listaOrdenada = cliente.OrderBy(o=>o.Nome).ToList();

            Console.WriteLine("Lista de clientes em ordem alfabética: ");
            int counter = 1;
            foreach (var x in listaOrdenada)
            {
                Console.WriteLine(counter + ". " + x.Nome);
                counter += 1;
            }
        }
        public void clientesProfissaoSelecionada(List<Pessoa.Cliente> cliente)
        {
            Console.WriteLine("Informe a profissão a ser critério de filtro: ");
            string profissao = Console.ReadLine()!.ToLower();
            var correspondencias = cliente.Where(x => x.Profissao.ToLower() == profissao);
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
                    Console.WriteLine(counter + ". " + x.Nome);
                    counter += 1;
                }
            }
        }
        public void MesAniversario(List<Pessoa.Cliente> cliente, List<Pessoa.Advogado> advogado)
        {
            Console.WriteLine("Informe o mês a filtrar(em numero): ");
            int mes = Convert.ToInt16(Console.ReadLine());

            var correspondenciasAdvogado = advogado.Where(x => x.DataNascimento.Month == mes);
            var correspondenciasCliente = cliente.Where(x => x.DataNascimento.Month == mes);
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
                    Console.WriteLine(counter + ". " + x.Nome);
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
                    Console.WriteLine(counter + ". " + x.Nome);
                    counter += 1;
                }
            }
        }
        public void casosAbertos(List<CasoJuridico> casos)
        {

            var listaOrdenada = casos.OrderBy(x => x.Abertura).ToList();
            var correspondencias = listaOrdenada.Where(x => x.Status == "Em aberto");

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
                    Console.WriteLine(counter + ". " + x.Documentos[0].Codigo);
                    counter += 1;
                }
            }
        }
        public void advogadosCasosDecrescente(List<Pessoa.Advogado> advogado)
        {

            advogado.OrderByDescending(x => x.).ToList();
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
}
#endregion