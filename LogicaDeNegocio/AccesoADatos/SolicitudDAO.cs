using System;
using System.Data.SqlClient;
using LogicaDeNegocio.AccesoADatos.Interfaces;
using LogicaDeNegocio.Modelo.Emun;
using LogicaDeNegocio.Modelo;
using BaseDatos;
using LogicaDeNegocio.Excepciones;
using System.Collections.Generic;

namespace LogicaDeNegocio.AccesoADatos
{
    public class SolicitudDAO : ISolicitudDAO
    {
        public bool asignarProyectos(String proyecto1, String proyecto2, String proyecto3, String id)
        {
            bool proyectosAsignados = false;

            ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();

            using (SqlConnection connection = conexionBaseDatos.GetConnection())
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();

                SqlTransaction transaction = connection.BeginTransaction("Transaccion");

                command.Connection = connection;

                command = new SqlCommand("UPDATE Solicitud SET Proyecto1 = @proyecto1, Proyecto2 = @proyecto2, Proyecto3 = @proyecto3 WHERE Matricula_Alumno = @matricula ", connection);
                {
                    command.Transaction = transaction;

                    command.Parameters.Add(new SqlParameter("matricula", id));

                    command.Parameters.Add(new SqlParameter("proyecto1", proyecto1));

                    command.Parameters.Add(new SqlParameter("proyecto2", proyecto2));

                    command.Parameters.Add(new SqlParameter("proyecto3", proyecto3));

                    try
                    {
                        command.ExecuteNonQuery();

                        transaction.Commit();

                        proyectosAsignados = true;

                    }
                    catch (SqlException ex)
                    {
                        var excepcion = new LogicException(ex);

                        var error = excepcion.SqlErrorMessage();

                        if (error == ExcepcionesLogicas.ValorFueraDeRango)
                        {
                            transaction.Rollback();

                            proyectosAsignados = false;

                            throw new LogicException("Lo sentimos, se estan tratando de ingresar valores que exceden el limite de memoria.", ExcepcionesLogicas.ValorFueraDeRango);
                        }
                        else
                        {
                            transaction.Rollback();
                            proyectosAsignados = false;
                            throw new LogicException("Lo sentimos. \nAlgo paso que impide la conexión con la base de datos, \nesta siendo redireccionado a la pantalla anterior.", ex);
                        }
                    }
                }
                conexionBaseDatos.CloseConnection();
            }

            return proyectosAsignados;
        }

        public bool cambiarEstadoSolicitud(String id,EstadoSolicitud estado)
        {
            bool estadoCambiado = false;

            ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();

            using (SqlConnection connection = conexionBaseDatos.GetConnection())
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();

                SqlTransaction transaction = connection.BeginTransaction("Transaccion");

                command.Connection = connection;

                command = new SqlCommand("UPDATE Solicitud SET EstadoSolicitud = @estado WHERE Matricula_Alumno = @matricula ", connection);
                {
                    command.Transaction = transaction;

                    command.Parameters.Add(new SqlParameter("matricula", id));

                    command.Parameters.Add(new SqlParameter("estado", estado.ToString()));

                    try
                    {
                        command.ExecuteNonQuery();

                        estadoCambiado = true;

                    }catch(SqlException ex)
                    {
                        var excepcion = new LogicException(ex);

                        var error = excepcion.SqlErrorMessage();

                      if (error == ExcepcionesLogicas.ValorFueraDeRango)
                        {
                            transaction.Rollback();

                            estadoCambiado = false;

                            throw new LogicException("Lo sentimos, se estan tratando de ingresar valores que exceden el limite de memoria.", ExcepcionesLogicas.ValorFueraDeRango);
                        }
                        else
                        {
                            transaction.Rollback();
                            estadoCambiado = false;
                            throw new LogicException("Lo sentimos. \nAlgo paso que impide la conexión con la base de datos, \nesta siendo redireccionado a la pantalla anterior.", ex);
                        }
                    }

                    transaction.Commit();
                }
                conexionBaseDatos.CloseConnection();
            }

            return estadoCambiado;
        }

        public List<Solicitud> mostrarSolicitudes()
        {
            List<Solicitud> solicitudes = new List<Solicitud>();

            var estado = EstadoSolicitud.Aceptada;

            ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();

            using (SqlConnection connection = conexionBaseDatos.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Solicitud WHERE EstadoSolicitud = @estado;", connection))
                {
                    command.Parameters.Add(new SqlParameter("estado", estado.ToString()));

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Solicitud solicitud = new Solicitud();
                      
                        solicitud.EstadoDeSolicitud = (EstadoSolicitud)Enum.Parse(typeof(EstadoSolicitud), reader["EstadoSolicitud"].ToString());
                        solicitud.SolicitadoPor = reader["Matricula_Alumno"].ToString();
                        solicitud.Proyecto1 = reader["Proyecto1"].ToString();
                        solicitud.Proyecto2 = reader["Proyecto2"].ToString();
                        solicitud.Proyecto3 = reader["Proyecto3"].ToString();
                        solicitudes.Add(solicitud);
                    }

                }
                connection.Close();
            }
            return solicitudes;
        }

        public EstadoSolicitud obtenerEstado(String Alumno)
        {
            EstadoSolicitud estadoActual = EstadoSolicitud.EnEspera;

            ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();

            Solicitud solicitud = new Solicitud();

            using (SqlConnection connection = conexionBaseDatos.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT EstadoSolicitud FROM Solicitud WHERE Matricula_Alumno = @matricula", connection))
                {
                    command.Parameters.Add(new SqlParameter("matricula", Alumno));

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        
                        solicitud.EstadoDeSolicitud = (EstadoSolicitud)Enum.Parse(typeof(EstadoSolicitud), reader["EstadoSolicitud"].ToString());

                    }

                    if(solicitud.EstadoDeSolicitud == EstadoSolicitud.Aceptada)
                    {
                        estadoActual = EstadoSolicitud.Aceptada;
                    }else if(solicitud.EstadoDeSolicitud == EstadoSolicitud.EnEspera)
                    {
                        estadoActual = EstadoSolicitud.EnEspera;
                    }
                    else
                    {
                        estadoActual = EstadoSolicitud.Rechazada;
                    }

                }
                connection.Close();

            }
                return estadoActual;
        }

        public EstadoSolicitud obtenerEstadoEspera()
        {
            EstadoSolicitud estadoActual = EstadoSolicitud.EnEspera;

            ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();

            using (SqlConnection connection = conexionBaseDatos.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT EstadoSolicitud FROM Solicitud ", connection))
                {

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        estadoActual = (EstadoSolicitud)Enum.Parse(typeof(EstadoSolicitud), reader["EstadoSolicitud"].ToString());

                    }

                }
                connection.Close();

            }
            return estadoActual;
        }

        public bool realizarSolicitud(String Alumno)
        {
            bool solicitudRealizada = false;

            Solicitud solicitud = new Solicitud();

            var estado = solicitud.EstadoDeSolicitud;

            estado = EstadoSolicitud.EnEspera;

            ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();

            using (SqlConnection connection = conexionBaseDatos.GetConnection())
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();

                SqlTransaction transaction = connection.BeginTransaction("Transaccion");

                command.Connection = connection;

                command = new SqlCommand("Insert into Solicitud(Matricula_Alumno,EstadoSolicitud) values(@id,@estado)", connection);
                {
                    command.Transaction = transaction;

                    command.Parameters.Add(new SqlParameter("id", Alumno));

                    command.Parameters.Add(new SqlParameter("estado", estado.ToString()));

                    try
                    {
                        command.ExecuteNonQuery();

                        solicitudRealizada = true;
                    }
                    catch (SqlException ex)
                    {
                        var excepcion = new LogicException(ex);

                        var error = excepcion.SqlErrorMessage();

                        if (error == ExcepcionesLogicas.LlaveDuplicada)
                        {
                            transaction.Rollback();

                            solicitudRealizada = false;

                            throw new LogicException("Lo sentimos, se estan tratando de ingresar una llave ya existente."+ex.Number,ExcepcionesLogicas.LlaveDuplicada);
                        }
                        else if (error == ExcepcionesLogicas.ValorFueraDeRango)
                        {
                            transaction.Rollback();

                            solicitudRealizada = false;

                            throw new LogicException("Lo sentimos, se estan tratando de ingresar valores que exceden el limite de memoria.", ExcepcionesLogicas.ValorFueraDeRango);
                        }
                        else
                        {
                            transaction.Rollback();

                            solicitudRealizada = false;

                            throw new LogicException("Lo sentimos. \nAlgo paso que impide la conexión con la base de datos, \nesta siendo redireccionado a la pantalla anterior.", ExcepcionesLogicas.FallaGeneral);
                        }
                    }

                    transaction.Commit();
                }
                conexionBaseDatos.CloseConnection();
            }

            return solicitudRealizada;
        }
    }
}
