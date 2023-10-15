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
        public virtual DbSet<EnderecoConfig> EnderecoClientes { get; set; }

        public virtual DbSet<LoginConfig> LoginClientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<ClientesConfig>(entity =>
            {
                entity.ToTable("clientes");

                entity.HasKey(e => e.id);

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.nome).HasMaxLength(100).IsUnicode(false);

                entity.Property(e => e.cpf).HasMaxLength(11).IsUnicode(false);

                entity.Property(e => e.idade).HasColumnType("int");

                entity.Property(e => e.sexo).HasMaxLength(1).IsUnicode(false);

                entity.Property(e => e.peso).HasColumnType("decimal(5,2)");

                entity.Property(e => e.altura).HasColumnType("decimal(3,2)");
            });

            modelBuilder.Entity<LoginConfig>(entity =>
            {
                entity.ToTable("Login");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.Password).IsRequired();
                entity.Property(e => e.UserType).IsRequired().HasMaxLength(50); // Defina o tamanho adequado aqui
            });

            modelBuilder.Entity<EnderecoConfig>(entity =>
        {
            entity.ToTable("enderecos");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Pais)
                .IsUnicode(false)
                .HasMaxLength(255)
                .IsRequired();

            entity.Property(e => e.Cidade)
                .IsUnicode(false)
                .HasMaxLength(255)
                .IsRequired();

            entity.Property(e => e.Estado)
                .IsUnicode(false)
                .HasMaxLength(255)
                .IsRequired();

            entity.Property(e => e.Endereco)
                .IsUnicode(false)
                .HasMaxLength(255)
                .IsRequired();

            entity.Property(e => e.Bairro)
                .IsUnicode(false)
                .HasMaxLength(255)
                .IsRequired();

            entity.Property(e => e.Numero)
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(e => e.Complemento)
                .IsUnicode(false)
                .HasMaxLength(255);

            entity.Property(e => e.ClientId).IsUnicode(false);

        });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
