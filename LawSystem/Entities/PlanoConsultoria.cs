namespace LawSystem.Entities
{
    public class PlanoConsultoria{
        public string? Titulo { get; set; }
        public double ValorPorMes { get; set; }
        public List<string> Beneficios = new();
    }
}