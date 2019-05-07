using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using System.Data.SqlClient;

namespace LogicaDeNegocio
{
    class CoordinadorDAO : ICoordinadorDAO
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
                    command.Parameters.Add(new SqlParameter("fecha",documento.FechaEntrega));
                    command.Parameters.Add(new SqlParameter("id", documento.IdDocumento));
                    fechaGuardada = true;
                }
                conexionBaseDatos.CloseConnection();
            }

            return fechaGuardada;
        }

        public bool registrarEncargado(Encargado encargado)
        {
            bool encargadoGuardado = false;
            ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();
            using (SqlConnection connection = conexionBaseDatos.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("Insert into Encargado(ID_Encargado, Nombre_Encargado, Apellido_Encargado, Correo_Encargado, FechaNacimiento, ID_Proyecto, ID_Institucion) values(@idencargado,@nombre,@apellido,@correo,@fecha,@proyecto,@institucion)", connection))
                {

                    command.Parameters.Add(new SqlParameter("idencargado", encargado.IdEncargado));
                    command.Parameters.Add(new SqlParameter("nombre", encargado.Nombre));
                    command.Parameters.Add(new SqlParameter("apellido", encargado.Apellido));
                    command.Parameters.Add(new SqlParameter("correo", encargado.CorreoElectronico));
                    command.Parameters.Add(new SqlParameter("fecha", encargado.FechaNacimiento));
                    command.Parameters.Add(new SqlParameter("proyecto", encargado.Dirigea));
                    command.Parameters.Add(new SqlParameter("institucion", encargado.Pertenecea));
                    encargadoGuardado = true;
                }
                conexionBaseDatos.CloseConnection();
            }

            return encargadoGuardado;
        }

        public bool registrarInstitucion(Institucion institucion)
        {
            bool institucionGuardado = false;
            ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();
            using (SqlConnection connection = conexionBaseDatos.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("Insert into Institucion(ID_Institucion,Nombre_Institucion,Direccion_Institucion,Telefono,Tipo_Institucion) values(@idinstitucion,@nombre,@direccion,@telefono,@tipo)", connection))
                {

                    command.Parameters.Add(new SqlParameter("idinstitucion", institucion.IdInstitucion));
                    command.Parameters.Add(new SqlParameter("nombre", institucion.NombreInstitucion));
                    command.Parameters.Add(new SqlParameter("direccion", institucion.Direccion));
                    command.Parameters.Add(new SqlParameter("telefono", institucion.TelefonoInstitucion));
                    command.Parameters.Add(new SqlParameter("tipo", institucion.TipoInstitucion));
                    institucionGuardado = true;
                }
                conexionBaseDatos.CloseConnection();
            }

            return institucionGuardado;
        }

        public bool registrarProyeto(Proyecto proyecto)
        {
            bool proyectoGuardado = false;
            ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();
            using (SqlConnection connection = conexionBaseDatos.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("Insert into Proyecto_SS(ID_Proyecto, Horario_Proyecto, Nombre_Proyecto, ID_Institucion, MaxAlumnos, Vacantes, Estado) values(@idproyecto,@horario,@nombre,@idinstitucion,@maxalumnos,@vacantes,@estado)", connection))
                {

                    command.Parameters.Add(new SqlParameter("idproyecto", proyecto.IdProyecto));
                    command.Parameters.Add(new SqlParameter("horario", proyecto.Horario));
                    command.Parameters.Add(new SqlParameter("nombre", proyecto.NombreProyecto));
                    command.Parameters.Add(new SqlParameter("idinstitucion", proyecto.Pertenecea));
                    command.Parameters.Add(new SqlParameter("maxalumnos", proyecto.MaxAlumno));
                    command.Parameters.Add(new SqlParameter("vacantes", proyecto.Vacantes));
                    command.Parameters.Add(new SqlParameter("estado", proyecto.EstadoP));
                    proyectoGuardado = true;
                }
                conexionBaseDatos.CloseConnection();
            }

            return proyectoGuardado;
        }

        public bool registrarTecnico(TecnicoAcademico tecnico)
        {
            bool tecnicoGuardado = false;
            ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();
            using (SqlConnection connection = conexionBaseDatos.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("Insert into TecnicoAcad_SS(Nombre_Técnico, Apellido_Técnico, Correo, FechaNacimiento, Contraseña, Matricula,Matricula_Coordinador) values(@nombre, @apellido, @correo, @fechanacimiento, @contraseña, @matricula, @matriculacoordinador)", connection))
                {

                    command.Parameters.Add(new SqlParameter("nombre", tecnico.Nombre));
                    command.Parameters.Add(new SqlParameter("apellido", tecnico.Apellido));
                    command.Parameters.Add(new SqlParameter("correo", tecnico.CorreoElectronico));
                    command.Parameters.Add(new SqlParameter("fechanacimiento", tecnico.FechaNacimiento));
                    command.Parameters.Add(new SqlParameter("contraseña", tecnico.ContraseñaTecnico));
                    command.Parameters.Add(new SqlParameter("matricula", tecnico.NumPersonal_Tecnico));
                    command.Parameters.Add(new SqlParameter("matriculacoordinador", tecnico.Auxuliaa));
                    tecnicoGuardado = true;
                }
                conexionBaseDatos.CloseConnection();
            }

            return tecnicoGuardado;
        }
    }
}
