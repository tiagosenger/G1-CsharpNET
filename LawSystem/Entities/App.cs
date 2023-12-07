#region 

using LawSystem.Entities;
    public class App{
        private Escritorio escritorio;
        private Operations operacoes;

        public App()
        {
            escritorio = new Escritorio();
            operacoes = new Operations();
        }

    public void Run(){
        
    int opcao;

            do
            {
                Console.Clear();
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Adicionar Advogado");
                Console.WriteLine("2. Adicionar Cliente");
                Console.WriteLine("3. Adicionar Caso Jurídico");
                Console.WriteLine("4. Atualizar Caso jurídico");
                Console.WriteLine("5. Remover caso jurídico");
                Console.WriteLine("6. Gerar Listas");
                Console.WriteLine("7. Gerar Relatórios");
                Console.WriteLine("8. Efetuar Pagamento");
                Console.WriteLine("0. Sair");

                Console.Write("Escolha uma opção: ");
                var entrada = Console.ReadLine();
                if(string.IsNullOrWhiteSpace(entrada)){
                    Console.WriteLine("Digite uma opção!");
                    opcao = 1;
                    Console.Read();
                }else {
                    opcao = Convert.ToInt32(entrada);

                    switch (opcao)
                    {
                        case 1:
                            try{
                                operacoes.criarAdvogado(ListAndReports.Relatorios.ListaDeAdvogados);
                                Console.Read();
                            } catch(Exception e) {
                                Console.WriteLine(e.Message);
                                Console.WriteLine("Ocorreu um erro, tente novamente! Tecle enter para continuar...");
                                Console.Read();
                            }
                            
                            break;
                        case 2:
                            try{
                                operacoes.criarCliente(ListAndReports.Relatorios.ListaDeClientes);
                                Console.Read();
                            } catch(Exception e) {
                                Console.WriteLine(e.Message);
                                Console.WriteLine("Ocorreu um erro, tente novamente! Tecle enter para continuar...");
                                Console.Read();
                            }
                            
                            break;
                        case 3:
                            if(ListAndReports.Relatorios.ListaDeAdvogados.Count == 0){
                                Console.WriteLine("Não há advogados cadastrados, portanto não é possível iniciar um caso!");
                                Console.Read();
                            }
                            else if(ListAndReports.Relatorios.ListaDeClientes.Count == 0){
                                Console.WriteLine("Não há clientes cadastrados, portanto não é possível iniciar um caso!");
                                Console.Read();
                            } else {
                                try{
                                    operacoes.IniciarCaso(ListAndReports.Relatorios.ListaDeAdvogados,
                                    ListAndReports.Relatorios.ListaDeClientes,
                                    ListAndReports.Relatorios.ListaDeCasos);
                                } catch (Exception e){
                                    Console.WriteLine(e.Message);
                                }
                                
                                Console.Read();
                            }
                            
                            break;
                        case 4:
                            if(ListAndReports.Relatorios.ListaDeCasos.Count == 0){
                                Console.WriteLine("Ainda não existe nenhum caso jurídico cadastrado!");
                            } else {
                                try {
                                    operacoes.AtualizarCasoJuridico(ListAndReports.Relatorios.ListaDeCasos, ListAndReports.Relatorios.ListaDeAdvogados);
                                } catch(Exception e){
                                    Console.WriteLine(e.Message);
                                }
                            }
                            break;
                        case 5:
                            if(ListAndReports.Relatorios.ListaDeCasos.Count == 0){
                                Console.WriteLine("Ainda não existe nenhum caso jurídico cadastrado!");
                            } else {
                                operacoes.ExcluirCaso(ListAndReports.Relatorios.ListaDeCasos);
                            }
                            Console.Read();
                            break;                      
                        case 6:
                            int opcaoListas;
                            do
                            {
                                Console.Clear();
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
                                        ListAndReports.Relatorios.ListarAdvogados(); 
                                        break;
                                    case 2:
                                        ListAndReports.Relatorios.ListarClientes();                                 
                                        break;
                                    case 3:
                                        ListAndReports.Relatorios.ListarDocumentos();                                 
                                        break;
                                    case 4:
                                        ListAndReports.Relatorios.ListarCasosJuridicos();                                 
                                        break;
                                }
                                Console.Read();
                            } while (opcaoListas != 0);
                            break;
                        case 7:
                            int opcaoRelatorios;
                            do
                            {
                                Console.Clear();
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
                                        ListAndReports.Relatorios.advogadosFaixaIdade();
                                        Console.Read();
                                        break;
                                    case 2:
                                        ListAndReports.Relatorios.clientesFaixaDeIdade();
                                        Console.Read();
                                        break;
                                    case 3:
                                        ListAndReports.Relatorios.clientesEstadocivilInformado();
                                        Console.Read();
                                        break;
                                    case 4:
                                        ListAndReports.Relatorios.clientesOrdemAlfabetica();
                                        Console.Read();
                                        break;
                                    case 5:
                                        ListAndReports.Relatorios.clientesProfissaoSelecionada();
                                        Console.Read();
                                        break;
                                    case 6:
                                        ListAndReports.Relatorios.MesAniversario();
                                        Console.Read();
                                        break;
                                    case 7:
                                        ListAndReports.Relatorios.casosAbertos();
                                        Console.Read();
                                        break;
                                    case 8:
                                        ListAndReports.Relatorios.advogadosCasosDecrescente();
                                        Console.Read();
                                        break;
                                    case 9:
                                        try {
                                            ListAndReports.Relatorios.casosComCustoContendoPalavra();
                                        } catch (Exception e) {
                                            Console.WriteLine(e.Message);
                                        }
                                        Console.Read();
                                        break;
                                    case 10:
                                        ListAndReports.Relatorios.tiposMaisCadastrados();
                                        Console.Read();
                                        break;
                                    case 0:
                                        break;
                                    default:
                                        Console.WriteLine("Opção inválida!");
                                        Console.Read();
                                        break;
                                }

                            } while (opcaoRelatorios != 0);
                            break;
                        case 8:
                        operacoes.RealizarPagamento(ListAndReports.Relatorios.ListaDeClientes);
                        break;
                        
                        case 0:
                            break;
                        default:
                            Console.WriteLine("opção inválida!");
                            break;
                    }

                }
                
            } while (opcao != 0);
        }
    }
#endregion