using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FastFiles.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Nombre es requerido")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Campo Contraseña es requerido")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Campo Correo es requerido")]
        public string? Email { get; set; }

        [JsonIgnore]
        public List<Folder>? Folders { get; set; }
    }
}