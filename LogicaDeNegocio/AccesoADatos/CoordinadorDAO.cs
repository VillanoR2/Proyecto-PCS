using System.Collections.Generic;
using System.Data.SqlClient;
using BaseDatos;
using LogicaDeNegocio.AccesoADatos.Interfaces;
using LogicaDeNegocio.Excepciones;
using LogicaDeNegocio.Modelo;
using System;
using LogicaDeNegocio.Modelo.Emun;

namespace LogicaDeNegocio.AccesoADatos
{
    public class CoordinadorDAO : ICoordinadorDAO
    {

        public bool darBajaCoordinador(String matricula)
        {
            bool bajaCoordinador = false;
            ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();

            using (SqlConnection connection = conexionBaseDatos.GetConnection())
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();

                SqlTransaction transaction = connection.BeginTransaction("Transaccion");

                command.Connection = connection;

                command = new SqlCommand("delete from Coordinador where Matricula_Coordinador = '@matricula' ", connection);
                {
                    command.Transaction = transaction;
                    command.Parameters.Add(new SqlParameter("matricula", matricula));

                    try
                    {
                        command.ExecuteNonQuery();
                        bajaCoordinador = true;
                    }
                    catch (SqlException ex)
                    {
                        var excepcion = new LogicException(ex);
                        var error = excepcion.SqlErrorMessage();
                        if (error == ExcepcionesLogicas.ValorFueraDeRango)
                        {
                            transaction.Rollback();
                            bajaCoordinador = false;
                            throw new LogicException("Lo sentimos, se estan tratando de ingresar valores que exceden el límite de memoria", ex);
                        }
                        else
                        {
                            transaction.Rollback();
                            bajaCoordinador = false;
                            throw new LogicException("Lo sentimos. \nAlgo pasó que impide la conexión con la base de datos, \nesta siendo redireccionado a la pantalla anterior.", ex);

                        }

                    }

                    transaction.Commit();

                }
                conexionBaseDatos.CloseConnection();
            }
            return bajaCoordinador;
        }

        public List<Coordinador> mostrarCoordinadores()
        {
            List<Coordinador> coordinadores = new List<Coordinador>();

            ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();

            using (SqlConnection connection = conexionBaseDatos.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT Nombre,Apellidos,CorreoElectronico,Matricula_Coordinador,Contraseña,Carrera FROM Coordinador ", connection))
                {

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Coordinador coordinador = new Coordinador();
                        coordinador.Nombre = reader["Nombre"].ToString();
                        coordinador.Apellidos = reader["Apellidos"].ToString();
                        coordinador.CorreoElectronico = reader["CorreoElectronico"].ToString();
                        coordinador.NumPersonalCoordinador = reader["Matricula_Coordinador"].ToString();
                        coordinador.ContraseñaCoordinador = reader["Contraseña"].ToString();
                        coordinador.CarreraCoordinar = (Carrera)Enum.Parse(typeof(Carrera), reader["Carrera"].ToString());
                        coordinadores.Add(coordinador);
                    }

                }
                connection.Close();
            }
            return coordinadores;
        }

        public bool editarCoordinador(String matricula, String contraseña, String correo)
        {
            bool coordinadorActualizado = false;
            ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();

            using (SqlConnection connection = conexionBaseDatos.GetConnection())
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();

                SqlTransaction transaction = connection.BeginTransaction("Transaccion");

                command.Connection = connection;

                command = new SqlCommand("UPDATE Coordinador set CorreoElectronico = @correo , Contraseña = @contraseña where Matricula_Coordinador = @matricula ", connection);
                {
                    command.Transaction = transaction;
                    command.Parameters.Add(new SqlParameter("matricula", matricula));
                    command.Parameters.Add(new SqlParameter("correo", correo));
                    command.Parameters.Add(new SqlParameter("contraseña",contraseña));
                    try
                    {
                        command.ExecuteNonQuery();
                        coordinadorActualizado = true;
                    }
                    catch (SqlException ex)
                    {
                        var excepcion = new LogicException(ex);
                        var error = excepcion.SqlErrorMessage();
                        if (error == ExcepcionesLogicas.ValorFueraDeRango)
                        {
                            transaction.Rollback();
                            coordinadorActualizado = false;
                            throw new LogicException("Lo sentimos, se estan tratando de ingresar valores que exceden el límite de memoria", ex);
                        }
                        else
                        {
                            transaction.Rollback();
                            coordinadorActualizado = false;
                            throw new LogicException("Lo sentimos. \nAlgo pasó que impide la conexión con la base de datos, \nesta siendo redireccionado a la pantalla anterior.", ex);

                        }

                    }
                    transaction.Commit();
                }
                conexionBaseDatos.CloseConnection();
            }
            return coordinadorActualizado;
        }

        public bool registrarCoordinador(Coordinador coordinador)
        {
            bool coordinadorGuardado = false;


            ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();

            using (SqlConnection connection = conexionBaseDatos.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                SqlTransaction transaction = connection.BeginTransaction("Transaccion");

                command.Connection = connection;

                command = new SqlCommand("Insert into Coordinador(Matricula_Coordinador, Nombre, Apellidos, CorreoElectronico, Contraseña, Carrera) values(@matricula, @nombre, @apellido, @correo, @contraseña, @carrera)", connection);
                {
                    command.Transaction = transaction;
                    command.Parameters.Add(new SqlParameter("matricula", coordinador.NumPersonalCoordinador));
                    command.Parameters.Add(new SqlParameter("nombre", coordinador.Nombre));
                    command.Parameters.Add(new SqlParameter("apellido", coordinador.Apellidos));
                    command.Parameters.Add(new SqlParameter("correo", coordinador.CorreoElectronico));
                    command.Parameters.Add(new SqlParameter("contraseña", coordinador.ContraseñaCoordinador));
                    command.Parameters.Add(new SqlParameter("carrera", coordinador.CarreraCoordinar.ToString()));

                    try
                    {
                        command.ExecuteNonQuery();
                        transaction.Commit();
                        coordinadorGuardado = true;
                    }
                    catch (SqlException ex)
                    {
                        var excepcion = new LogicException(ex);
                        var error = excepcion.SqlErrorMessage();
                        if (error == ExcepcionesLogicas.LlaveDuplicada)
                        {
                            transaction.Rollback();
                            coordinadorGuardado = false;
                            throw new LogicException("La matricula ingresada ya fue previamente asignada", ExcepcionesLogicas.LlaveDuplicada);
                        }
                        else if (error == ExcepcionesLogicas.ValorFueraDeRango)
                        {
                            transaction.Rollback();
                            coordinadorGuardado = false;
                            throw new LogicException("Lo sentimos, se estan tratando de ingresar valores que exceden el limite de memoria.", ExcepcionesLogicas.ValorFueraDeRango);
                        }
                        else
                        {
                            transaction.Rollback();
                            coordinadorGuardado = false;
                            throw new LogicException("Lo sentimos. \nAlgo paso que impide la conexión con la base de datos, \nesta siendo redireccionado a la pantalla anterior.", ExcepcionesLogicas.FallaGeneral);
                        }
                    }

                    
                }
                conexionBaseDatos.CloseConnection();
            }

            return coordinadorGuardado;
        }

        public bool getIdCoordinador(String id)
        {
            bool idObtenido = false;
            ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();

            using (SqlConnection connection = conexionBaseDatos.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT Matricula_Coordinador FROM Coordinador WHERE Matricula_Coordinador = @id", connection))
                {
                    command.Parameters.Add(new SqlParameter("id", id));
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Coordinador coordinador = new Coordinador(); ;
                        coordinador.NumPersonalCoordinador = reader["Matricula_Coordinador"].ToString();
                        idObtenido = true;
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return idObtenido;
        }
    }
}
