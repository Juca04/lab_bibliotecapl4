using Microsoft.EntityFrameworkCore;

namespace lab_biblioteca.Models;

public partial class BibliotecaContext : DbContext
{
    public BibliotecaContext()
    {
    }

    public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AprovacoesBibliotecario> AprovacoesBibliotecarios { get; set; }

    public virtual DbSet<Emprestimo> Emprestimos { get; set; }

    public virtual DbSet<HistoricoBloqueio> HistoricoBloqueios { get; set; }

    public virtual DbSet<Livro> Livros { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=defaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AprovacoesBibliotecario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Aprovaco__3213E83F2DB0608F");

            entity.Property(e => e.DataAprovacao).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdAdministradorNavigation).WithMany(p => p.AprovacoesBibliotecarioIdAdministradorNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Aprovacoe__id_ad__48CFD27E");

            entity.HasOne(d => d.IdBibliotecarioNavigation).WithMany(p => p.AprovacoesBibliotecarioIdBibliotecarioNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Aprovacoe__id_bi__47DBAE45");
        });

        modelBuilder.Entity<Emprestimo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Empresti__3213E83F0E657AF8");

            entity.HasOne(d => d.IdLivroNavigation).WithMany(p => p.Emprestimos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Emprestim__id_li__440B1D61");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Emprestimos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Emprestim__id_us__4316F928");
        });

        modelBuilder.Entity<HistoricoBloqueio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Historic__3213E83F51503E64");

            entity.Property(e => e.DataBloqueio).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.HistoricoBloqueios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Historico__id_us__4CA06362");
        });

        modelBuilder.Entity<Livro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Livros__3213E83FF706FA97");

            entity.Property(e => e.NumExemplares).HasDefaultValue(1);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3213E83F31E32112");

            entity.Property(e => e.DataRegistro).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status).HasDefaultValue("Ativo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
