using System;
using System.Data.SqlClient;
using BaseDatos;
using LogicaDeNegocio.Modelo;
using LogicaDeNegocio.AccesoADatos.Interfaces;
using LogicaDeNegocio.Excepciones;
using System.Collections.Generic;
using LogicaDeNegocio.Modelo.Emun;
using System.Data;

namespace LogicaDeNegocio.AccesoADatos

    {
    public class AlumnoDAO : IAlumnoDAO
    {

        public List<Alumno> mostrarAlumnosAvance(Carrera carrera)
        {
            List<Alumno> alumnos = new List<Alumno>();
        
            ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();

            using (SqlConnection connection = conexionBaseDatos.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT Matricula,Nombres,Apellidos,Carrera,CorreoElectronico FROM Alumno WHERE Carrera = @carrera ",connection))
                {
                    command.Parameters.Add(new SqlParameter("carrera", carrera.ToString()));
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Alumno alumno = new Alumno();
                        alumno.Matricula = reader["Matricula"].ToString();
                        alumno.Nombre = reader["Nombres"].ToString();
                        alumno.Apellidos = reader["Apellidos"].ToString();
                        alumno.CarreraAlumno = (Carrera)Enum.Parse(typeof(Carrera), reader["Carrera"].ToString());
                        alumno.CorreoElectronico = reader["CorreoElectronico"].ToString();
                        alumnos.Add(alumno);
                    }
                    
                }
                    connection.Close();
            }
            return alumnos;
        }

        public List<Alumno> mostrarAlumnosSolicitud()
        {
            List<Alumno> alumnos = new List<Alumno>();

            var estado = EstadoSolicitud.EnEspera;

            ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();

            using (SqlConnection connection = conexionBaseDatos.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT Matricula, Nombres, Apellidos, EstadoSolicitud FROM Alumno,Solicitud WHERE Alumno.Matricula = Solicitud.Matricula_Alumno AND EstadoSolicitud = @estado;", connection))
                {
                    command.Parameters.Add(new SqlParameter("estado", estado.ToString()));

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Alumno alumno = new Alumno();
                        alumno.Matricula = reader["Matricula"].ToString();
                        alumno.Nombre = reader["Nombres"].ToString();
                        alumno.Apellidos = reader["Apellidos"].ToString();
                        alumno.Estado = (EstadoSolicitud)Enum.Parse(typeof(EstadoSolicitud), reader["EstadoSolicitud"].ToString());
                        
                        alumnos.Add(alumno);
                    }

                }
                connection.Close();
            }
            return alumnos;
        }

        public bool registrarAlumno(Alumno alumno)
        {
            bool alumnoGuardado = false;


            ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();

            using (SqlConnection connection = conexionBaseDatos.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                SqlTransaction transaction = connection.BeginTransaction("Transaccion");

                command.Connection = connection;

                command = new SqlCommand("Insert into Alumno(Matricula, Nombres, Apellidos, CorreoElectronico, Contraseña, Carrera) values(@matricula, @nombre, @apellido, @correo, @contraseña, @carrera)", connection);
                {
                    command.Transaction = transaction;
                    command.Parameters.Add(new SqlParameter("matricula", alumno.Matricula));
                    command.Parameters.Add(new SqlParameter("nombre", alumno.Nombre));
                    command.Parameters.Add(new SqlParameter("apellido", alumno.Apellidos));
                    command.Parameters.Add(new SqlParameter("correo", alumno.CorreoElectronico));
                    command.Parameters.Add(new SqlParameter("contraseña", alumno.ContraseñaAlumno));
                    command.Parameters.Add(new SqlParameter("carrera", alumno.CarreraAlumno.ToString()));
          
                    
                    try
                    {
                        command.ExecuteNonQuery();
                        alumnoGuardado = true;
                    }
                    catch (SqlException ex)
                    {
                        
                        var excepcion = new LogicException(ex);
                        var error = excepcion.SqlErrorMessage();
                        if (error == ExcepcionesLogicas.LlaveDuplicada)
                        {
                            transaction.Rollback();
                            alumnoGuardado = false;
                            throw new LogicException("La matricula ingresada ya fue previamente asignada", ex);
                        }
                        else if (error == ExcepcionesLogicas.ValorFueraDeRango)
                        {
                            transaction.Rollback();
                            alumnoGuardado = false;
                            throw new LogicException("Lo sentimos, se estan tratando de ingresar valores que exceden el limite de memoria.", ex);
                        }
                        else
                        {
                            transaction.Rollback();
                            alumnoGuardado = false;
                            throw new LogicException("Lo sentimos. \nAlgo paso que impide la conexión con la base de datos, \nesta siendo redireccionado a la pantalla anterior.", ex);
                        }
                    }

                        transaction.Commit();
                }
                conexionBaseDatos.CloseConnection();
            }

            return alumnoGuardado;
        }

        public bool editarAlumno(String matricula, String contraseña, String correo)
        {
            bool alumnoActualizado = false;
            ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();

            using (SqlConnection connection = conexionBaseDatos.GetConnection())
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();

                SqlTransaction transaction = connection.BeginTransaction("Transaccion");

                command.Connection = connection;

                command = new SqlCommand("UPDATE Alumno set CorreoElectronico = @correo , Contraseña = @contraseña where Matricula = @matricula ", connection);
                {
                    command.Transaction = transaction;
                    command.Parameters.Add(new SqlParameter("matricula", matricula));
                    command.Parameters.Add(new SqlParameter("correo", correo));
                    command.Parameters.Add(new SqlParameter("contraseña", contraseña));
                    try
                    {
                        command.ExecuteNonQuery();
                        alumnoActualizado = true;
                    }
                    catch (SqlException ex)
                    {
                        var excepcion = new LogicException(ex);
                        var error = excepcion.SqlErrorMessage();
                        if (error == ExcepcionesLogicas.ValorFueraDeRango)
                        {
                            transaction.Rollback();
                            alumnoActualizado = false;
                            throw new LogicException("Lo sentimos, se estan tratando de ingresar valores que exceden el límite de memoria", ex);
                        }
                        else
                        {
                            transaction.Rollback();
                            alumnoActualizado = false;
                            throw new LogicException("Lo sentimos. \nAlgo pasó que impide la conexión con la base de datos, \nesta siendo redireccionado a la pantalla anterior.", ex);

                        }

                    }
                    transaction.Commit();
                }
                conexionBaseDatos.CloseConnection();
            }
            return alumnoActualizado;
        }

        public Carrera obtenerCarrera(Carrera carrera)
        {
            Carrera carreraActual = Carrera.IngenieriaDeSoftware;
           
            ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();

            Alumno alumno = new Alumno();
           
            using (SqlConnection connection = conexionBaseDatos.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT Carrera FROM Alumno WHERE Carrera = @carrera", connection))
                {
                    command.Parameters.Add(new SqlParameter("@carrera",carrera.ToString()));

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        alumno.CarreraAlumno = (Carrera)Enum.Parse(typeof(Carrera), reader["Carrera"].ToString());

                    }

                    if (alumno.CarreraAlumno == Carrera.IngenieriaDeSoftware)
                    {
                        carreraActual = Carrera.IngenieriaDeSoftware;
                    }
                    else if (alumno.CarreraAlumno == Carrera.RedesyServiciosDeComputo)
                    {
                        carreraActual = Carrera.RedesyServiciosDeComputo;
                    }
                    else
                    {
                        carreraActual = Carrera.TecnologiasComputacionales;
                    }

                }
                connection.Close();

            }
            return carreraActual;
        }

    }
}
