using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab_biblioteca.Models;

public partial class HistoricoBloqueio
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_usuario")]
    public int IdUsuario { get; set; }

    [Column("motivo")]
    public string? Motivo { get; set; }

    [Column("data_bloqueio", TypeName = "datetime")]
    public DateTime? DataBloqueio { get; set; }

    [ForeignKey("IdUsuario")]
    [InverseProperty("HistoricoBloqueios")]
    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
