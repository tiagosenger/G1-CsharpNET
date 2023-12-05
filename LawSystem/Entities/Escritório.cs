
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

        public static void AtualizarCaso(CasoJuridico caso, DateTime? dataConclusao, Advogado advogados){
            if (dataConclusao.HasValue && dataConclusao < caso.DataInicio){
                Console.WriteLine("A data de conclusão deve ser posterior à data de início.");
                return;
            } else {
                caso.Encerramento = dataConclusao;
                caso.Status = "Concluído";
            }

            if (caso.Advogados.Count > 0){
                caso.AdicionarAdvogados(advogados);
            }

            Console.WriteLine($"Caso atualizado. Status: {caso.Status}, Data de Conclusão: {caso.Encerramento}");
        }

        public static void ExcluirCaso(List<CasoJuridico> casos, int numeroCaso){    
           var casoRemovido = casos.SingleOrDefault(caso => caso.ListaDocumentos.Any(doc => doc.Codigo == numeroCaso));

            if (casoRemovido != null){
                casos.Remove(casoRemovido);
                Console.WriteLine($"Caso {numeroCaso} excluído com sucesso.");
            }
            else{
                Console.WriteLine($"Caso {numeroCaso} não encontrado.");
            }
        }

        public static void AdicionarAdvogado(List<CasoJuridico> casos, Advogado advogado){
            casos.Add(advogado);
            Console.WriteLine($"Advogado {advogado.Nome} adicionado com sucesso!");
        }

        public static void AdicionarCliente(Lista<CasoJuridico> casos, int numeroCaso, Cliente cliente){
            var caso = casos.Find(c => c.Numero == numeroCaso);
            if(caso != null){
                caso.cliente = cliente;
                Console.WriteLine($"Cliente {cliente.Nome} adicionado ao caso {caso.ListaDocumentos[numeroCaso]} com sucesso!");
                
            } else {
                Console.WriteLine($"Caso {numeroCaso} não encontrado.");
            }
        }

    }
}