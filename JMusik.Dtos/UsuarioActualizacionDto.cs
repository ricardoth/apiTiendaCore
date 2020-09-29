using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JMusik.Dtos
{
    public class UsuarioActualizacionDto
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
    }
}
