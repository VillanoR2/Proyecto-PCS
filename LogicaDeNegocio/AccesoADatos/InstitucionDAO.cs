using System.Data.SqlClient;
using LogicaDeNegocio.AccesoADatos.Interfaces;
using LogicaDeNegocio.Modelo;
using BaseDatos;
using LogicaDeNegocio.Excepciones;
using System;

namespace LogicaDeNegocio.AccesoADatos
{
     public class InstitucionDAO : IInstitucionDAO
    {
        public bool registrarInstitucion(Institucion institucion)
        {
            bool institucionGuardado = false;

            ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();

            using (SqlConnection connection = conexionBaseDatos.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                SqlTransaction transaction = connection.BeginTransaction("Transaccion");

                command.Connection = connection;

                command = new SqlCommand("Insert into Institucion(Nombre, Direccion, TipoInstitucion, Telefono) values(@nombre, @direccion, @tipo, @telefono)", connection);
                {
                    command.Transaction = transaction;

                    command.Parameters.Add(new SqlParameter("nombre", institucion.NombreInstitucion));
                    command.Parameters.Add(new SqlParameter("direccion", institucion.Direccion));
                    command.Parameters.Add(new SqlParameter("tipo", institucion.TipoInstitucion));
                    command.Parameters.Add(new SqlParameter("telefono", institucion.TelefonoInstitucion));
    
                    try
                    {
                        command.ExecuteNonQuery();
                        institucionGuardado = true;
                    }
                    catch (SqlException ex)
                    {
                        var excepcion = new LogicException(ex);
                        var error = excepcion.SqlErrorMessage();
                        if (error == ExcepcionesLogicas.LlaveDuplicada)
                        {
                            transaction.Rollback();
                            institucionGuardado = false;
                            throw new LogicException("La matricula ingresada ya fue previamente asignada", ExcepcionesLogicas.LlaveDuplicada);
                        }
                        else if (error == ExcepcionesLogicas.ValorFueraDeRango)
                        {
                            transaction.Rollback();
                            institucionGuardado = false;
                            throw new LogicException("Lo sentimos, se estan tratando de ingresar valores que exceden el limite de memoria.", ExcepcionesLogicas.ValorFueraDeRango);
                        }
                        else
                        {
                            transaction.Rollback();
                            institucionGuardado = false;
                            throw new LogicException("Lo sentimos. \nAlgo paso que impide la conexión con la base de datos, \nesta siendo redireccionado a la pantalla anterior.", ExcepcionesLogicas.FallaGeneral);
                        }
                    }

                    transaction.Commit();
                }
                conexionBaseDatos.CloseConnection();
            }

            return institucionGuardado;
        }

        public bool getNombreInsitucion(String nombre)
        {
            bool nombreObtenido = false;

            ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();

            using (SqlConnection connection = conexionBaseDatos.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT Nombre FROM Institucion WHERE Nombre = @nombre", connection))
                {
                    command.Parameters.Add(new SqlParameter("nombre", nombre));
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Institucion institucion = new Institucion();
                        institucion.NombreInstitucion = reader["Nombre"].ToString();
                        nombreObtenido = true;
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return nombreObtenido;
        }

    }
}
