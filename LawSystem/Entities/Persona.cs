#region Definições de Pessoa, Advogado e Cliente herdam essas definições.

namespace LawSystem.Entities{
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
        public virtual bool ValidarCPF(List<Pessoa> pessoas)
        {
            if (CPF.Length != 11 || !int.TryParse(CPF, out _))
            {
                Console.WriteLine("CPF inválido.");
                return false;
            }

            string cpfFormatado = string.Format("{0:000\\.000\\.000\\-00}", long.Parse(CPF));

            if (cpfFormatado != CPF)
            {
                Console.WriteLine("CPF inválido.");
                return false;
            }

            if (pessoas.Exists(p => p.CPF == CPF))
            {
                Console.WriteLine("CPF já cadastrado.");
                return false;
            }

            return true;
        }

        public virtual bool ValidarDataNascimento()
        {

            if (DataNascimento > DateTime.Now)
            {
                Console.WriteLine("Data de nascimento inválida.");
                return false;
            }

            string dataFormatada = DataNascimento.ToString("dd/MM/yyyy");

            Console.WriteLine($"Data de nascimento formatada: {dataFormatada}");

            return true;

        }

        public class Advogado : Pessoa
        {
            public string CNA { get; set; }

            public Advogado(string nome, string sobrenome, DateTime dataNascimento, string cpf, string cna)
                : base(nome, sobrenome, dataNascimento, cpf)
            {
                CNA = cna;
            }


            public override bool ValidarCPF(List<Pessoa> pessoas)
            {
                if (!base.ValidarCPF(pessoas))
                {
                    return false;
                }

                if (CNA.Length != 6 && CNA.Length == 0)
                {
                    Console.WriteLine("CNA inválido.");
                    return false;
                }

                if (pessoas.Exists(p => p is Advogado advogado && advogado.CNA == CNA))
                {
                    Console.WriteLine("CNA já cadastrado.");
                    return false;
                }

                return true;
            }

            public override bool ValidarDataNascimento()
            {
                return base.ValidarDataNascimento();
            }
        }

        public class Cliente : Pessoa
        {
            public string EstadoCivil { get; set; }
            public string Profissao { get; set; }

            public Cliente(string nome, string sobrenome, DateTime dataNascimento, string cpf, string estadoCivil, string profissao)
                : base(nome, sobrenome, dataNascimento, cpf)
            {
                EstadoCivil = estadoCivil;
                Profissao = profissao;
            }

            public override bool ValidarCPF(List<Pessoa> pessoas)
            {
                if (!base.ValidarCPF(pessoas))
                {
                    return false;
                }

                if (pessoas.Exists(p => p is Cliente cliente && cliente.CPF == CPF))
                {
                    Console.WriteLine("CPF já cadastrado para um cliente.");
                    return false;
                }

                return true;
            }   

            public override bool ValidarDataNascimento()
            {
                return base.ValidarDataNascimento();
            }

            public bool ValidarEstadoCivil()
            {
                if (string.IsNullOrEmpty(EstadoCivil))
                {
                    Console.WriteLine("Estado civil não pode ser vazio.");
                    return false;
                }
                return true;
            }
        }
    }
}
#endregion 