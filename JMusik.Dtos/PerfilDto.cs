using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JMusik.Dtos
{
    public class PerfilDto
    {
        public int Id { get; set; }
        [Display(Name = "Perfil")]
        [Required(ErrorMessage = "El nombre del perfil es requerido")]
        public string Nombre { get; set; }
    }

}
