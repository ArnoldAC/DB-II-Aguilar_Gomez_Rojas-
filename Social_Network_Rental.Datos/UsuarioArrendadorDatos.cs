using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Social_Network_Rental.Entidad;
using System.Data;
using System.Data.SqlClient;

namespace Social_Network_Rental.Datos
{
    class UsuarioArrendadorDatos
    {

        public DataTable Loguear(string Usuario, string Password)
        {
            SqlDataReader resultado;
            DataTable Tabla = new DataTable();
            SqlConnection sqlCnx = new SqlConnection();

            try
            {
                //Establecer conexion
                sqlCnx = Conexion.getInstancia().EstablecerConexion();
                //Llamar al procedimiento almacenado
                SqlCommand comando = new SqlCommand("USP_Usuario_Loguear", sqlCnx);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@pusuario", SqlDbType.VarChar).Value = Usuario;
                comando.Parameters.Add("@pclave", SqlDbType.VarChar).Value = Password;

                sqlCnx.Open();
                resultado = comando.ExecuteReader();
                Tabla.Load(resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlCnx.State == ConnectionState.Open) sqlCnx.Close();
            }
        }
    }
}
