namespace ProjetoMyRh.API.Models.DTO
{
    public class InscricoesDTO
    {
        public int IdIsncricao { get; set; }
        public string? Cargo { get; set; }
        public double Salario { get; set; }
        public DateTime DataInscricao { get; set; }
        public string? Candidato { get; set; }
    }
}
