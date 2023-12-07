#region Métodos relacionados à geração de listas e relatórios. 
using Advogado = LawSystem.Entities.Pessoa.Advogado;
using Cliente = LawSystem.Entities.Pessoa.Cliente;
using Documento = LawSystem.Entities.Escritorio.Documento;
using CasoJuridico = LawSystem.Entities.Escritorio.CasoJuridico;
using System.Diagnostics.Metrics;

namespace LawSystem.Entities{
public class ListAndReports{
    
        public static class Relatorios{
        public static List<Advogado> ListaDeAdvogados = new List<Advogado>();
        public static List<Cliente> ListaDeClientes = new List<Cliente>();
        public static List<CasoJuridico> ListaDeCasos = new List<CasoJuridico>();

        public static List<PlanoConsultoria> ListaDePlanos = new List<PlanoConsultoria>();
        
        public static void advogadosFaixaIdade()
        {
            Console.WriteLine("Informe a idade míninma: ");
            int min = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Informe a idade máxima: ");
            int max = Convert.ToInt16(Console.ReadLine());

            var correspondencias = ListaDeAdvogados.Where(x => x.DataNascimento.Year >= DateTime.Now.Year - min && x.DataNascimento.Year <= DateTime.Now.Year - max).ToList();
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
                    Console.WriteLine(counter + ". " + x.Nome);
                    counter += 1;
                }
            }

        }
        public static void clientesFaixaDeIdade()
        {
            Console.WriteLine("Informe a idade míninma: ");
            int min = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Informe a idade máxima: ");
            int max = Convert.ToInt16(Console.ReadLine());

            var correspondencias = ListaDeClientes.Where(x => x.DataNascimento.Year >= DateTime.Now.Year - min && x.DataNascimento.Year <= DateTime.Now.Year - max).ToList();
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
                    Console.WriteLine(counter + ". " + x.Nome);
                    counter += 1;
                }
            }
        }
        public static void clientesEstadocivilInformado()
        {
            Console.WriteLine("Informe a estado civil a ser critério de filtro: ");
            string estadocivil = Console.ReadLine()!.ToLower();
            var correspondencias = ListaDeClientes.Where(x => x.EstadoCivil == estadocivil);
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
        public static void clientesOrdemAlfabetica()
        {

            var listaOrdenada = ListaDeClientes.OrderBy(x => x.Nome.ToLower()).ToList();

            Console.WriteLine("Lista de clientes em ordem alfabética: ");
            int counter = 1;
            foreach (var x in listaOrdenada)
            {
                Console.WriteLine(counter + ". " + x.Nome);
                counter += 1;
            }
        }
        public static void clientesProfissaoSelecionada()
        {
            Console.WriteLine("Informe a profissão a ser critério de filtro: ");
            string profissao = Console.ReadLine()!.ToLower();
            var correspondencias = ListaDeClientes.Where(x => x.Profissao.ToLower() == profissao);
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
        public static void MesAniversario()
        {
            Console.WriteLine("Informe o mês a filtrar(em numero): ");
            int mes = Convert.ToInt16(Console.ReadLine());

            var correspondenciasAdvogado = ListaDeAdvogados.Where(x => x.DataNascimento.Month == mes);
            var correspondenciasCliente = ListaDeClientes.Where(x => x.DataNascimento.Month == mes);
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
        public static void casosAbertos()
        {

            var listaOrdenada = ListaDeCasos.OrderBy(x => x.Abertura).ToList();
            var correspondencias = listaOrdenada.Where(x => x.Status!.ToLower() == "em aberto");

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
                    Console.WriteLine(counter + ". Abertura: " +x.Abertura+" Provabilidade de sucesso: "+x.ProbabilidadeSucesso+" ID: "+x.Id);
                    counter += 1;
                }
            }
        }
        public static void advogadosCasosDecrescente()
        {
            
            var correspondencias = ListaDeAdvogados.Where(x => x.Casos.Any(x=>x.Status == "Concluído"));
            var Listaordenada = correspondencias.OrderBy(x => x.Casos.Count);

            if (Listaordenada == null)
            {
                Console.WriteLine("Não há advogados que concluiram casos.");
            }
            else
            {
                Console.WriteLine("Lista de advogados e a quantidade de casos concluidos por eles: ");
                int counter = 1;
                foreach (var x in Listaordenada)
                {
                    Console.WriteLine(counter + ". " +x.Nome+": "+x.Casos.Count);
                    Console.WriteLine();
                    counter += 1;
                }
            }
        }

        public static void casosComCustoContendoPalavra(){
            Console.WriteLine("Digite uma palavra para pesquisar:");
            var palavra = Console.ReadLine()!;

            if(string.IsNullOrEmpty(palavra)){
                throw new Exception("Digite uma descrição! A busca não pode ser vazia!");
            }

            Console.WriteLine("Casos com custos relacionados à pesquisa:");
            var casos = ListaDeCasos.Where(c => c.Custos!.Any(cs => cs.Descricao.Contains(palavra))).ToList();

            if(casos.Count == 0){
                Console.WriteLine("Não foram encontrados casos contendo essa descrição nos custos");
                return;
            }

            int counter = 1;
            foreach(var caso in casos){
                Console.WriteLine(counter + ". Abertura: " +caso.Abertura+" Provabilidade de sucesso: "+caso.ProbabilidadeSucesso+" ID: "+caso.Id);
            }
        }
        public static void tiposMaisCadastrados()
        {
            
            List<Dictionary<string,int>> ListaTipoComQuantidade = new List<Dictionary<string,int>>();
            foreach (var caso in ListaDeCasos)
            {
                foreach (var documento in caso.Documentos)
                {
                    if (ListaTipoComQuantidade != null)
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
                            else
                            {
                            // Se a chave não foi encontrada em nenhum dicionário, adiciona um novo dicionário com a chave e valor 0
                            Dictionary<string,int> TipoComQuantidade = new Dictionary<string,int>
                            {
                                { documento.Tipo!, 1 }
                            };
                            ListaTipoComQuantidade!.Add(TipoComQuantidade);
                            }

                        }
                    }
                    
                }
            }
            if (ListaTipoComQuantidade != null){
                for (var i = 0; i < 10; i++)
                {
                    Console.Write(ListaTipoComQuantidade![i].Keys);
                    Console.Write(" ");
                    Console.WriteLine(ListaTipoComQuantidade[i].Values);
                }    
            }
            else{
                Console.WriteLine("Não há registro de documentos.");
            }
            
        }
        public static void ListarAdvogados()
            {
                Console.WriteLine("Lista de Advogados Cadastrados:");
                foreach (var advogado in  ListaDeAdvogados)
                {
                    Console.WriteLine($"Nome: {advogado.Nome} {advogado.Sobrenome}");
                    Console.WriteLine($"CPF: {advogado.CPF}");
                    Console.WriteLine($"CNA: {advogado.CNA}");
                    Console.WriteLine();
                }
            }

            public static void ListarClientes()
            {
                Console.WriteLine("Lista de Clientes Cadastrados:");
                foreach (var cliente in ListaDeClientes)
                {
                    Console.WriteLine($"Nome: {cliente.Nome} {cliente.Sobrenome}");
                    Console.WriteLine($"CPF: {cliente.CPF}");
                    Console.WriteLine($"Estado Civil: {cliente.EstadoCivil}");
                    Console.WriteLine($"Profissão: {cliente.Profissao}");
                    Console.WriteLine();
                }
            }

            public static void ListarDocumentos()
            {
                Console.WriteLine("Lista de Documentos Cadastrados:");
                
                var documentos = ListaDeCasos.SelectMany(documentos => documentos.Documentos);
                int counter = 1;
                foreach (var documento in documentos)
                {
                    Console.WriteLine($"{counter} . Tipo: {documento.Tipo} Codigo: {documento.Codigo} \n Descrição: {documento.Descricao}");
                }
                /*
                List<Documento> documentos = new List<Documento>();
                foreach (var caso in ListaDeCasos)
                {
                    foreach (var documento in caso.Documentos)
                    {
                        documentos.Add(documento);
                    }
                }
                */
            }

            public static void ListarCasosJuridicos()
            {
                Console.WriteLine("Lista de Casos Jurídicos Cadastrados:");
                foreach (var casoJuridico in ListaDeCasos)
                {
                    Console.WriteLine($"Abertura: {casoJuridico.Abertura:dd/MM/yyyy}");
                    Console.WriteLine($"Probabilidade de Sucesso: {casoJuridico.ProbabilidadeSucesso}%");
                    Console.WriteLine($"Status: {casoJuridico.Status ?? "N/A"}");
                    Console.WriteLine();
                }
            }
            public static void ListarPlanos(){
                foreach (var plano in ListaDePlanos)
                {
                    Console.WriteLine("Titulo: "+plano.Titulo);
                    Console.WriteLine("Valor por mês: "+plano.ValorPorMes);
                    Console.WriteLine("Benefícios: ");
                    int counter = 1;
                    foreach (var beneficio in plano.Beneficios)
                    {
                        Console.WriteLine(counter+". "+beneficio);
                        counter += 1;
                    }
                }
            }
            public static void ListarPagamentosDosCliente(){
                int counterC = 1;
                foreach (var cliente in ListaDeClientes)
                {
                    int counterP = 1;
                    Console.WriteLine(counterC+".");
                    Console.WriteLine(cliente.Nome);
                    Console.WriteLine("Lista de pagamentos: ");
                    foreach (var pagamento in cliente.Pagamentos)
                    {
                        Console.WriteLine("Pagamento "+counterP);
                        Console.WriteLine(pagamento);
                        counterP += 1;
                    }
                    counterC += 1;
                }
            }
        }
        
    }
       
}
#endregion