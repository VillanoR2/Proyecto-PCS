using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Configuration;

namespace AccesoDatos
{
    public class BaseDatosConexion
    {
        private SqlConnection bdServicioConexion;
        private String conexionString;


        public BaseDatosConexion()
        {
            conexionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
            bdServicioConexion = new SqlConnection(conexionString);
        }

        public SqlConnection GetConexion()
        {
            return bdServicioConexion;
        }

        public void CloseConexion()
        {
            if (bdServicioConexion != null)
            {
                if (bdServicioConexion.State == System.Data.ConnectionState.Open)
                {
                    bdServicioConexion.Close();
                }
            }
        }
    }
}
