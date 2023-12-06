#region Métodos relacionados à geração de listas e relatórios. 
using Advogado = LawSystem.Entities.Pessoa.Advogado;
using Cliente = LawSystem.Entities.Pessoa.Cliente;
using Documento = LawSystem.Entities.Escritorio.Documento;
using CasoJuridico = LawSystem.Entities.Escritorio.CasoJuridico;

namespace LawSystem.Entities{
public class ListAndReports{
    
    public class Relatorios{
        private List<Advogado> ListaDeAdvogados = new List<Advogado>();
        private List<Cliente> ListaDeClientes = new List<Cliente>();
        private List<CasoJuridico> ListaDeCasos = new List<CasoJuridico>();

        public void adicionarAdvogadoParaLista(Advogado advogado){
            ListaDeAdvogados.Add(advogado);
        }
        public void adicionarClientesParaLista(Cliente cliente){
            ListaDeClientes.Add(cliente);
        }
        public void adicionarCasoParaLista(CasoJuridico caso){
            ListaDeCasos.Add(caso);
        }
        public void advogadosFaixaIdade(List<Advogado> advogado)
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
        public void clientesFaixaDeIdade(List<Cliente> cliente)
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
        public void clientesEstadocivilInformado(List<Cliente> cliente)
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
        public void clientesOrdemAlfabetica(List<Cliente> cliente)
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
        public void clientesProfissaoSelecionada(List<Cliente> cliente)
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
        public void MesAniversario(List<Cliente> cliente, List<Advogado> advogado)
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
        public void advogadosCasosDecrescente(List<Advogado> ListaAdvogados)
        {
            
            var correspondencias = ListaAdvogados.OrderByDescending(x => x.Casos.Count).ToList();
            
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
                    Console.WriteLine(counter + ". " +x.Nome+": "+x.Casos.Count);
                    Console.WriteLine();
                    counter += 1;
                }
            }
        }
        public void tiposMaisCadastrados(List<CasoJuridico> ListaDeCasos){
            
            List<Dictionary<string,int>> ListaTipoComQuantidade = new List<Dictionary<string,int>>;
            foreach (var caso in ListaDeCasos)
            {
                foreach (var documento in caso.Documentos)
                {
                    if (ListaTipoComQuantidade != null && ListaTipoComQuantidade.Count > 0)
                    {
                        // Verificando se a chave existe em qualquer dicionário da lista
                        foreach (var dicionario in ListaTipoComQuantidade)
                        {
                            if (dicionario.ContainsKey(documento.Tipo!))
                            {
                            // Aumentando o valor da chave em 1 se ela existir
                            dicionario[documento.Tipo!] += 1;
                            return;
                            }
                        }
                    }
                    // Se a chave não foi encontrada em nenhum dicionário, adiciona um novo dicionário com a chave e valor 0
                    Dictionary<string,int> TipoComQuantidade = new Dictionary<string,int>
                    {
                    { documento.Tipo!, 0 }
                    };

                    ListaTipoComQuantidade!.Add(TipoComQuantidade);
                }
    
                }
                for (var i = 0; i < 10; i++)
                {
                    Console.WriteLine(ListaTipoComQuantidade[i]);
                }
            }
            
        }
    }
    public class Listas {
            public static void ListarAdvogados(List<Advogado> advogados)
            {
                Console.WriteLine("Lista de Advogados Cadastrados:");
                foreach (var advogado in advogados)
                {
                    Console.WriteLine($"Nome: {advogado.Nome} {advogado.Sobrenome}");
                    Console.WriteLine($"CPF: {advogado.CPF}");
                    Console.WriteLine($"CNA: {advogado.CNA}");
                    Console.WriteLine();
                }
            }

            public static void ListarClientes(List<Cliente> clientes)
            {
                Console.WriteLine("Lista de Clientes Cadastrados:");
                foreach (var cliente in clientes)
                {
                    Console.WriteLine($"Nome: {cliente.Nome} {cliente.Sobrenome}");
                    Console.WriteLine($"CPF: {cliente.CPF}");
                    Console.WriteLine($"Estado Civil: {cliente.EstadoCivil}");
                    Console.WriteLine($"Profissão: {cliente.Profissao}");
                    Console.WriteLine();
                }
            }

            public static void ListarDocumentos(List<Documento> documentos)
            {
                Console.WriteLine("Lista de Documentos Cadastrados:");
                foreach (var documento in documentos)
                {
                    Console.WriteLine($"Código: {documento.Codigo}");
                    Console.WriteLine($"Tipo: {documento.Tipo ?? "N/A"}");
                    Console.WriteLine($"Descrição: {documento.Descricao ?? "N/A"}");
                    Console.WriteLine($"Data de Modificação: {documento.DataDeModificacao:dd/MM/yyyy}");
                    Console.WriteLine();
                }
            }

            public static void ListarCasosJuridicos(List<CasoJuridico> casosJuridicos)
            {
                Console.WriteLine("Lista de Casos Jurídicos Cadastrados:");
                foreach (var casoJuridico in casosJuridicos)
                {
                    Console.WriteLine($"Abertura: {casoJuridico.Abertura:dd/MM/yyyy}");
                    Console.WriteLine($"Probabilidade de Sucesso: {casoJuridico.ProbabilidadeSucesso}%");
                    Console.WriteLine($"Status: {casoJuridico.Status ?? "N/A"}");
                    Console.WriteLine();
                }
            }
        }
    }    
}
#endregion