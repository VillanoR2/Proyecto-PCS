using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;

namespace LogicaDeNegocio
{
    public class AlumnoDAO : IAlumnoDAO
    {
        public bool registrarAlumno(Alumno alumno)
        {
            bool alumnoGuardado = false;
            ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();
            using (SqlConnection connection = conexionBaseDatos.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("Insert into Alumno_SS(Matricula_Alumno, Nombre_Alumno, Apellidos_Alumno, Correo_Alumno, FechaNacimiento, Contraseña_Alumno, Carrera) values(@matricula, @nombre, @apellido, @correo, @fechanacimiento, @contraseña, @carrera)", connection))
                {

                    command.Parameters.Add(new SqlParameter("matricula", alumno.Matricula));
                    command.Parameters.Add(new SqlParameter("nombre", alumno.Nombre));
                    command.Parameters.Add(new SqlParameter("apellido", alumno.Apellido));
                    command.Parameters.Add(new SqlParameter("correo", alumno.CorreoElectronico));
                    command.Parameters.Add(new SqlParameter("fechanac", alumno.FechaNacimiento));
                    command.Parameters.Add(new SqlParameter("contraseña", alumno.ContraseñaAlumno));
                    command.Parameters.Add(new SqlParameter("carrera",alumno.CarreraAlumno));
                    alumnoGuardado = true;
                }
                conexionBaseDatos.CloseConnection();
            }

            return alumnoGuardado;
        }
    }
}
