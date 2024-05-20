namespace ProjetoMyRh.API.Models.Entities
{
    public class Inscricao
    {
        public int Id { get; set; }
        public int CargoId { get; set; }
        public string? Cpf { get; set; }
        public System.Int16 Situacao { get; set; }
        public DateTime DataInscricao { get; set; }
        public DateTime DataEfetivacao { get; set; }
        public Cargo? Cargo { get; set; }
        public Candidato? Candidato { get; set; }
    }
}
