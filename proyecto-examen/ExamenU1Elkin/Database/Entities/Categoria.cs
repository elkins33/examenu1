using System.ComponentModel.DataAnnotations;

namespace ExamenU1Elkin.Database.Entities
{
    public class Categoria
    {

        public Guid Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El {0} de la categoria es necesario!")]
        public string Name { get; set; }
    }
}
