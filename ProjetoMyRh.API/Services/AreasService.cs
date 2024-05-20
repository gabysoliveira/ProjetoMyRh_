using ProjetoMyRh.API.DAL;
using ProjetoMyRh.API.Models.Contexts;
using ProjetoMyRh.API.Models.Entities;

namespace ProjetoMyRh.API.Services
{
    public class AreasService
    {
        public GenericDao<Area, int> AreasDao { get; set; }

        public AreasService(MyRhContext context)
        {
            this.AreasDao = new GenericDao<Area, int>(context);
        }
        public IEnumerable<Area> Listar()
        {
            return AreasDao.Listar();
        }

        public Area? Buscar(int id)
        {
            return AreasDao.Buscar(id);
        }

        public void Incluir(Area area)
        {
            AreasDao.Adicionar(area);
        }

        public void Alterar(Area area)
        {
            AreasDao.Alterar(area);
        }

        public void Remover(Area area)
        {
            AreasDao.Remover(area);
        }
    }

}
