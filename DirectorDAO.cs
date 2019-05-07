using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using System.Data.SqlClient;

namespace LogicaDeNegocio
{
    class DirectorDAO : IDirectorDAO

    {
        public bool darBajaCoordinador(Coordinador coordinador)
        {
            bool bajaCoordinador = false;
            ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();
            using (SqlConnection connection = conexionBaseDatos.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("delete from Coordinador_SS where Matricula_Coordinador = '@matricula' ", connection))
                {
                    command.Parameters.Add(new SqlParameter("matricula", coordinador.NumPersonalCoordinador));
                    command.ExecuteNonQuery();
                    bajaCoordinador = true;
                }
                conexionBaseDatos.CloseConnection();
            }
            return bajaCoordinador;
        }

        public bool registrarCoordinador(Coordinador coordinador)
        {
            bool coordinadorGuardado = false;
            ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();
            using (SqlConnection connection = conexionBaseDatos.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("Insert into Coordinador_SS(Matricula_Coordinador, Nombre_Coordinador, Apellidos_Coordinador, Correo_Coordinador, Contraseña, Fecha_Nacimiento, Carrera) values(@matricula, @nombre, @apellido, @correo, @contraseña, @fechanacimiento, @carrera)", connection))
                {

                    command.Parameters.Add(new SqlParameter("matricula", coordinador.NumPersonalCoordinador));
                    command.Parameters.Add(new SqlParameter("nombre", coordinador.Nombre));
                    command.Parameters.Add(new SqlParameter("apellido", coordinador.Apellido));
                    command.Parameters.Add(new SqlParameter("correo", coordinador.CorreoElectronico));
                    command.Parameters.Add(new SqlParameter("contraseña", coordinador.ContraseñaCoordinador));
                    command.Parameters.Add(new SqlParameter("fechanacimiento", coordinador.FechaNacimiento));
                    command.Parameters.Add(new SqlParameter("carrera", coordinador.Carrera));
                   
                    coordinadorGuardado = true;
                }
                conexionBaseDatos.CloseConnection();
            }

            return coordinadorGuardado;
        }
    }
}
