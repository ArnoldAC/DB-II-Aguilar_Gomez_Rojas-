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
    public class UsuarioArrendatarioDatos
    {
        public string Existe(string Valor)
        {
            string Rpta = "";

            SqlConnection sqlConnection = new SqlConnection();

            try
            {
                //Establecer conexion
                sqlConnection = Conexion.getInstancia().EstablecerConexion();
                //Llamar al procedimiento almacenado
                SqlCommand comando = new SqlCommand("USP_Arrendatario_Verificar", sqlConnection);
                //Especificar el tipo de objeto
                comando.CommandType = CommandType.StoredProcedure;
                //Pasarle el parametro
                comando.Parameters.Add("@pvalor", SqlDbType.VarChar).Value = Valor;
                SqlParameter PExiste = new SqlParameter();
                PExiste.ParameterName = "@pexiste";
                PExiste.SqlDbType = SqlDbType.Int;
                PExiste.Direction = ParameterDirection.Output;
                sqlConnection.Open();

                Rpta = Convert.ToString(PExiste.Value);


            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open) sqlConnection.Close();
            }
            return Rpta;
        }
        public string Insertar(UsuarioArrendatarioEntidad objArrendatario)
        {
            string Rpta = "";
            SqlConnection sqlCnx = new SqlConnection();
            try
            {
                //Establecer conexion
                sqlCnx = Conexion.getInstancia().EstablecerConexion();
                //Llamar al procedimiento almacenado
                SqlCommand comando = new SqlCommand("USP_Arrendatario_I", sqlCnx);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@pCod_Usuario", SqlDbType.Int).Value = objArrendatario.Cod_Arrendatario;
                comando.Parameters.Add("@pNombre", SqlDbType.VarChar).Value = objArrendatario.Nombre;
                comando.Parameters.Add("@pApellido", SqlDbType.VarChar).Value = objArrendatario.Apellido;
                comando.Parameters.Add("@pDni", SqlDbType.Char).Value = objArrendatario.Dni;
                comando.Parameters.Add("@pEmail", SqlDbType.VarChar).Value = objArrendatario.Email;
                comando.Parameters.Add("@pDireccion", SqlDbType.VarChar).Value = objArrendatario.Direccion;
                comando.Parameters.Add("@pCelular", SqlDbType.Char).Value = objArrendatario.Celular;
                comando.Parameters.Add("@pusuario", SqlDbType.VarChar).Value = objArrendatario.usuario;
                comando.Parameters.Add("@pcontraseña", SqlDbType.VarChar).Value = objArrendatario.contraseña;
                comando.Parameters.Add("@pestado", SqlDbType.Char).Value = objArrendatario.estado;



                sqlCnx.Open();
                Rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo agregar el registro...";

            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (sqlCnx.State == ConnectionState.Open) sqlCnx.Close();
            }
            return Rpta;
        }

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
                SqlCommand comando = new SqlCommand("USP_Arrendatario_Auntentificar", sqlCnx);
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

