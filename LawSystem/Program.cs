#region 

using LawSystem.Entities;
class Program{
    static void Main(){
        Escritorio escritorio = new Escritorio(); 
        Operations operacoes = new Operations();
        ListAndReports listAndReports = new ListAndReports(); 

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
                            Console.WriteLine("1. Listar Advogados");
                            Console.WriteLine("2. Listar Clientes");
                            Console.WriteLine("3. Listar Documentos");
                            Console.WriteLine("4. Listar Casos Jurídicos");
                            Console.WriteLine("0. Voltar ao Menu Principal");

                            Console.Write("Escolha uma opção: ");
                            opcaoListas = Convert.ToInt32(Console.ReadLine());

                            switch (opcaoListas)
                            {
                                case 1:
                                    // Listar Advogados
                                    // Implemente a lógica aqui chamando o método correspondente de ListAndReports.cs
                                    break;
                                case 2:
                                    // Listar Clientes
                                    // Implemente a lógica aqui chamando o método correspondente de ListAndReports.cs
                                    break;
                                case 3:
                                    // Listar Documentos
                                    // Implemente a lógica aqui chamando o método correspondente de ListAndReports.cs
                                    break;
                                case 4:
                                    // Listar Casos Jurídicos
                                    // Implemente a lógica aqui chamando o método correspondente de ListAndReports.cs
                                    break;
                            }
                        } while (opcaoListas != 0);
                        break;
                    case 6:
                        // Menu para gerar relatórios
                        int opcaoRelatorios;
                        do
                        {
                            Console.WriteLine("Menu de Relatórios:");
                            Console.WriteLine("1. Gerar Relatório de Advogados");
                            Console.WriteLine("2. Gerar Relatório de Clientes");
                            Console.WriteLine("3. Gerar Relatório de Documentos");
                            Console.WriteLine("4. Gerar Relatório de Casos Jurídicos");
                            Console.WriteLine("0. Voltar ao Menu Principal");

                            Console.Write("Escolha uma opção: ");
                            opcaoRelatorios = Convert.ToInt32(Console.ReadLine());

                            switch (opcaoRelatorios)
                            {
                                case 1:
                                    // Gerar Relatório de Advogados
                                    // Implemente a lógica aqui chamando o método correspondente de ListAndReports.cs
                                    break;
                                case 2:
                                    // Gerar Relatório de Clientes
                                    // Implemente a lógica aqui chamando o método correspondente de ListAndReports.cs
                                    break;
                                case 3:
                                    // Gerar Relatório de Documentos
                                    // Implemente a lógica aqui chamando o método correspondente de ListAndReports.cs
                                    break;
                                case 4:
                                    // Gerar Relatório de Casos Jurídicos
                                    // Implemente a lógica aqui chamando o método correspondente de ListAndReports.cs
                                    break;
                            }
                        } while (opcaoRelatorios != 0);
                        break;
                }
            } while (opcao != 0);
        }
    }


#endregion