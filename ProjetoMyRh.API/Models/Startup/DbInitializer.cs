using ProjetoMyRh.API.Models.Contexts;

namespace ProjetoMyRh.API.Models.Startup
{
    public class DbInitializer
    {
        public static void Initializer(MyRhContext context) { context.Database.EnsureCreated(); }
    }
}
