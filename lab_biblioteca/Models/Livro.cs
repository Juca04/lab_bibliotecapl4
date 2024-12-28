using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab_biblioteca.Models;

[Index("Isbn", Name = "UQ__Livros__99F9D0A4B90ACDFC", IsUnique = true)]
public partial class Livro
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("titulo")]
    [StringLength(255)]
    public string Titulo { get; set; } = null!;

    [Column("autor")]
    [StringLength(255)]
    public string Autor { get; set; } = null!;

    [Column("genero")]
    [StringLength(50)]
    public string? Genero { get; set; }

    [Column("preco", TypeName = "decimal(10, 2)")]
    public decimal? Preco { get; set; }

    [Column("isbn")]
    [StringLength(13)]
    public string Isbn { get; set; } = null!;

    [Column("num_exemplares")]
    public int NumExemplares { get; set; }

    [InverseProperty("IdLivroNavigation")]
    public virtual ICollection<Emprestimo> Emprestimos { get; set; } = new List<Emprestimo>();
}
