using System;
using System.Collections.Generic;
using Advogado = LawSystem.Entities.Pessoa.Advogado;
using Cliente = LawSystem.Entities.Pessoa.Cliente;
namespace LawSystem.Entities
{
    public class Operations
    {
        public static void IniciarCaso(CasoJuridico caso, DateTime dataInicio)
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

       public void AtualizarCasoJuridico(CasoJuridico casoJuridico, string novoStatus){
            casoJuridico.Status = novoStatus;
            Console.WriteLine("Caso Jurídico atualizado com sucesso!");
       }

        public static void ExcluirCaso(List<CasoJuridico> casos, CasoJuridico casoJuridico)
        {
            casos.Remove(casoJuridico);
        }

        public static void AdicionarAdvogado(CasoJuridico caso, Advogado advogado)
        {
            caso.Advogados?.Add(advogado);
            Console.WriteLine($"Advogado {advogado.Nome} adicionado com sucesso!");
        }

        public static void AdicionarCliente(CasoJuridico caso, Cliente cliente)
        {
            caso.Cliente = cliente;
            Console.WriteLine($"Cliente {cliente.Nome} adicionado ao Caso Juridico com sucesso!");
        }

        public static void ExcluirAdvogado(CasoJuridico caso, Advogado advogado)
        {
            caso.Advogados?.Remove(advogado);
            Console.WriteLine("Advogado removido com sucesso!");
        }

        public static void ExcluirCliente(CasoJuridico caso){
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
