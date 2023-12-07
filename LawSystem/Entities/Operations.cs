using System;
using System.Collections.Generic;
using System.Globalization;
using Exceptions;
using Validations;
using Advogado = LawSystem.Entities.Pessoa.Advogado;
using Cliente = LawSystem.Entities.Pessoa.Cliente;
using Documento = LawSystem.Entities.Escritorio.Documento;
using CasoJuridico = LawSystem.Entities.Escritorio.CasoJuridico;
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

       public void AtualizarCasoJuridico(Escritorio.CasoJuridico casoJuridico, string novoStatus){
            casoJuridico.Status = novoStatus;
            Console.WriteLine("Caso Jurídico atualizado com sucesso!");
       }

        public static void ExcluirCaso(List<Escritorio.CasoJuridico> casos, Escritorio.CasoJuridico casoJuridico)
        {
            casos.Remove(casoJuridico);
        }

        public static void AdicionarAdvogado(Escritorio.CasoJuridico caso, Advogado advogado)
        {
            caso.Advogados?.Add(advogado);
            Console.WriteLine($"Advogado {advogado.Nome} adicionado com sucesso!");
        }

        public static void AdicionarCliente(Escritorio.CasoJuridico caso, Cliente cliente)
        {
            caso.Cliente = cliente;
            Console.WriteLine($"Cliente {cliente.Nome} adicionado ao Caso Juridico com sucesso!");
        }

        public static void ExcluirAdvogado(Escritorio.CasoJuridico caso, Advogado advogado)
        {
            caso.Advogados?.Remove(advogado);
            Console.WriteLine("Advogado removido com sucesso!");
        }

        public static void ExcluirCliente(Escritorio.CasoJuridico caso){
            if (caso.Cliente != null)
            {
                Cliente clienteRemovido = caso.Cliente;
                caso.Cliente = null;
                Console.WriteLine($"Cliente {clienteRemovido.Nome} removido com sucesso!");
            }
            else{
                Console.WriteLine("Não há cliente associado a este caso.");
            }

        }   

    }
}
