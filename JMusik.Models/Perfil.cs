using System;
using System.Collections.Generic;

namespace JMusik.Models
{
    public class Perfil
    {
        public Perfil()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
