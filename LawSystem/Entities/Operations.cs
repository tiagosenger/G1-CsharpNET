#region Métodos relacionados à adição, edição ou exclusão de dados. 
public class Operations
{
    public static void IniciarCaso(CasoJuridico caso, DateTime dataInicio){
        if (caso.Status == StatusCaso.EmAberto)
        {
            caso.DataInicio = dataInicio;
            Console.WriteLine($"Caso iniciado em {dataInicio}.");
        }
        else
        {
            Console.WriteLine("Não é possível iniciar um caso que não está em aberto.");
        }
    }

    public static void AtualizarCaso(CasoJuridico caso, DateTime? dataConclusao, List<Advogado> advogados){
        if (caso.Status == StatusCaso.EmAberto && !dataConclusao.HasValue)
        {
            Console.WriteLine("Ao concluir um caso, é necessário fornecer uma data de conclusão.");
            return;
        }

        if (dataConclusao.HasValue && dataConclusao < caso.DataInicio)
        {
            Console.WriteLine("A data de conclusão deve ser posterior à data de início.");
            return;
        }

        caso.DataConclusao = dataConclusao;
        caso.Status = dataConclusao.HasValue ? StatusCaso.Concluido : StatusCaso.EmAberto;

        if (advogados.Count > 0)
        {
            caso.AdicionarAdvogados(advogados);
        }

        Console.WriteLine($"Caso atualizado. Status: {caso.Status}, Data de Conclusão: {caso.DataConclusao}");
    }

    public static void ExcluirCaso(List<CasoJuridico> casos, int numeroCaso){    
        CasoJuridico caso = casos.Find(c => c.Numero == numeroCaso);

        if (caso != null)
        {
            casos.Remove(caso);
            Console.WriteLine($"Caso {numeroCaso} excluído com sucesso.");
        }
        else
        {
            Console.WriteLine($"Caso {numeroCaso} não encontrado.");
        }
    }

    public static void AdicionarAdvogado(Escritorio escritorio, Advogado advogado){
        try
        {
            escritorio.AdicionarAdvogado(advogado);
            Console.WriteLine("Advogado adicionado com sucesso!");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Erro ao adicionar advogado: {ex.Message}");
        }
    }

    public static void AdicionarCliente(Escritorio escritorio, Cliente cliente){
        try
        {
            escritorio.AdicionarCliente(cliente);
            Console.WriteLine("Cliente adicionado com sucesso!");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Erro ao adicionar cliente: {ex.Message}");
        }
    }

    public static void EditarAdvogado(Advogado advogado, string novoNome, DateTime novaDataNascimento, string novoCNA){
        advogado.Nome = novoNome;
        advogado.DataNascimento = novaDataNascimento;
        advogado.CNA = novoCNA;
        Console.WriteLine("Advogado editado com sucesso!");
    }

    public static void ExcluirAdvogado(Escritorio escritorio, Advogado advogado){
        escritorio.RemoverAdvogado(advogado);
        Console.WriteLine("Advogado removido com sucesso!");
    }

    public static void EditarCliente(Cliente cliente, string novoNome, DateTime novaDataNascimento, string novoEstadoCivil, string novaProfissao){
        cliente.Nome = novoNome;
        cliente.DataNascimento = novaDataNascimento;
        cliente.EstadoCivil = novoEstadoCivil;
        cliente.Profissao = novaProfissao;
        Console.WriteLine("Cliente editado com sucesso!");
    }

    public static void ExcluirCliente(Escritorio escritorio, Cliente cliente){
        escritorio.RemoverCliente(cliente);
        Console.WriteLine("Cliente removido com sucesso!");
    }

}
#endregion