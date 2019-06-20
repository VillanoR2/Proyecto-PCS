using System;
using BaseDatos;
using System.Data.SqlClient;
using LogicaDeNegocio.AccesoADatos.Interfaces;
using LogicaDeNegocio.Modelo;
using LogicaDeNegocio.Excepciones;
using LogicaDeNegocio.Modelo.Emun;
using System.Collections.Generic;

namespace LogicaDeNegocio.AccesoADatos
{
     public class ProyectoDAO : IProyectoDAO
    {
        public void calcularHoras(Proyecto Horas)
        {
            throw new NotImplementedException();
        }

        public bool calcularVacanates(String proyecto)
        {
            bool vacantesActualizados = false;

            Proyecto proyecto1 = new Proyecto();

            ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();

            using (SqlConnection connection = conexionBaseDatos.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT  MaxAlumnos, Vacantes, ID_Proyecto FROM Proyecto WHERE ID_Proyecto=@proyecto", connection))
                {
                    command.Parameters.Add(new SqlParameter("proyecto", proyecto));
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        
                        proyecto1.MaxAlumno = Convert.ToInt32(reader["MaxAlumnos"].ToString());
                        proyecto1.Vacantes = Convert.ToInt32(reader["Vacantes"].ToString());
                    }

                    
                }
                connection.Close();
            }

            proyecto1.Vacantes = proyecto1.MaxAlumno - 1;

            ConexionBaseDatos conexionBaseDatos2 = new ConexionBaseDatos();

            using (SqlConnection connection = conexionBaseDatos2.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("Update Proyecto SET Vacantes = @vacantes WHERE ID_Proyecto=@proyecto", connection))
                {
                    command.Parameters.Add(new SqlParameter("proyecto", proyecto));
                    command.Parameters.Add(new SqlParameter("vacantes", proyecto1.Vacantes));

                    command.ExecuteNonQuery();
                    vacantesActualizados = true;
                }
                connection.Close();
            }

            return vacantesActualizados;
        }

        public void cambiarEstadoProyecto(Proyecto EstadoProyecto)
        {
            throw new NotImplementedException();
        }

        public List<Proyecto> mostrarProyectos()
        {
            List<Proyecto> proyectos = new List<Proyecto>();
            ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();

            using (SqlConnection connection = conexionBaseDatos.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT  MaxAlumnos, Vacantes, ID_Proyecto, Nombre_Proyecto, ID_Institucion, Estado, Encargado FROM Proyecto ", connection))
                {

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Proyecto proyecto = new Proyecto();
                        proyecto.MaxAlumno = Convert.ToInt32(reader["MaxAlumnos"].ToString());
                        proyecto.Vacantes = Convert.ToInt32(reader["Vacantes"].ToString());
                        proyecto.IdProyecto = reader["ID_Proyecto"].ToString();
                        proyecto.NombreProyecto = reader["Nombre_Proyecto"].ToString();
                        proyecto.Pertenecea = reader["ID_Institucion"].ToString();
                        proyecto.EstadoP = (EstadoProyecto)Enum.Parse(typeof(EstadoProyecto), reader["Estado"].ToString());
                        proyecto.DirigidoPor = reader["Encargado"].ToString();
                        proyectos.Add(proyecto);
                    }
                }
                connection.Close();
            }
            return proyectos;
        }

        public bool registrarProyeto(Proyecto proyecto)
        {
            bool proyectoGuardado = false;

            ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();

            proyecto.EstadoP = EstadoProyecto.EnEspera;
            proyecto.Vacantes = proyecto.MaxAlumno;

            using (SqlConnection connection = conexionBaseDatos.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                SqlTransaction transaction = connection.BeginTransaction("Transaccion");

                command.Connection = connection;

                command = new SqlCommand("Insert into Proyecto(ID_Proyecto,Nombre_Proyecto, MaxAlumnos,Vacantes, Encargado, ID_Institucion,Estado) values(@id,@nombre, @maximo,@vacantes, @dirigido, @institucion,@estado)", connection);
                {
                    command.Transaction = transaction;

                    command.Parameters.Add(new SqlParameter("id", proyecto.IdProyecto));
                    command.Parameters.Add(new SqlParameter("nombre", proyecto.NombreProyecto));
                    command.Parameters.Add(new SqlParameter("maximo", proyecto.MaxAlumno));
                    command.Parameters.Add(new SqlParameter("vacantes", proyecto.Vacantes));
                    command.Parameters.Add(new SqlParameter("dirigido", proyecto.DirigidoPor));
                    command.Parameters.Add(new SqlParameter("institucion",proyecto.Pertenecea));
                    command.Parameters.Add(new SqlParameter("estado", proyecto.EstadoP.ToString()));

                    try
                    {
                        command.ExecuteNonQuery();
                        proyectoGuardado = true;
                    }
                    catch (SqlException ex)
                    {
                        var excepcion = new LogicException(ex);
                        var error = excepcion.SqlErrorMessage();
                        if (error == ExcepcionesLogicas.LlaveDuplicada)
                        {
                            transaction.Rollback();
                            proyectoGuardado = false;
                            throw new LogicException("La matricula ingresada ya fue previamente asignada", ExcepcionesLogicas.LlaveDuplicada);
                        }
                        else if (error == ExcepcionesLogicas.ValorFueraDeRango)
                        {
                            transaction.Rollback();
                            proyectoGuardado = false;
                            throw new LogicException("Lo sentimos, se estan tratando de ingresar valores que exceden el limite de memoria.", ExcepcionesLogicas.ValorFueraDeRango);
                        }
                        else
                        {
                            transaction.Rollback();
                            proyectoGuardado = false;
                            throw new LogicException("Lo sentimos. \nAlgo paso que impide la conexión con la base de datos, \nesta siendo redireccionado a la pantalla anterior.", ExcepcionesLogicas.FallaGeneral);
                        }
                    }

                    transaction.Commit();
                }
                conexionBaseDatos.CloseConnection();
            }

            return proyectoGuardado;
        }

        public bool getIdProyecto(String id)
        {
            bool idObtenida = false;

            ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();

            using (SqlConnection connection = conexionBaseDatos.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT ID_Proyecto FROM Proyecto WHERE ID_Proyecto = @id", connection))
                {
                    command.Parameters.Add(new SqlParameter("id",id));
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Proyecto proyecto = new Proyecto();
                        proyecto.IdProyecto = reader["ID_Proyecto"].ToString();
                        idObtenida = true;
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return idObtenida;
        }

        public void obtenerDatos(String matricula)
        {
            ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();

            using (SqlConnection connection = conexionBaseDatos.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT Nombre_Proyecto, Direccion, TipoInstitucion,Nombres,CorreoElectronico FROM Institucion,Encargado,Proyecto WHERE  ", connection))
                {

                }
            }

        }
    }
}
