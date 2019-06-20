using System;
using BaseDatos;
using System.Data.SqlClient;
using LogicaDeNegocio.AccesoADatos.Interfaces;
using LogicaDeNegocio.Modelo;


namespace LogicaDeNegocio.AccesoADatos
{
    class ExpedienteDAO : IExpedienteDAO
    {
        public bool asignarFechaADocumento(Documento documento)
        {
            bool fechaGuardada = false;

            ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();
            using (SqlConnection connection = conexionBaseDatos.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("Update Documento set Fecha = @fecha where ID_Documento = @id;", connection))
                {
                    command.Parameters.Add(new SqlParameter("fecha", documento.FechaEntrega));
                    command.Parameters.Add(new SqlParameter("id", documento.IdDocumento));
                    fechaGuardada = true;
                }
                conexionBaseDatos.CloseConnection();
            }

            return fechaGuardada;
        }

        public bool editarFechaADocumento(Documento documento)
        {
            throw new NotImplementedException();
        }
    }
}
