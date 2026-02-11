using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using VhBurguer.Domains;

namespace VhBurguer.Contexts;

public partial class VhBurguerDbContext : DbContext
{
    public VhBurguerDbContext()
    {
    }

    public VhBurguerDbContext(DbContextOptions<VhBurguerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Log_AlteracaoProduto> Log_AlteracaoProduto { get; set; }

    public virtual DbSet<Produto> Produto { get; set; }

    public virtual DbSet<ProdutoPromocao> ProdutoPromocao { get; set; }

    public virtual DbSet<Promocao> Promocao { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=VhBurguerDb;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.CategoriaId).HasName("PK__Categori__F353C1E530CA6354");

            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Log_AlteracaoProduto>(entity =>
        {
            entity.HasKey(e => e.Log_AltercaoProdutoId).HasName("PK__Log_Alte__C368CC2E74711688");

            entity.Property(e => e.DataAlteracao).HasColumnType("datetime");
            entity.Property(e => e.NomeAnterior)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PrecoAnterior).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Produto).WithMany(p => p.Log_AlteracaoProduto)
                .HasForeignKey(d => d.ProdutoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Log_AlteracaoProduto");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.ProdutoId).HasName("PK__Produto__9C8800E34ED8BEEA");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("trg_AlteracaoProduto");
                    tb.HasTrigger("trg_Produto_StatusProduto");
                });

            entity.HasIndex(e => e.Nome, "UQ__Produto__7D8FE3B2A6B9F664").IsUnique();

            entity.Property(e => e.Nome).HasMaxLength(100);
            entity.Property(e => e.Preco).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.StatusProduto).HasDefaultValue(true);

            entity.HasOne(d => d.Usuario).WithMany(p => p.Produto)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasMany(d => d.Categoria).WithMany(p => p.Produto)
                .UsingEntity<Dictionary<string, object>>(
                    "ProdutoCategoria",
                    r => r.HasOne<Categoria>().WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    l => l.HasOne<Produto>().WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey("ProdutoId", "CategoriaId").HasName("PK_ProdutoCategoria_ProdutoId_CategoriaId");
                    });
        });

        modelBuilder.Entity<ProdutoPromocao>(entity =>
        {
            entity.HasKey(e => new { e.ProdutoId, e.PromocaoId }).HasName("PK_ProdutoPromocao_ProdutoId_PromocaoId");

            entity.Property(e => e.PrecoAtual).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Produto).WithMany(p => p.ProdutoPromocao)
                .HasForeignKey(d => d.ProdutoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProdutoPromocao_ProdutoId");
        });

        modelBuilder.Entity<Promocao>(entity =>
        {
            entity.HasKey(e => e.PromocaoId).HasName("PK__Promocao__254B581D0CB71B5F");

            entity.HasIndex(e => e.Nome, "UQ__Promocao__7D8FE3B2E3677C2B").IsUnique();

            entity.Property(e => e.DataExpiracao).HasColumnType("datetime");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StatusPromocao).HasDefaultValue(true);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuario__2B3DE7B869993D60");

            entity.ToTable(tb => tb.HasTrigger("trg_Usuario_StatusUsuario"));

            entity.HasIndex(e => e.Email, "UQ__Usuario__A9D105347896E4AA").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Senha).HasMaxLength(32);
            entity.Property(e => e.StatusUsuario).HasDefaultValue(true);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
