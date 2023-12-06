namespace Validations;
using Advogado = LawSystem.Entities.Pessoa.Advogado;
using Cliente = LawSystem.Entities.Pessoa.Cliente;

public class Validator {
    public static bool validacaoCpfAdvogado(List<Advogado> advogados, string cpf){
        if(cpf.Length != 11) return false;

        if(advogados.Exists(a => a.CPF == cpf)) return false;

        string cpfFormatado = string.Format("{0:000\\.000\\.000\\-00}", long.Parse(cpf));

        if (cpfFormatado != cpf) {
            Console.WriteLine("CPF inválido.");
            return false;
        }

        return true;
    }

    public static bool validacaoCpfCliente(List<Cliente> clientes, string cpf){
        if(cpf.Length != 11) return false;

        if(clientes.Exists(a => a.CPF == cpf)) return false;

        string cpfFormatado = string.Format("{0:000\\.000\\.000\\-00}", long.Parse(cpf));

        if (cpfFormatado != cpf) {
            Console.WriteLine("CPF inválido.");
            return false;
        }

        return true;
    }

    public static bool validacaoCna(List<Advogado> advogados, string cna){
        if(advogados.Exists(a => a.CNA == cna)) return false;

        return true;
    }
}
