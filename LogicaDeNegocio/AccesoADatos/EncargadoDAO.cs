using BaseDatos;
using System.Data.SqlClient;
using LogicaDeNegocio.AccesoADatos.Interfaces;
using LogicaDeNegocio.Modelo;
using LogicaDeNegocio.Excepciones;
using System;

namespace LogicaDeNegocio.AccesoADatos
{
    public class EncargadoDAO : IEncargadoDAO
    {
        public bool registrarEncargado(Encargado encargado)
        {
            bool encargadoGuardado = false;

            ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();

            using (SqlConnection connection = conexionBaseDatos.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                SqlTransaction transaction = connection.BeginTransaction("Transaccion");

                command.Connection = connection;

                command = new SqlCommand("Insert into Encargado(ID_Encargado,Nombres, Apellidos, CorreoElectronico, Institucion) values(@id,@nombre, @apellido, @correo, @institucion)", connection);
                {
                    command.Transaction = transaction;

                    command.Parameters.Add(new SqlParameter("id", encargado.IdEncargado));
                    command.Parameters.Add(new SqlParameter("nombre", encargado.Nombre));
                    command.Parameters.Add(new SqlParameter("apellido", encargado.Apellidos));
                    command.Parameters.Add(new SqlParameter("correo", encargado.CorreoElectronico));
                    command.Parameters.Add(new SqlParameter("institucion", encargado.Pertenecea));

                    try
                    {
                        command.ExecuteNonQuery();
                        transaction.Commit();
                        encargadoGuardado = true;
                    }
                    catch (SqlException ex)
                    {
                        var excepcion = new LogicException(ex);
                        var error = excepcion.SqlErrorMessage();
                        if (error == ExcepcionesLogicas.LlaveDuplicada)
                        {
                            transaction.Rollback();
                            encargadoGuardado = false;
                            throw new LogicException("La matricula ingresada ya fue previamente asignada", ExcepcionesLogicas.LlaveDuplicada);
                        }
                        else if (error == ExcepcionesLogicas.ValorFueraDeRango)
                        {
                            transaction.Rollback();
                            encargadoGuardado = false;
                            throw new LogicException("Lo sentimos, se estan tratando de ingresar valores que exceden el limite de memoria.", ExcepcionesLogicas.ValorFueraDeRango);
                        }
                        else
                        {
                            transaction.Rollback();
                            encargadoGuardado = false;
                            throw new LogicException("Lo sentimos. \nAlgo paso que impide la conexión con la base de datos, \nesta siendo redireccionado a la pantalla anterior.", ExcepcionesLogicas.FallaGeneral);
                        }
                    }

                }
                conexionBaseDatos.CloseConnection();
            }

            return encargadoGuardado;
        }

        public bool getIdEncargado(String id)
        {
            bool idObtenida = false;

            ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();

            using (SqlConnection connection = conexionBaseDatos.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT ID_Encargado FROM Encargado WHERE ID_Encargado = @id", connection))
                {
                    command.Parameters.Add(new SqlParameter("id", id));
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Proyecto proyecto = new Proyecto();
                        proyecto.IdProyecto = reader["ID_Encargado"].ToString();
                        idObtenida = true;
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return idObtenida;
        }

    }
}
