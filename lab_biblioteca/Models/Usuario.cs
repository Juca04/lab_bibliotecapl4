using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab_biblioteca.Models;

[Index("Email", Name = "UQ__Usuarios__AB6E6164CE0CB7B8", IsUnique = true)]
[Index("Username", Name = "UQ__Usuarios__F3DBC572C794DC88", IsUnique = true)]
public partial class Usuario
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("nome")]
    [StringLength(255)]
    public string Nome { get; set; } = null!;

    [Column("email")]
    [StringLength(255)]
    public string Email { get; set; } = null!;

    [Column("username")]
    [StringLength(100)]
    public string Username { get; set; } = null!;

    [Column("password")]
    [StringLength(255)]
    public string Password { get; set; } = null!;

    [Column("morada")]
    public string? Morada { get; set; }

    [Column("contatos")]
    [StringLength(255)]
    public string? Contatos { get; set; }

    [Column("tipo")]
    [StringLength(50)]
    public string Tipo { get; set; } = null!;

    [Column("status")]
    [StringLength(50)]
    public string? Status { get; set; }

    [Column("motivo_bloqueio")]
    public string? MotivoBloqueio { get; set; }

    [Column("data_registro", TypeName = "datetime")]
    public DateTime? DataRegistro { get; set; }

    [InverseProperty("IdAdministradorNavigation")]
    public virtual ICollection<AprovacoesBibliotecario> AprovacoesBibliotecarioIdAdministradorNavigations { get; set; } = new List<AprovacoesBibliotecario>();

    [InverseProperty("IdBibliotecarioNavigation")]
    public virtual ICollection<AprovacoesBibliotecario> AprovacoesBibliotecarioIdBibliotecarioNavigations { get; set; } = new List<AprovacoesBibliotecario>();

    [InverseProperty("IdUsuarioNavigation")]
    public virtual ICollection<Emprestimo> Emprestimos { get; set; } = new List<Emprestimo>();

    [InverseProperty("IdUsuarioNavigation")]
    public virtual ICollection<HistoricoBloqueio> HistoricoBloqueios { get; set; } = new List<HistoricoBloqueio>();
}
