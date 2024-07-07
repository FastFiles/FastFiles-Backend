using System.ComponentModel.DataAnnotations;

namespace FastFiles.Models
{
    public class Folder
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Nombre es requerido")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Campo Descripción es requerido")]
        public string? Description { get; set; }

        // [Required(ErrorMessage = "Campo Fecha de Creación es requerido")]
        public DateTime? DateCreated { get; set; }

        // [Required(ErrorMessage = "Campo Fecha de Modificación es requerido")]
        public DateTime? DateModified { get; set; }

        [Required(ErrorMessage = "Campo Ubicación es requerido")]
        public string? Location { get; set; }

        // [Required(ErrorMessage = "Campo Estado es requerido")]
        public string? Status { get; set; }

        [Required(ErrorMessage = "Relación de Usuario es requerido")]
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}