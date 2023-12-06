using System;
using System.Collections.Generic;
using System.Globalization;
using Exceptions;
using Validations;
using Advogado = LawSystem.Entities.Pessoa.Advogado;
using Cliente = LawSystem.Entities.Pessoa.Cliente;
namespace LawSystem.Entities
{
    public class Operations
    {
          public static void criarAdvogado(List<Advogado> advogados){
            Console.WriteLine("Nome do advogado: ");
            var nome = Console.ReadLine()!;
            Console.WriteLine("Sobrenome do advogado: ");
            var sobrenome = Console.ReadLine()!;
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
        }

        public static void criarCliente(List<Cliente> clientes){
            Console.WriteLine("Nome do cliente: ");
            var nome = Console.ReadLine()!;
            Console.WriteLine("Sobrenome do cliente: ");
            var sobrenome = Console.ReadLine()!;
            Console.WriteLine("Data de nascimento do cliente: ");
            var dataString = Console.ReadLine()!;
            DateTime data = DateTime.ParseExact(dataString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine("CPF do cliente:");
            var cpf = Console.ReadLine()!;
            if(Validator.validacaoCpfCliente(clientes, cpf)){
                throw new cpfInvalidoException("Cpf inválido!");
            }
            Console.WriteLine("Profissão do cliente: ");
            var profissao = Console.ReadLine()!;
            Console.WriteLine("Estado civil do cliente: ");
            var estadoCivil = Console.ReadLine()!;
        }

        public static void IniciarCaso(Escritorio.CasoJuridico caso, DateTime dataInicio)
        {
            if (caso.Status == "Em aberto")
            {
                caso.Abertura = dataInicio;
                Console.WriteLine($"Caso iniciado em {dataInicio}.");
            }
            else
            {
                Console.WriteLine("Não é possível iniciar um caso que não está em aberto.");
            }
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
