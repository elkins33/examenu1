using System.ComponentModel.DataAnnotations;

namespace ExamenU1Elkin.Dtos.Categories
{
    public class CategoryCreateDto
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo de la categoria es requerido!")]
        public string Name { get; set; }

        [Display(Name = "Cantidad")]
        [MinLength(100, ErrorMessage = "El campo debe tener caracteres!")]
        public string Canti { get; set; }


    }
}
