using System.ComponentModel.DataAnnotations;

namespace ExamenU1Elkin.Database.Entities
{
    public class Producto
    {
        public Guid Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El {0} de la categoria es necesario!")]
        public string Name { get; set; }

        [Display(Name = "Cantidad")]
        [MinLength(100, ErrorMessage = "Este campo puede estar vacio.")]
        public string Canti { get; set; }

        [Display(Name = "Precio")]
        [MinLength(100, ErrorMessage = "Este campo no puede estar vacion")]
        public string Sale { get; set; }
    }
}
