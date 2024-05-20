using Microsoft.EntityFrameworkCore;
using ProjetoMyRh.API.Models.Entities;

namespace ProjetoMyRh.API.Models.Contexts
{
    public class MyRhContext : DbContext
    {
        public MyRhContext(DbContextOptions<MyRhContext> options) :base(options) { }

        public DbSet<Area> Areas { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Inscricao> Inscricoes { get; set; }
        public DbSet<Candidato> Candidatos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapeamento das entidades para as tabelas 
            modelBuilder.Entity<Area>().ToTable("TB_AREAS");
            modelBuilder.Entity<Cargo>().ToTable("TB_CARGOS");
            modelBuilder.Entity<Inscricao>().ToTable("TB_INSCRICOES");
            modelBuilder.Entity<Candidato>().ToTable("TB_CANDIDATOS");
            // Mapeamento das propriedades para as colunas 
            modelBuilder.Entity<Area>()
                .Property(p => p.Descricao)
                .HasColumnName("DESCRICAO")
                .HasMaxLength(100);
            modelBuilder.Entity<Cargo>()
                .Property(p => p.Descricao)
                .HasColumnName("DESCRICAO")
                .HasMaxLength(100);
            modelBuilder.Entity<Cargo>()
                .Property(p => p.AreaId)
                .HasColumnName("ID_AREA");
            modelBuilder.Entity<Cargo>()
                .Property(p => p.TipoSalario)
                .HasColumnName("TP_SALARIO");

            modelBuilder.Entity<Inscricao>()
                .Property(p => p.DataInscricao)
                .HasColumnName("DATA_INSCRICAO");
            modelBuilder.Entity<Inscricao>()
                .Property(p => p.CargoId)
                .HasColumnName("ID_CARGO");
            modelBuilder.Entity<Inscricao>()
                .Property(p => p.DataEfetivacao)
                .HasColumnName("DATA_EFETIVACAO");
        }
    }
}
