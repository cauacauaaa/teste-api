using CidadeInteligente.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CidadeInteligente.Data.Contexts
{
    public class DatabaseContext : DbContext
    {

        public virtual DbSet<UsuarioModel> Usuarios { get; set; }
        public virtual DbSet<AcidenteModel> Acidentes { get; set; }
        public virtual DbSet<MonitorModel> Monitores { get; set; }
        public virtual DbSet<ViolacaoModel> Violacoes { get; set; }
        public virtual DbSet<SemaforoModel> Semaforos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioModel>(entity =>
            {
                entity.ToTable("Usuarios");
                entity.HasKey(e => e.UsuarioId);
                entity.Property(e => e.UsuarioNome).IsRequired();
                entity.Property(e => e.Email).IsRequired();
                                
            });

            modelBuilder.Entity<MonitorModel>(entity =>
            {
                entity.ToTable("Monitor_Trafego");
                entity.HasKey(m => m.MonitorId);
                entity.Property(m => m.Dia).IsRequired().HasColumnType("date");
                entity.Property(m => m.Loc).IsRequired();
                entity.Property(m => m.ContVeic).IsRequired();
                entity.Property(m => m.VelMedia).IsRequired();

  
            });

            modelBuilder.Entity<AcidenteModel>(entity =>
            {
                entity.ToTable("Acidentes_Reportados");
                entity.HasKey(a => a.AcidenteId);
                entity.Property(a => a.Descricao).IsRequired();
                entity.Property(a => a.Severidade).IsRequired();
            });

            modelBuilder.Entity<ViolacaoModel>(entity =>
            {
                entity.ToTable("Violacoes");
                entity.HasKey(v => v.ViolacaoId);
                entity.Property(v => v.Tipo).IsRequired();
                entity.Property(v => v.Placa).IsRequired();


            });

        
            modelBuilder.Entity<SemaforoModel>(entity =>
            {
                entity.ToTable("Dados_Semaforo");
                entity.HasKey(s => s.SemaforoId);
                entity.Property(s => s.Estado).IsRequired();
                entity.Property(s => s.Duracao);
            });


        }
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
        protected DatabaseContext()
        {
        }

    }
}