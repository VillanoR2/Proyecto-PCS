using BaseDatos;
using LogicaDeNegocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaDeNegocio.Modelo;

namespace LogicaDeNegocio.AccesoADatos
{
    public class DocumentoDAO
    {
        public bool calendarizarDocumento(String ID, DateTime Fecha)
        {
            bool documentoCalendarizado = false;
            ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();

            using (SqlConnection connection = conexionBaseDatos.GetConnection())
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();

                SqlTransaction transaction = connection.BeginTransaction("Transaccion");

                command.Connection = connection;

                command = new SqlCommand("UPDATE Documento set FechaEntrega = @fecha where ID_Documento = @id", connection);
                {
                    command.Transaction = transaction;
                    command.Parameters.Add(new SqlParameter("id",ID));
                    command.Parameters.Add(new SqlParameter("fecha", Fecha));

                    try
                    {
                        command.ExecuteNonQuery();
                        documentoCalendarizado = true;
                    }
                    catch (SqlException ex)
                    {
                        var excepcion = new LogicException(ex);
                        var error = excepcion.SqlErrorMessage();
                        if (error == ExcepcionesLogicas.ValorFueraDeRango)
                        {
                            transaction.Rollback();
                            documentoCalendarizado = false;
                            throw new LogicException("Lo sentimos, se estan tratando de ingresar valores que exceden el límite de memoria", ex);
                        }
                        else
                        {
                            transaction.Rollback();
                            documentoCalendarizado = false;
                            throw new LogicException("Lo sentimos. \nAlgo pasó que impide la conexión con la base de datos, \nesta siendo redireccionado a la pantalla anterior.", ex);

                        }

                    }
                    transaction.Commit();
                }
                conexionBaseDatos.CloseConnection();
            }
            return documentoCalendarizado;
        }

        public bool getIdDocumento(String id)
        {
            bool idObtenida = false;

            ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();

            using (SqlConnection connection = conexionBaseDatos.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT ID_Documento FROM Documento WHERE ID_Documento = @id", connection))
                {
                    command.Parameters.Add(new SqlParameter("id", id));
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Documento documento = new Documento();
                        documento.IdDocumento = reader["ID_Documento"].ToString();
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
