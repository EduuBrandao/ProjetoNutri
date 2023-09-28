using Infra.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Infra.Data
{
    public partial class NutriContext : DbContext
    {
        private readonly ConnectionString connectionStringsConfig;

        public NutriContext(IOptions<ConnectionString> ConnectionStringConfig)
        {
            connectionStringsConfig = ConnectionStringConfig.Value;
        }

        public NutriContext(DbContextOptions<NutriContext> options, IOptions<ConnectionString> connectionStringsCofingOptions)
            : base(options)
        {
            connectionStringsConfig = connectionStringsCofingOptions.Value;
        }

        public virtual DbSet<ClientesConfig> DadosClientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<ClientesConfig>(entity =>
            {
                entity.ToTable("clientes");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("id"); // Certifique-se de que a propriedade corresponda ao nome da coluna no banco de dados

                entity.Property(e => e.nome)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.cpf)
                    .HasMaxLength(11) // Ajuste o tamanho máximo conforme necessário
                    .IsUnicode(false);

                entity.Property(e => e.idade)
                    .HasColumnType("int"); // Corrigido para int

                entity.Property(e => e.sexo)
                    .HasMaxLength(1) // Ajuste o tamanho máximo conforme necessário
                    .IsUnicode(false);

                entity.Property(e => e.peso)
                    .HasColumnType("decimal(5,2)"); // Corrigido para decimal(5,2)

                entity.Property(e => e.altura)
                    .HasColumnType("decimal(3,2)"); // Corrigido para decimal(3,2)
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
