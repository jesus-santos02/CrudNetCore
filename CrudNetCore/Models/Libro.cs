using System.ComponentModel.DataAnnotations;

namespace CrudNetCore.Models
{
    public class Libro
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(50, ErrorMessage = "El campo {0} debe estar comprendido entre {2} y {1} caracteres.", MinimumLength = 3)]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(50, ErrorMessage = "El campo {0} debe estar comprendido entre {2} y {1} caracteres.", MinimumLength = 3)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Lanzamiento")]
        public DateTime FechaLanzamiento { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal Precio { get; set; }
    }
}
