namespace ProjetoMyRh.API.Models.Entities
{
    public class Cargo
    {
        public int Id { get; set; }
        public int AreaId { get; set; }
        public string? Descricao { get; set; }
        public double Salario { get; set; }
        public int TipoSalario { get; set; }
        public Area? Areas { get; set; }
        public ICollection<Inscricao>? Inscricoes { get; set; }
    }
}
