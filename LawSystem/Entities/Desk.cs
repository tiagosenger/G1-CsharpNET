#region Classes Documento e Caso Jurídico, e métodos relacionados ao ambiente de escritório.
using System.Globalization;
using Exceptions;
using static LawSystem.Entities.Pessoa;

namespace LawSystem.Entities{
    class Documento{
        public int Codigo {get; set;}
        private DateTime modificacao;

        public DateTime Modificacao => modificacao;

        public void SetModificacao(string data){
            if(DateTime.TryParseExact(data, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out modificacao)){

            } else {
                throw new DataInvalidaException("Data fornecida inválida!");
            }
        }

        public string? Tipo {get; set;}
        public string? Descricao {get; set;}

        public Documento(int codigo, string modificacao, string tipo, string descricao){
            Codigo = codigo;
            SetModificacao(modificacao);
            Tipo = tipo;
            Descricao = descricao;
        }
    }

    class CasoJuridico {
        private DateTime abertura;
        public DateTime Abertura => abertura;
        public float ProbabilidadeSucesso {get; set;}
        public List<Documento> Documentos {get; set;}
        private List<(float, string)> custos;
        public float CustoTotal{
            get{
                float total = 0.0f;

                foreach(var custo in custos){
                    total += custo.Item1;
                }

                return total;
            }
        }
        private DateTime? encerramento;
        public DateTime? Encerramento {
            get {return encerramento;}
            private set {encerramento = value;}
        }
        public List<Advogado> Advogados {get;}
        public Cliente ClienteCaso {get;set;}
        private string? status;
        public string? Status {
            get {return status;}
            set {
                if(value != "Em aberto" && value != "Concluído" && value != "Arquivado"){
                    throw new StatusInvalidoException("Status inválido! O status deve ser 'Em aberto', 'Concluído' ou 'Arquivado'");
                } else {
                    status = value;
                }
            }
        }

        public CasoJuridico(string dataAbertura, float probabilidadeSucesso/*, Cliente cliente*/){
            setaDataAbertura(dataAbertura);
            ProbabilidadeSucesso = probabilidadeSucesso;
            advogados = new();
            ClienteCaso = cliente;
            Status = "Em aberto";
            custos = new();
        }

        public void setaDataAbertura(string entrada){
            if(DateTime.TryParseExact(entrada, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out abertura)){

            } else {
                throw new DataInvalidaException("Data de abertura fornecida inválida!");
            }
        }

        public void setDataEncerramento(string data){
            if(Status == "Em aberto"){
                throw new DataInvalidaException("O caso está em aberto! Não pode haver uma data de encerramento!");
            }

            DateTime dataConvertida;
            if(DateTime.TryParseExact(data, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataConvertida)){

            } else {
                throw new DataInvalidaException("Data de encerramento fornecida inválida!");
            }

            if(DateTime.Compare(Abertura, dataConvertida) < 0) Encerramento = dataConvertida;
            else throw new DataInvalidaException("A data de encerramento precisa ser posterior à data de abertura do caso!");
        }

        public void adicionaCusto(float valor, string descricao){
            custos.Add((valor, descricao));
        }

        public void adicionaAdvogado(Advogado advogado){
            Advogados.Add(advogado);
        }
        
    }
}

#endregion 