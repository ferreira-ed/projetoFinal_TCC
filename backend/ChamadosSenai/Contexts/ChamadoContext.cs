using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ChamadosSenai.Domains;

#nullable disable

namespace ChamadosSenai.Contexts
{
    public partial class ChamadoContext : DbContext
    {
        public ChamadoContext()
        {
        }

        public ChamadoContext(DbContextOptions<ChamadoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chamado> Chamados { get; set; }
        public virtual DbSet<Equipamento> Equipamentos { get; set; }
        public virtual DbSet<Instituicao> Instituicaos { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-1T7L9M3\\SQLEXPRESS; Initial Catalog=Chamados; user Id=sa; pwd=senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Chamado>(entity =>
            {
                entity.HasKey(e => e.IdChamado)
                    .HasName("PK__Chamado__500206794E7DAA2B");

                entity.ToTable("Chamado");

                entity.Property(e => e.Andar)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Classe)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Data).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NomeUsuario)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Prioridade)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Sala)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Situacao)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TipoProblema)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TipoServico)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdInstituicaoNavigation)
                    .WithMany(p => p.Chamados)
                    .HasForeignKey(d => d.IdInstituicao)
                    .HasConstraintName("FK__Chamado__IdInsti__29221CFB");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Chamados)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Chamado__IdUsuar__282DF8C2");
            });

            modelBuilder.Entity<Equipamento>(entity =>
            {
                entity.HasKey(e => e.IdEquipamento)
                    .HasName("PK__Equipame__E309D87F63208AAA");

                entity.ToTable("Equipamento");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroPatrimonio)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Quantidade)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TipoEquipamento)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdInstituicaoNavigation)
                    .WithMany(p => p.Equipamentos)
                    .HasForeignKey(d => d.IdInstituicao)
                    .HasConstraintName("FK__Equipamen__IdIns__1DB06A4F");
            });

            modelBuilder.Entity<Instituicao>(entity =>
            {
                entity.HasKey(e => e.IdInstituicao)
                    .HasName("PK__Institui__B771C0D82540B94F");

                entity.ToTable("Instituicao");

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("CEP");

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("CNPJ");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NomeInstituicao)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Pais)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasMaxLength(11)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TipoUsua__CA04062B9C944955");

                entity.ToTable("TipoUsuario");

                entity.Property(e => e.NomeTipoUsuario)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF97106BB405");

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).HasDefaultValueSql("(newid())");

                entity.Property(e => e.EmailUsuario)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SenhaUsuario)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuario__IdTipoU__245D67DE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
