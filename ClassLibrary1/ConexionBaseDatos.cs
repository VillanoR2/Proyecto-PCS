using System;
using System.Data.SqlClient;
using System.Configuration;

namespace BaseDatos
{
    public class ConexionBaseDatos
    {
        private SqlConnection conexionServicioSocialBD;

        private String connectionString;

        public ConexionBaseDatos()
        {

                connectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;

                conexionServicioSocialBD = new SqlConnection(connectionString);
                
        }

        public SqlConnection GetConnection()
        {
            return conexionServicioSocialBD;
        }

        public void CloseConnection()
        {
            if (conexionServicioSocialBD != null)
            {
                if (conexionServicioSocialBD.State == System.Data.ConnectionState.Open)
                {
                    conexionServicioSocialBD.Close();
                }
            }
        }
    }
}
