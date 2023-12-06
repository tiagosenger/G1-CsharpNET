#region 

using LawSystem.Entities;
class Program{
    static void Main(){
        Escritorio escritorio = new Escritorio(); 
        Operations operacoes = new Operations();
        ListAndReports.Listas _listas = new ListAndReports.Listas(); 
        ListAndReports.Relatorios _relatorios = new ListAndReports.Relatorios(); 
 

    int opcao;

            do
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Adicionar Advogado");
                Console.WriteLine("2. Adicionar Cliente");
                Console.WriteLine("3. Adicionar Caso Jurídico");
                Console.WriteLine("4. Adicionar Documento");
                Console.WriteLine("5. Exibir Informações de um Documento");  
                Console.WriteLine("6. Excluir Documento");                                       
                Console.WriteLine("7. Gerar Listas");
                Console.WriteLine("8. Gerar Relatórios");
                Console.WriteLine("0. Sair");

                Console.Write("Escolha uma opção: ");
                opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        operacoes.AdicionarAdvogado();
                        break;
                    case 2:
                        operacoes.AdicionarCliente();
                        break;
                    case 3:
                        operacoes.IniciarCaso();
                        break;
                    case 4:
                        escritorio.AdicionarDocumento();
                        break;
                    case 5:
                        escritorio.ExibirInformacoesDocumento();
                        break;                        
                    case 6:
                        escritorio.DeletarDocumento();
                        break;
                    case 7:
                        int opcaoListas;
                        do
                        {
                            Console.WriteLine("Menu de Listas:");
                            Console.WriteLine("1. Lista de Advogados cadastrados");
                            Console.WriteLine("2. Lista de Clientes cadastrados");
                            Console.WriteLine("3. Listar Documentos Cadastrados");
                            Console.WriteLine("4. Listar Casos Jurídicos e respectivos status");
                            Console.WriteLine("0. Voltar ao Menu Principal");

                            Console.Write("Escolha uma opção: ");
                            opcaoListas = Convert.ToInt32(Console.ReadLine());

                            switch (opcaoListas)
                            {
                                case 1:
                                    ListAndReports.Listas.ListarAdvogados(advogados); 
                                    break;
                                case 2:
                                    ListAndReports.Listas.ListarClientes(clientes);                                 
                                    break;
                                case 3:
                                    ListAndReports.Listas.ListarDocumentos(documentos);                                 
                                    break;
                                case 4:
                                    ListAndReports.Listas.ListarCasosJuridicos(caso);                                 
                                    break;
                            }
                        } while (opcaoListas != 0);
                        break;
                    case 8:
                        int opcaoRelatorios;
                        do
                        {
                            Console.WriteLine("Menu de Relatórios:");
                            Console.WriteLine("1. Gerar Relatório de Advogados com idade entre dois valores");
                            Console.WriteLine("2. Gerar Clientes com idade entre dois valores");
                            Console.WriteLine("3. Gerar Relatório de Clientes com estado civil informado pelo usuário");
                            Console.WriteLine("4. Gerar Relatório de Clientes em ordem alfabética");
                            Console.WriteLine("5. Gerar Relatório de Clientes cuja profissão contenha texto informado pelo usuário");
                            Console.WriteLine("6. Gerar Relatório de Advogados e Clientes aniversariantes do mês informado");
                            Console.WriteLine("7. Gerar Relatório de Casos com o status “Em aberto”, em ordem crescente pela data de início");
                            Console.WriteLine("8. Gerar Relatório de Advogados em ordem decrescente pela quantidade de casos com status 'Concluído'");
                            Console.WriteLine("9. Gerar Relatório de Casos que possuam custo com uma determinada palavra na descrição.");
                            Console.WriteLine("10. Gerar Relatório de . Top 10 tipos de documentos mais inseridos nos casos.");
                            Console.WriteLine("0. Voltar ao Menu Principal");

                            Console.Write("Escolha uma opção: ");
                            opcaoRelatorios = Convert.ToInt32(Console.ReadLine());

                            switch (opcaoRelatorios)
                            {
                                case 1:
                                    break;
                                case 2:
                                    break;
                                case 3:
                                    break;
                                case 4:
                                    break;
                                case 5:
                                    break;
                                case 6:
                                    break;
                                case 7:
                                    break;
                                case 8:
                                    break;
                                case 9:
                                    break;
                                case 10:
                                    break;
                            }

                        } while (opcaoRelatorios != 0);
                        break;
                }

            } while (opcao != 0);
        }
    }
#endregion