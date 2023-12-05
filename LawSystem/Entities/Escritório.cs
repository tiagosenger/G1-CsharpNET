
namespace LawSystem.Entities
{
    public class Escritorio {
        public static void IniciarCaso(CasoJuridico caso, DateTime dataInicio){
            if (caso.Status == "Em aberto") {
                caso.DataInicio = dataInicio;
                Console.WriteLine($"Caso iniciado em {dataInicio}.");
            }
            else{
                Console.WriteLine("Não é possível iniciar um caso que não está em aberto.");
            }
        }

    public static void AtualizarCaso(List<CasoJuridico> casos, int numeroCaso){
    var caso = casos.Find(c => c.Numero == numeroCaso);

        if (caso == null){
            Console.WriteLine($"Caso com número {numeroCaso} não encontrado.");
            return;
        }

        Console.WriteLine("Escolha como deseja atualizar o status do caso");
        Console.WriteLine("1 - Concluído");
        Console.WriteLine("2 - Arquivado");

        if (int.TryParse(Console.ReadLine(), out int opcao)){
            switch (opcao){
                case 1:
                    Console.WriteLine("Digite a data de conclusão do caso (formato dd/mm/aaaa):");
                    if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dataConclusao)
                        && dataConclusao > caso.DataInicio){
                        caso.Status = "Concluído";
                        caso.Encerramento = dataConclusao;
                        Console.WriteLine($"Caso atualizado. Status: {caso.Status}, Data de Conclusão: {caso.Encerramento}");
                    }
                    else{
                        Console.WriteLine("A data de conclusão deve ser posterior à data de início ou o formato da data é inválido.");
                    }
                    break;
                case 2:
                    caso.Status = "Arquivado";
                    caso.Encerramento = DateTime.Now;
                    Console.WriteLine($"Caso atualizado e arquivado. Status: {caso.Status}, Data de Conclusão: {caso.Encerramento}");
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }
        else{
            Console.WriteLine("Opção inválida");
        }
    }

        public static void ExcluirCaso(List<CasoJuridico> casos, int numeroCaso){    
           var casoRemovido = casos.Find(c => c.Numero == numeroCaso);

            if (casoRemovido != null){
                casos.Remove(casoRemovido);
                Console.WriteLine($"Caso {numeroCaso} excluído com sucesso.");
            }
            else{
                Console.WriteLine($"Caso {numeroCaso} não encontrado.");
            }
        }

        public static void AdicionarAdvogado(Lista<CasoJuridico> casos, int numeroCaso, Advogado advogado){
            var caso = casos.Find(c => c.Numero == numeroCaso);
            if(caso != null){
                caso.AdvogadosAssociados.Add(advogado);
                advogado.CasosAssociados.Add(caso);
            }
            Console.WriteLine($"Advogado {advogado.Nome} adicionado com sucesso!");
        }

        public static void AdicionarCliente(Lista<CasoJuridico> casos, int numeroCaso, Cliente cliente){
            var caso = casos.Find(c => c.Numero == numeroCaso);
            if(caso != null){
                caso.cliente = cliente;
                cliente.CasoAssociado = caso;
                Console.WriteLine($"Cliente {cliente.Nome} adicionado ao caso {caso.ListaDocumentos[numeroCaso]} com sucesso!");
                
            } else {
                Console.WriteLine($"Caso {numeroCaso} não encontrado.");
            }
        }

        public static void ExcluirAdvogado(List<CasoJuridicos> casos,int numeroCaso, Advogado advogado){
            var caso = casos.Find(c => c.Numero == numeroCaso);
            if(caso != null){
                caso.AdvogadosAssociados.Remove(advogado);
                Console.WriteLine("Advogado removido com sucesso!");
            } else {
                Console.WriteLine($"Caso {numeroCaso} não encontrado.");
            }
            
        }

        public static void ExcluirCliente(List<CasosJuridicos> casos, int numeroCaso, Cliente cliente){
            var caso = casos.Find(c => c.Numero == numeroCaso);
            if(caso != null){
                caso.Cliente = null;
                Console.WriteLine("Cliente removido com sucesso!");
            }else {
                Console.WriteLine($"Caso {numeroCaso} não encontrado.");
            }
        }

    }
}