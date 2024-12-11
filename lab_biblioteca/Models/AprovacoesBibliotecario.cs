using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace lab_biblioteca.Models;

public partial class AprovacoesBibliotecario
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_bibliotecario")]
    public int IdBibliotecario { get; set; }

    [Column("id_administrador")]
    public int IdAdministrador { get; set; }

    [Column("data_aprovacao", TypeName = "datetime")]
    public DateTime? DataAprovacao { get; set; }

    [ForeignKey("IdAdministrador")]
    [InverseProperty("AprovacoesBibliotecarioIdAdministradorNavigations")]
    public virtual Usuario IdAdministradorNavigation { get; set; } = null!;

    [ForeignKey("IdBibliotecario")]
    [InverseProperty("AprovacoesBibliotecarioIdBibliotecarioNavigations")]
    public virtual Usuario IdBibliotecarioNavigation { get; set; } = null!;
}
