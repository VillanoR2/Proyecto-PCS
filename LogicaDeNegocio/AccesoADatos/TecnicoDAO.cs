using BaseDatos;
using System.Data.SqlClient;
using LogicaDeNegocio.AccesoADatos.Interfaces;
using LogicaDeNegocio.Modelo;
using LogicaDeNegocio.Excepciones;
using System;
namespace LogicaDeNegocio.AccesoADatos
{
    public class TecnicoDAO : ITecnicoDAO
    {
        public bool darBajaTecnico(String matricula)
        {
            bool bajaTecnico = false;

            ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();

            using (SqlConnection connection = conexionBaseDatos.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                SqlTransaction transaction = connection.BeginTransaction("Transaccion");

                command.Connection = connection;

                command = new SqlCommand("delete from TecnicoAcad where Matricula_Tecnico = '@matricula' ", connection);
                {
                    command.Transaction = transaction;
                    command.Parameters.Add(new SqlParameter("matricula", matricula));

                    try
                    {
                        command.ExecuteNonQuery();
                        bajaTecnico = true;
                    }
                    catch (SqlException ex)
                    {
                        var excepcion = new LogicException(ex);
                        var error = excepcion.SqlErrorMessage();
                        if (error == ExcepcionesLogicas.ValorFueraDeRango)
                        {
                            transaction.Rollback();
                            bajaTecnico = false;
                            throw new LogicException("Lo sentimos, se estan tratando de ingresar valores que exceden el límite de memoria", ex);
                        }
                        else
                        {
                            transaction.Rollback();
                            bajaTecnico = false;
                            throw new LogicException("Lo sentimos. \nAlgo pasó que impide la conexión con la base de datos, \nesta siendo redireccionado a la pantalla anterior.", ex);
                        }

                    }

                    transaction.Commit();
                }
                connection.Close();
            }
            return bajaTecnico;
        }

        public bool registrarTecnico(TecnicoAcademico tecnico)
        {
            bool tecnicoGuardado = false;

            ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();

            using (SqlConnection connection = conexionBaseDatos.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                SqlTransaction transaction = connection.BeginTransaction("Transaccion");

                command.Connection = connection;

                command = new SqlCommand("Insert into TecnicoAcad(Matricula_Tecnico,Nombre, Apellido, CorreoElectronico, Contraseña, Matricula_Coordinador) values(@matricula,@nombre, @apellido, @correo, @contraseña,@coordinador)", connection);
                {
                    command.Transaction = transaction;

                    command.Parameters.Add(new SqlParameter("matricula", tecnico.NumPersonal_Tecnico));
                    command.Parameters.Add(new SqlParameter("nombre", tecnico.Nombre));
                    command.Parameters.Add(new SqlParameter("apellido", tecnico.Apellidos));
                    command.Parameters.Add(new SqlParameter("correo", tecnico.CorreoElectronico));
                    command.Parameters.Add(new SqlParameter("contraseña", tecnico.ContraseñaTecnico));
                    command.Parameters.Add(new SqlParameter("coordinador", tecnico.AuxuliaA));

                    try
                    {
                        command.ExecuteNonQuery();
                        transaction.Commit();
                        tecnicoGuardado = true;
                    }
                    catch (SqlException ex)
                    {
                        var excepcion = new LogicException(ex);
                        var error = excepcion.SqlErrorMessage();
                        if (error == ExcepcionesLogicas.LlaveDuplicada)
                        {
                            transaction.Rollback();
                            tecnicoGuardado = false;
                            throw new LogicException("La matricula ingresada ya fue previamente asignada", ExcepcionesLogicas.LlaveDuplicada);
                        }
                        else if (error == ExcepcionesLogicas.ValorFueraDeRango)
                        {
                            transaction.Rollback();
                            tecnicoGuardado = false;
                            throw new LogicException("Lo sentimos, se estan tratando de ingresar valores que exceden el limite de memoria.", ExcepcionesLogicas.ValorFueraDeRango);
                        }
                        else if (error == ExcepcionesLogicas.CampoVacio)
                        {
                            transaction.Rollback();
                            tecnicoGuardado = false;
                            throw new LogicException("Se han detectado datos faltantes. \nFavor de ingresar todos los datos.", ExcepcionesLogicas.CampoVacio);
                        }
                        else
                        {
                            transaction.Rollback();
                            tecnicoGuardado = false;
                            throw new LogicException("Lo sentimos. \nAlgo paso que impide la conexión con la base de datos, \nesta siendo redireccionado a la pantalla anterior.", ExcepcionesLogicas.FallaGeneral);
                        }
                    }

                }
                conexionBaseDatos.CloseConnection();
            }

            return tecnicoGuardado;
        }

        public bool editarTecnico(String matricula, String correo, String contraseña)
        {
            bool tecnicoActualizado = false;

            ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();

            using (SqlConnection connection = conexionBaseDatos.GetConnection())
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();

                SqlTransaction transaction = connection.BeginTransaction("Transaccion");

                command.Connection = connection;

                command = new SqlCommand("UPDATE TecnicoAcad set CorreoElectronico = @correo , Contraseña = @contraseña where Matricula_Tecnico = @matricula ", connection);
                {
                    command.Transaction = transaction;
                    command.Parameters.Add(new SqlParameter("matricula", matricula));
                    command.Parameters.Add(new SqlParameter("correo", correo));
                    command.Parameters.Add(new SqlParameter("contraseña", contraseña));
                    try
                    {
                        command.ExecuteNonQuery();
                        tecnicoActualizado = true;
                    }
                    catch (SqlException ex)
                    {
                        var excepcion = new LogicException(ex);
                        var error = excepcion.SqlErrorMessage();
                        if (error == ExcepcionesLogicas.ValorFueraDeRango)
                        {
                            transaction.Rollback();
                            tecnicoActualizado = false;
                            throw new LogicException("Lo sentimos, se estan tratando de ingresar valores que exceden el límite de memoria", ex);
                        }
                        else
                        {
                            transaction.Rollback();
                            tecnicoActualizado = false;
                            throw new LogicException("Lo sentimos. \nAlgo pasó que impide la conexión con la base de datos, \nesta siendo redireccionado a la pantalla anterior.", ex);

                        }

                    }
                    transaction.Commit();
                }
                conexionBaseDatos.CloseConnection();
            }
            return tecnicoActualizado;
        }
    }
}
