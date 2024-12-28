using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab_biblioteca.Models;

public partial class Emprestimo
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_usuario")]
    public int IdUsuario { get; set; }

    [Column("id_livro")]
    public int IdLivro { get; set; }

    [Column("data_requisicao")]
    public DateOnly DataRequisicao { get; set; }

    [Column("data_devolucao")]
    public DateOnly? DataDevolucao { get; set; }

    [Column("data_limite")]
    public DateOnly DataLimite { get; set; }

    [ForeignKey("IdLivro")]
    [InverseProperty("Emprestimos")]
    public virtual Livro IdLivroNavigation { get; set; } = null!;

    [ForeignKey("IdUsuario")]
    [InverseProperty("Emprestimos")]
    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
