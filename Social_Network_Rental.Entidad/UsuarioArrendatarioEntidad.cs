using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_Network_Rental.Entidad
{
    public class UsuarioArrendatarioEntidad
    {
        public int Cod_Arrendatario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }

        public string Email { get; set; }

        public string Direccion { get; set; }
        public string Celular { get; set; }
        public string usuario { get; set; }
        public string contraseña { get; set; }

        public char estado { get; set; }
    }
}
