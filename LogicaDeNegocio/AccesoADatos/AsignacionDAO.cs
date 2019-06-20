using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BaseDatos;
using LogicaDeNegocio.AccesoADatos.Interfaces;
using LogicaDeNegocio.Excepciones;
using LogicaDeNegocio.Modelo;
using LogicaDeNegocio.Modelo.Emun;

namespace LogicaDeNegocio.AccesoADatos
{
    public class AsignacionDAO : IAsignacionDAO
    {
        public int actualizarHoras(int Horas)
        {
            throw new NotImplementedException();
        }

        public bool cambiarEstadoBaja()
        {
            bool EditAlumno = false;
            Alumno alumno = new Alumno();
            ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();

            using (SqlConnection connection = conexionBaseDatos.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;

                transaction = connection.BeginTransaction("Transacción");

                command.Connection = connection;
                command.Transaction = transaction;

                command = new SqlCommand("update Asignacion set EstadoServicio = 'De Baja' where Matricula = @matricula", connection);
                {
                    command.Parameters.Add(new SqlParameter("matricula", alumno.Matricula));
                    try
                    {
                        command.ExecuteNonQuery();
                        EditAlumno = true;
                    }

                    catch (SqlException ex)
                    {
                        var excepcion = new LogicException(ex);
                        var error = excepcion.SqlErrorMessage();
                        transaction.Rollback();
                        throw new LogicException("Algo paso que impide la conexión con la base de datos.", error);

                    }

                    transaction.Commit();
                }
                conexionBaseDatos.CloseConnection();
            }

            return EditAlumno;
        }

        public EstadoServicio obtenerEstado(String Alumno)
        {
            EstadoServicio estadoActual = EstadoServicio.Espera;

            ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();

            Asignacion solicitud = new Asignacion();

            using (SqlConnection connection = conexionBaseDatos.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT EstadoServicio FROM Asignacion WHERE Matricula = @matricula", connection))
                {
                    command.Parameters.Add(new SqlParameter("matricula", Alumno));

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        solicitud.EstadoAsignado = (EstadoServicio)Enum.Parse(typeof(EstadoServicio), reader["EstadoServicio"].ToString());

                    }

                    if (solicitud.EstadoAsignado == EstadoServicio.Aceptado)
                    {
                        estadoActual = EstadoServicio.Aceptado;
                    }
                    else if (solicitud.EstadoAsignado == EstadoServicio.Rechazado)
                    {
                        estadoActual = EstadoServicio.Rechazado;
                    }
                    else
                    {
                        estadoActual = EstadoServicio.Baja;
                    }
                }
                connection.Close();

            }
            return estadoActual;
        }

        public bool realizarAsignacion(String id, String proyecto, EstadoServicio estado)
        {
            bool asignacionRealizada = false;

            int horas = 0;
            ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();

            using (SqlConnection connection = conexionBaseDatos.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                SqlTransaction transaction = connection.BeginTransaction("Transaccion");

                command.Connection = connection;

                command = new SqlCommand("Insert into Asignacion(ID_Proyecto, Matricula, Horas, EstadoServicio) values(@id, @matricula, @horas, @estado)", connection);
                {
                    command.Transaction = transaction;
                    command.Parameters.Add(new SqlParameter("id", proyecto));
                    command.Parameters.Add(new SqlParameter("matricula", id));
                    command.Parameters.Add(new SqlParameter("horas", horas));
                    command.Parameters.Add(new SqlParameter("estado", estado.ToString()));

                    try
                    {
                        command.ExecuteNonQuery();
                        asignacionRealizada = true;
                    }
                    catch (SqlException ex)
                    {

                        var excepcion = new LogicException(ex);
                        var error = excepcion.SqlErrorMessage();
                        if (error == ExcepcionesLogicas.LlaveDuplicada)
                        {
                            transaction.Rollback();
                            asignacionRealizada = false;
                            throw new LogicException("La matricula ingresada ya fue previamente asignada", ex);
                        }
                        else if (error == ExcepcionesLogicas.ValorFueraDeRango)
                        {
                            transaction.Rollback();
                            asignacionRealizada = false;
                            throw new LogicException("Lo sentimos, se estan tratando de ingresar valores que exceden el limite de memoria.", ex);
                        }
                        else
                        {
                            transaction.Rollback();
                            asignacionRealizada = false;
                            throw new LogicException("Lo sentimos. \nAlgo paso que impide la conexión con la base de datos, \nesta siendo redireccionado a la pantalla anterior.", ex);
                        }
                    }

                    transaction.Commit();
                }
                conexionBaseDatos.CloseConnection();
            }

            return asignacionRealizada;
        }

        
    }
}
