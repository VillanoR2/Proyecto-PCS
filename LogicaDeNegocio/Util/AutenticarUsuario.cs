using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseDatos;
using System.Data.SqlClient;
namespace LogicaDeNegocio.Util
{
    public enum ResultadoAutenticacion
    {
        UsuarioInexistente,
        Alumno,
        Coordinador,
        Director,
        Tecnico
    }
    public class AutenticarUsuario
    {
        public ResultadoAutenticacion resultadoAutenticacion(String Usuario, String Contraseña)
        {
            ResultadoAutenticacion resultadoAutenticacion = ResultadoAutenticacion.UsuarioInexistente;

            ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();

            using (SqlConnection connection = conexionBaseDatos.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT NumPersonal FROM Director WHERE NumPersonal = @usuario and Contraseña = @contraseña", connection))
                {
                    command.Parameters.Add(new SqlParameter("@usuario", Usuario));
                    command.Parameters.Add(new SqlParameter("@contraseña", Contraseña));

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Usuario = reader["NumPersonal"].ToString();
                        resultadoAutenticacion = ResultadoAutenticacion.Director;
                    }

                    reader.Close();
                    connection.Close();
                }
            }

            ConexionBaseDatos conexionBaseDatos2 = new ConexionBaseDatos();

            using (SqlConnection connection = conexionBaseDatos2.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT Matricula FROM Alumno WHERE Matricula = @usuario and Contraseña = @contraseña", connection))
                {
                    command.Parameters.Add(new SqlParameter("@usuario", Usuario));
                    command.Parameters.Add(new SqlParameter("@contraseña", Contraseña));

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Usuario = reader["Matricula"].ToString();
                        resultadoAutenticacion = ResultadoAutenticacion.Alumno;
                    }

                    reader.Close();
                    connection.Close();
                }
            }

            ConexionBaseDatos conexionBaseDatos3 = new ConexionBaseDatos();

            using (SqlConnection connection = conexionBaseDatos3.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT Matricula_Coordinador FROM Coordinador WHERE Matricula_Coordinador = @usuario and Contraseña = @contraseña", connection))
                {
                    command.Parameters.Add(new SqlParameter("@usuario", Usuario));
                    command.Parameters.Add(new SqlParameter("@contraseña", Contraseña));

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Usuario = reader["Matricula_Coordinador"].ToString();
                        resultadoAutenticacion = ResultadoAutenticacion.Coordinador;
                    }

                    reader.Close();
                    connection.Close();
                }
            }

            ConexionBaseDatos conexionBaseDatos4 = new ConexionBaseDatos();

            using (SqlConnection connection = conexionBaseDatos4.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT Matricula_Tecnico FROM TecnicoAcad WHERE Matricula_Tecnico = @usuario and Contraseña = @contraseña", connection))
                {
                    command.Parameters.Add(new SqlParameter("@usuario", Usuario));
                    command.Parameters.Add(new SqlParameter("@contraseña", Contraseña));

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Usuario = reader["Matricula_Tecnico"].ToString();
                        resultadoAutenticacion = ResultadoAutenticacion.Tecnico;
                    }

                    reader.Close();
                    connection.Close();
                }
            }


            return resultadoAutenticacion;
        }
    }

}

