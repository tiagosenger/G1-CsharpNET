using System;
using System.Collections.Generic;
using System.Globalization;
using Exceptions;
using Validations;
using Advogado = LawSystem.Entities.Pessoa.Advogado;
using Cliente = LawSystem.Entities.Pessoa.Cliente;
using Documento = LawSystem.Entities.Escritorio.Documento;
using CasoJuridico = LawSystem.Entities.Escritorio.CasoJuridico;
using Payments;
namespace LawSystem.Entities
{
    public class Operations
    {
          public void criarAdvogado(List<Advogado> advogados){
            Console.WriteLine("Nome do advogado: ");
            var nome = Console.ReadLine()!;
            if(string.IsNullOrWhiteSpace(nome)){
                throw new ArgumentException("O nome não pode ser nulo ou espaço em branco!");
            }
            Console.WriteLine("Sobrenome do advogado: ");
            var sobrenome = Console.ReadLine()!;
            if(string.IsNullOrWhiteSpace(sobrenome)){
                throw new ArgumentException("O sobrenome não pode ser nulo ou espaço em branco!");
            }
            Console.WriteLine("Data de nascimento do advogado: ");
            var dataString = Console.ReadLine()!;
            DateTime data = DateTime.ParseExact(dataString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine("CPF do advogado:");
            var cpf = Console.ReadLine()!;
            if(!Validator.validacaoCpfAdvogado(advogados, cpf)){
                throw new cpfInvalidoException("Cpf inválido!");
            }
            Console.WriteLine("CNA do advogado: ");
            var cna = Console.ReadLine()!;
            if(!Validator.validacaoCna(advogados, cna)){
                throw new cnaInvalidoException("Cna inválido");
            }

            var advogado = new Advogado(nome, sobrenome, data, cpf, cna);
            advogados.Add(advogado);
            Console.WriteLine("Advogado criado com sucesso!");
        }

        public void criarCliente(List<Cliente> clientes){
            Console.WriteLine("Nome do cliente: ");
            var nome = Console.ReadLine()!;
            if(string.IsNullOrWhiteSpace(nome)){
                throw new ArgumentException("O nome não pode ser nulo ou espaço em branco!");
            }
            Console.WriteLine("Sobrenome do cliente: ");
            var sobrenome = Console.ReadLine()!;
            if(string.IsNullOrWhiteSpace(sobrenome)){
                throw new ArgumentException("O sobrenome não pode ser nulo ou espaço em branco!");
            }
            Console.WriteLine("Data de nascimento do cliente: ");
            var dataString = Console.ReadLine()!;
            DateTime data = DateTime.ParseExact(dataString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine("CPF do cliente:");
            var cpf = Console.ReadLine()!;
            if(!Validator.validacaoCpfCliente(clientes, cpf)){
                throw new cpfInvalidoException("Cpf inválido!");
            }
            Console.WriteLine("Profissão do cliente: ");
            var profissao = Console.ReadLine()!;
            Console.WriteLine("Estado civil do cliente: ");
            var estadoCivil = Console.ReadLine()!;

            var cliente = new Cliente(nome, sobrenome, data, cpf, estadoCivil, profissao);
            clientes.Add(cliente);
            Console.WriteLine("Cliente criado com sucesso!");
        }

        public void IniciarCaso(List<Advogado> advogados, List<Cliente> clientes, List<CasoJuridico> casos)
        {
            var dataAbertura = DateTime.Now;
            Console.WriteLine("Probabilidade de sucesso do caso: ");
            float probabilidadeSucesso = float.Parse(Console.ReadLine()!);
            if(float.IsNaN(probabilidadeSucesso)){
                throw new ArgumentException("Digite um valor de ponto flutuante para a probabilidade de sucesso!");
            }
            List<(DateTime, int, string, string)> listaDocumentos = new();
            Console.WriteLine("Documentos do caso:");
            string op;
            do{
                Console.WriteLine("Data e hora de modificacao:");
                var dataHora = Console.ReadLine()!;
                DateTime dataModificacao = DateTime.ParseExact(dataHora, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                Console.WriteLine("Código do documento: ");
                var codigo = Convert.ToInt32(Console.ReadLine()!);
                Console.WriteLine("Tipo do documento: ");
                var tipo = Console.ReadLine()!;
                Console.WriteLine("Descrição do documento: ");
                var descricao = Console.ReadLine()!;

                var documento = (dataModificacao, codigo, tipo, descricao);
                listaDocumentos.Add(documento);
                Console.WriteLine("Deseja adicionar mais um documento? Digite 's' para sim");
                op = Console.ReadLine()!;
            } while(op == "s");

            Console.WriteLine("Custos do caso: ");
            List<(float, string)> custos = new();
            do{
                Console.WriteLine("Custo: ");
                float custo = float.Parse(Console.ReadLine()!);
                Console.WriteLine("Descricao: ");
                string descricao = Console.ReadLine()!;

                custos.Add((custo, descricao));
                Console.WriteLine("Deseja adicionar mais um custo? Digite 's' para sim");
                op = Console.ReadLine()!;
            } while(op == "s");
            Console.WriteLine("Associando um advogado:");
            List<Advogado> advogadosCaso = new();
            do{
                Console.WriteLine("Digite o CNA do advogado para associar ao caso:");
                string cna = Console.ReadLine()!;
                var advogado = advogados.SingleOrDefault(a => a.CNA == cna);
                if(advogado != default){
                    advogadosCaso.Add(advogado);
                    Console.WriteLine("Advogado adicionado ao caso. Deseja adicionar outro?");
                    op = Console.ReadLine()!;
                } else {
                    Console.WriteLine("Nao existe um advogado com esse CNA! Tente novamente");
                    op = "s";
                }
            } while(op == "s");

            Console.WriteLine("Cliente do caso: ");

            Cliente cliente = null;
            do {
                Console.WriteLine("Digite o cpf do cliente: ");
                string cpf = Console.ReadLine()!;
                cliente = clientes.SingleOrDefault(c => c.CPF == cpf);
                if(cliente == default){
                    Console.WriteLine("Nao existe um cliente com esse cpf! Tente novamente");
                }
            } while(cliente == default);

            var caso = new CasoJuridico(dataAbertura, probabilidadeSucesso, listaDocumentos, custos, advogadosCaso, cliente, "Em aberto");

            casos.Add(caso);
            Console.WriteLine("Caso iniciado com sucesso!");
            // if (caso.Status == "Em aberto")
            // {
            //     caso.Abertura = dataInicio;
            //     Console.WriteLine($"Caso iniciado em {dataInicio}.");
            // }
            // else
            // {
            //     Console.WriteLine("Não é possível iniciar um caso que não está em aberto.");
            // }
        }

       public void AtualizarCasoJuridico(List<CasoJuridico> casos, List<Advogado> advogados){
            Console.WriteLine("Digite o id do caso jurídico que deseja atualizar:");
            var id = Convert.ToInt32(Console.ReadLine()!);
            
            var caso = casos.SingleOrDefault(c => c.Id == id);
            if(casos == default) throw new Exception("Não existe um caso com esse id!");

            if(caso.Status == "Concluído") {
                Console.WriteLine("Esse caso já foi concluído, não pode ser atualizado");
                return;
            }
            int op;
            do {
                Console.WriteLine("1 - Adicionar documento");
                Console.WriteLine("2 - Remover documento");
                Console.WriteLine("3 - Adicionar advogado");
                Console.WriteLine("4 - Remover advogado");
                Console.WriteLine("5 - Arquivar caso");
                Console.WriteLine("6 - Concluir caso");
                Console.WriteLine("0 - Voltar ao menu anterior");

                op = Convert.ToInt32(Console.ReadLine()!);

                switch(op){
                    case 1:
                        Console.WriteLine("Data e hora de modificacao:");
                        var dataHora = Console.ReadLine()!;
                        DateTime dataModificacao = DateTime.ParseExact(dataHora, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                        Console.WriteLine("Código do documento: ");
                        var codigo = Convert.ToInt32(Console.ReadLine()!);
                        Console.WriteLine("Tipo do documento: ");
                        var tipo = Console.ReadLine()!;
                        Console.WriteLine("Descrição do documento: ");
                        var descricao = Console.ReadLine()!;

                        var documento = new Documento(dataModificacao, codigo, tipo, descricao);
                        caso.AdicionarDocumento(documento);
                        Console.WriteLine("Documento adicionado ao caso!");
                        break;
                    
                    case 2:
                        Console.WriteLine("Digite o codigo do documento: ");
                        var codigoDoc = Convert.ToInt32(Console.ReadLine()!);

                        caso.DeletarDocumento(codigoDoc);
                        Console.Read();
                        break;
                    case 3:
                        Console.WriteLine("Digite o CNA do advogado:");
                        var cna = Console.ReadLine()!;

                        var advogado = advogados.SingleOrDefault(a => a.CNA == cna);
                        if(advogado != default){
                            if(advogado.Casos.Any(c => c.Id == caso.Id)){
                                Console.WriteLine("Esse advogado já está associado a esse caso!");
                                break;
                            } else {
                                caso.Advogados.Add(advogado);
                                advogado.Casos.Add(caso);
                                Console.Read();
                            }
                            
                        } else {
                            Console.WriteLine("Nao existe um advogado com esse CNA!");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Digite o CNA do advogado:");
                        cna = Console.ReadLine()!;

                        advogado = caso.Advogados.SingleOrDefault(a => a.CNA == cna);
                        if(advogado != default){
                            caso.Advogados.Remove(advogado);
                            advogado.Casos.Remove(caso);
                            Console.Read();
                        } else {
                            Console.WriteLine("Nao existe um advogado com esse CNA associado a este caso!");
                        }
                        break;
                    case 5:
                        if(caso.Status != "Arquivado" && caso.Status != "Concluido"){
                            caso.Status = "Arquivado";
                            Console.WriteLine("O caso foi arquivado!");
                        } else if(caso.Status == "Arquivado"){
                            Console.WriteLine("O caso já está arquivado");
                        } else {
                            Console.WriteLine("Este caso já foi concluído!");
                        }
                        Console.Read();
                        break;
                    case 6:
                        Console.WriteLine("Digite a data da conclusão:");
                        dataHora = Console.ReadLine()!;
                        DateTime dataEncerramento = DateTime.ParseExact(dataHora, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                        
                        if(dataEncerramento < caso.Abertura) {
                            Console.WriteLine("A data de conclusão não pode ser anterior à data de abertura do caso!");
                            break;
                        }
                        caso.Status = "Concluído";
                        Console.WriteLine("Caso foi concluído!");
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        Console.Read();
                        break;

                }
            } while(op != 0);
       }

        public void ExcluirCaso(List<CasoJuridico> casos)
        {
            Console.WriteLine("Digite o Id do caso:");
            var id = Convert.ToInt32(Console.ReadLine()!);
            var caso = casos.SingleOrDefault(c => c.Id == id);

            if(caso != default){
                casos.Remove(caso);
                caso.Advogados.ForEach(a => a.Casos.Remove(caso));
                Console.WriteLine("Caso removido com sucesso!");
            } else Console.WriteLine("Nao existe um caso jurídico com esse id!");
        }

        public void AdicionarPlano(){
            PlanoConsultoria novoPlano = new PlanoConsultoria();
            
            Console.WriteLine("Qual o título do plano que deseja adicionar?");
            string titulo = Console.ReadLine()!;
            novoPlano.Titulo = titulo;
            
            Console.WriteLine("Qual o valor do plano?");
            double valor = double.Parse(Console.ReadLine()!);
            novoPlano.ValorPorMes = valor;
            
            Console.WriteLine("Quantos benefícios são?");
            int qtd = int.Parse(Console.ReadLine()!);
            for(int i = 0; i < qtd;){
                Console.WriteLine($"Digite o {i + 1}º benefício");
                string beneficio = Console.ReadLine()!;
                novoPlano.Beneficios.Add(beneficio);
            }

            ListAndReports.Relatorios.ListaDePlanos.Add(novoPlano);
        }

        public void RealizarPagamento(List<Cliente> clientes){
            Console.WriteLine("Digite o cpf do cliente para realizar o pagamento:");
            var cpf = Console.ReadLine()!;

            var cliente = clientes.SingleOrDefault(c => c.CPF == cpf);

            if(cliente != default){
                Console.WriteLine("Qual o tipo de pagamento?");
                Console.WriteLine("\n1. Cartão de crédito\n2. Pix\n3. Dinheiro");
                Console.Write("Digite uma opção:");
                var opcao = Convert.ToInt32(Console.ReadLine()!);

                Console.WriteLine("Descricao do pagamento: ");
                var descricao = Console.ReadLine()!;
                Console.WriteLine("Valor do pagamento:");
                var valor = float.Parse(Console.ReadLine()!);

                switch(opcao) {
                    case 1:
                        var pagamentoC = new Cartao(descricao, valor);
                        cliente.Pagamentos.Add(pagamentoC);
                        pagamentoC.RealizarPagamento();
                        break;
                    case 2:
                        var pagamentoP = new Pix(descricao, valor);
                        cliente.Pagamentos.Add(pagamentoP);
                        pagamentoP.RealizarPagamento();
                        break;
                    case 3:
                        var pagamentoD = new Dinheiro(descricao, valor);
                        cliente.Pagamentos.Add(pagamentoD);
                        pagamentoD.RealizarPagamento();
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;

                }
            } else {
                Console.WriteLine("Cliente não encontrado!");
            }

            Console.Read();
        }
    }
}