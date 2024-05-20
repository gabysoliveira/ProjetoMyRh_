using ProjetoMyRh.API.DAL;
using ProjetoMyRh.API.Models.Contexts;
using ProjetoMyRh.API.Models.Entities;

namespace ProjetoMyRh.API.Services
{
    public class CandidatosService
    {
        public GenericDao<Candidato, string>? CandidatosDao { get; set; }

        public CandidatosService(MyRhContext context)
        {
            this.CandidatosDao = new GenericDao<Candidato, string> (context);
        }

        public IEnumerable<Candidato> Listar()
        {
            return CandidatosDao!.Listar();
        }

        public Candidato? Buscar(string? cpf)
        {
            return CandidatosDao!.Buscar(cpf!);
        }

        public void Alterar(Candidato? candidato)
        {
            CandidatosDao?.Alterar(candidato!);
        }

        public void Remover(Candidato? candidato)
        {
            CandidatosDao?.Remover(candidato!);
        }

        public void Incluir(Candidato? candidato)
        {
            CandidatosDao!.Adicionar(candidato!);
        }

    }
}
