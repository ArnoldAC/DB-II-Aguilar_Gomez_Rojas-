using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Social_Network_Rental.Datos;
using Social_Network_Rental.Entidad;

namespace Social_Network_Rental.Negocio
{
    public class UsuarioArrendatarioNegocio
    {
        public static string Insertar(string Usuario, string Nombre, string Apellido, string Dni, string Celular, string Email, string Direccion, string Contraseña)
        {
            UsuarioArrendatarioDatos objArrendatario = new UsuarioArrendatarioDatos();

            string Existe = objArrendatario.Existe(Usuario);
            if (Existe.Equals("1"))
            {
                return "El Usuario ya existe en la base de datos...";
            }
            else
            {
                UsuarioArrendatarioEntidad objArrendatarioE = new UsuarioArrendatarioEntidad();
                objArrendatarioE.usuario = Usuario;
                objArrendatarioE.Nombre = Nombre;
                objArrendatarioE.Apellido = Apellido;
                objArrendatarioE.Dni = Dni;
                objArrendatarioE.Email = Email;
                objArrendatarioE.Celular = Celular;
                objArrendatarioE.Direccion = Direccion;
                objArrendatarioE.contraseña = Contraseña;

                return objArrendatario.Insertar(objArrendatarioE);
            }
        }
    }
}