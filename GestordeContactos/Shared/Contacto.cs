using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestordeContactos.Shared
{
    public class Contacto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Celular { get; set; }
        public string Dirección { get; set; }

        public string NombreCompleto { get { return Apellido + ", " + Nombre; } }
    }
}
