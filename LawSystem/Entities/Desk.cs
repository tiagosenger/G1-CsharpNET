#region Classes Documento e Caso Jurídico, e métodos relacionados ao ambiente de escritório.
using Advogado = LawSystem.Entities.Pessoa.Advogado;
using Cliente = LawSystem.Entities.Pessoa.Cliente;
namespace LawSystem.Entities{

public class Escritorio{        
    public class Documento
    {

        public DateTime DataDeModificacao { get; set; }
        public int Codigo { get; set;}
        public string? Tipo { get; set; }
        public string? Descricao {get; set;}

        public Documento(DateTime dataDeModificacao, int codigo, string? tipo, string? descricao)
        {
            DataDeModificacao = dataDeModificacao;
            Codigo = codigo;
            Tipo = tipo;
            Descricao = descricao;
        }
    }

        public class CasoJuridico
    {
        public static int codigoCasos = 1;
        public int Id {get; set;}
        public DateTime Abertura { get; set; }
        public float ProbabilidadeSucesso { get; set; }
        public List<Documento> Documentos { get; private set; } 
        public List<(float Custos, string Descricao)>? Custos { get; set; }
        public DateTime Encerramento { get; set; }
        public List<Advogado>? Advogados { get; set; }
        public Cliente? Cliente { get; set; }
        public string? Status { get; set; }

        public CasoJuridico(DateTime abertura, float probabilidadeSucesso, List<(DateTime DataDeModificacao, int Codigo, string? Tipo, string? Descricao)> documentos,
                            List<(float Custos, string Descricao)>? custos,
                            List<Advogado>? advogados, Cliente? cliente, string? status)
        {
            Id = codigoCasos;
            Abertura = abertura;
            ProbabilidadeSucesso = probabilidadeSucesso;
            Documentos = documentos.Select(doc => new Documento(doc.DataDeModificacao, doc.Codigo, doc.Tipo, doc.Descricao)).ToList();
            Custos = custos;
            Advogados = advogados;
            Cliente = cliente;
            Status = status;
            codigoCasos++;
        }

        public void AdicionarDocumento(Documento documento)
        {
            Documentos.Add(documento);
            Console.WriteLine("Documento adicionado ao Caso Jurídico com sucesso!");
        }

        public void ListarDocumentos()
        {
            Console.WriteLine("Documentos Associados ao Caso Jurídico:");
            foreach (var documento in Documentos)
            {
                ExibirInformacoesDocumento(documento);
                Console.WriteLine();
            }
        }

        public void DeletarDocumento(int codigo)
        {
            try
            {
                var documento = Documentos.Find(d => d.Codigo == codigo);

                if (documento != null)
                {
                    Documentos.Remove(documento);
                    Console.WriteLine("Documento deletado com sucesso!!!\n");
                }
                else
                {
                    throw new("Documento não encontrado");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ExibirInformacoesDocumento(Documento documento)
        {
            Console.WriteLine($"Código: {documento.Codigo}");
            Console.WriteLine($"Tipo: {documento.Tipo ?? "N/A"}");
            Console.WriteLine($"Descrição: {documento.Descricao ?? "N/A"}");
            Console.WriteLine($"Data de Modificação: {documento.DataDeModificacao:dd/MM/yyyy}");
        }

        }
    }
}

#endregion 