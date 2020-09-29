using System.ComponentModel.DataAnnotations;

namespace JMusik.Dtos
{
    public class UsuarioRegistroDto
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre del Usuario")]
        public string Nombre { get; set; }
        [Display(Name = "Apellidos del Usuario")]
        public string Apellidos { get; set; }
        [Required]
        [Display(Name = "Correo Electrónico")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Cuenta")]
        public string Username { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Perfil del usuario")]
        public int PerfilId { get; set; }
        public string Perfil { get; set; }
    }

}
