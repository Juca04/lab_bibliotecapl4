using System.ComponentModel.DataAnnotations;

namespace aula02.Controllers
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Required field")]
        [StringLength(50, MinimumLength =3, ErrorMessage ="{0} lenght must be between {2} and {1}")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Required field")]
        [MaxLength(256, ErrorMessage ="{0} lenght can not exceed {1} characters")]
        public string Description { get; set; }

        public Boolean State { get; set; } = true; //default value
    }
}
