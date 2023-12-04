using System;

public class Pessoa
{
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string CPF { get; set; }

    public Pessoa(string nome, string sobrenome, DateTime dataNascimento, string cpf)
    {
        Nome = nome;
        Sobrenome = sobrenome;
        DataNascimento = dataNascimento;
        CPF = cpf;
    }


    public bool ValidarCPF()
    {

        if (CPF.Length != 11)
        {
            return false;
        }

        if (!int.TryParse(CPF, out _))
        {
            Console.WriteLine("CPF deve conter apenas números.");
            return false;
        }

        // Formatando o CPF no estilo padrão (xxx.xxx.xxx-xx)
        string cpfFormatado = string.Format("{0:000\\.000\\.000\\-00}", long.Parse(CPF));

        return cpfFormatado == CPF;
    }

    public bool ValidarDataNascimento()
    {

        if (DataNascimento > DateTime.Now)
        {
            Console.WriteLine("Data de nascimento inválida.");
            return false;
        }

        // Formatar a data no padrão brasileiro (dd/MM/yyyy)
        string dataFormatada = DataNascimento.ToString("dd/MM/yyyy");

        Console.WriteLine($"Data de nascimento formatada: {dataFormatada}");

        return true;

    }
}
