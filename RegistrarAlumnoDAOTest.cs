using System;
using LogicaDeNegocio;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class PruebaRegistrarInformacion

    {
        [TestMethod]
        public void PruebaRegistrarAlumno()
        {
           Alumno alumno = new Alumno(); 
            AlumnoDAO metodo = new AlumnoDAO();
            bool resultadoEsperado = true;
            bool resultadoObtenido = false;

            alumno.Matricula = "S17012946";
            alumno.Nombre = "Arturo";
            alumno.Apellido = "Villa Lopez";
            alumno.CorreoElectronico = "zs17012946@estudiantes.uv.mx";
            alumno.CarreraAlumno = 0;
            alumno.ContraseñaAlumno = "Trigoverde2";
            alumno.FechaNacimiento = "1999-06-19";
        
            resultadoObtenido=metodo.registrarAlumno(alumno);

            Assert.AreEqual(resultadoEsperado, resultadoObtenido, "Prueba agregar estudiante válido");

        }
        
        [TestMethod]
        public void PruebaRegistrarAlumnoNoValido()
        {
           Alumno alumno = new Alumno(); 
            AlumnoDAO metodo = new AlumnoDAO();
            bool resultadoEsperado = true;
            bool resultadoObtenido = false;

            alumno.Matricula = "S17012900000";
            alumno.Nombre = "Regina";
            alumno.Apellido = "Saavedra";
            alumno.CorreoElectronico = "zs17012923@estudiantes.uv.mx";
            alumno.CarreraAlumno = 0;
            alumno.ContraseñaAlumno = "calitom";
            alumno.FechaNacimiento = "1998-11-08";
        
            resultadoObtenido=metodo.registrarAlumno(alumno);

            Assert.AreEqual(resultadoEsperado, resultadoObtenido, "Matricula excede los valores permitidos");

        }
        
        [TestMethod]
        public void PruebaRegistrarAlumnoLlavePrimaria()
        {
           Alumno alumno = new Alumno(); 
            AlumnoDAO metodo = new AlumnoDAO();
            bool resultadoEsperado = true;
            bool resultadoObtenido = false;

            alumno.Matricula = "S17012946";
            alumno.Nombre = "Juan";
            alumno.Apellido = "Hernandez";
            alumno.CorreoElectronico = "zs17012943@estudiantes.uv.mx";
            alumno.CarreraAlumno = 0;
            alumno.ContraseñaAlumno = "juan123";
            alumno.FechaNacimiento = "1998-10-09";
        
            resultadoObtenido=metodo.registrarAlumno(alumno);

            Assert.AreEqual(resultadoEsperado, resultadoObtenido, "Llave primaria repetida");

        }
        
        [TestMethod]
          public void PruebaRegistrarAlumnoLlavePrimaria()
        {
           Alumno alumno = new Alumno(); 
            AlumnoDAO metodo = new AlumnoDAO();
            bool resultadoEsperado = true;
            bool resultadoObtenido = false;

            alumno.Matricula = "";
            alumno.Nombre = "Ana";
            alumno.Apellido = "Hernandez";
            alumno.CorreoElectronico = "zs17012930@estudiantes.uv.mx";
            alumno.CarreraAlumno = 0;
            alumno.ContraseñaAlumno = "ana123";
            alumno.FechaNacimiento = "1998-09-09";
        
            resultadoObtenido=metodo.registrarAlumno(alumno);

            Assert.AreEqual(resultadoEsperado, resultadoObtenido, "Llave primaria vacía");

        }
        
                [TestMethod]
        public void PruebaRegistrarAlumnoCamposVacios()
        {
            Alumno alumno = new Alumno();
            AlumnoDAO metodo = new AlumnoDAO();
            bool resultadoEsperado = true;
            bool resultadoObtenido = false;

            alumno.Matricula = null;
            alumno.Nombre = null;
            alumno.Apellido = null;
            alumno.CorreoElectronico = null;
            alumno.ContraseñaAlumno = null;
            alumno.FechaNacimiento = null;

            resultadoObtenido = metodo.registrarAlumno(alumno);

            Assert.AreEqual(resultadoEsperado, resultadoObtenido, "Prueba agregar estudiante con campos vacios");

        }
        
        [TestMethod]
        public void PruebaRegistrarCoordinador()
        {
           Coordinador coordinador = new Coordinador(); 
            DirectorDAO metodo = new DirectorDAO();
            bool resultadoEsperado = true;
            bool resultadoObtenido = false;
            
            coordinador.Nombre = "Ángel Juán";
            coordinador.Apellido = "Sánchez García";
            coordinador.CorreoElectronico = "angel@gmail.com";
            coordinador.ContraseñaCoordinador = "angel123";
            coordinador.FechaNacimiento = "1989-07-18";
            coordinador.Carrera = 0;
            coordinador.NumPersonal = "01";
        
            resultadoObtenido=metodo.registrarCoordinador(coordinador);

            Assert.AreEqual(resultadoEsperado, resultadoObtenido, "Prueba agregar coordinador válido");

        }
        
        [TestMethod]
        public void PruebaRegistrarCoordinador()
        {
           Coordinador coordinador = new Coordinador(); 
            DirectorDAO metodo = new DirectorDAO();
            bool resultadoEsperado = true;
            bool resultadoObtenido = false;
            
            coordinador.Nombre = "Ángel Juán";
            coordinador.Apellido = "Sánchez García";
            coordinador.CorreoElectronico = "angel@gmail.com";
            coordinador.ContraseñaCoordinador = "angel123";
            coordinador.FechaNacimiento = "1989-07-18";
            coordinador.Carrera = 1;
            coordinador.NumPersonal = "01";
        
            resultadoObtenido=metodo.registrarCoordinador(coordinador);

            Assert.AreEqual(resultadoEsperado, resultadoObtenido, "Llave primaria repetida");

        }
        
        [TestMethod]
         public void PruebaRegistrarCoordinador()
        {
           Coordinador coordinador = new Coordinador(); 
            DirectorDAO metodo = new DirectorDAO();
            bool resultadoEsperado = true;
            bool resultadoObtenido = false;
            
            coordinador.Nombre = "Ángel Juán";
            coordinador.Apellido = "Sánchez García";
            coordinador.CorreoElectronico = "angel@gmail.com";
            coordinador.ContraseñaCoordinador = "angel123";
            coordinador.FechaNacimiento = "1989-07-18";
            coordinador.Carrera = 1;
            coordinador.NumPersonal = " ";
        
            resultadoObtenido=metodo.registrarCoordinador(coordinador);

            Assert.AreEqual(resultadoEsperado, resultadoObtenido, "Llave primaria vacía");

        }
        
        [TestMethod]
        public void PruebaRegistrarInstitución()
        {
            Institución institución = new Institución(); 
            CoordinadorDAO metodo = new CoordinadorDAO();
            bool resultadoEsperado = true;
            bool resultadoObtenido = false;
            
           institucion.IdInstitucion = "001";
           institucion.NombreInstitucion = "FEI";
           institucion.Direccion = "avenida Xalapa esq. Avila camacho";
           institucion.TelefonoInstitucion = "2288900000";
           institucion.TipoInstitucion = "Universidad";
        
            resultadoObtenido=metodo.registrarInstitución(institución);

            Assert.AreEqual(resultadoEsperado, resultadoObtenido, "Prueba agregar institución válida");

        }
        
        [TestMethod]
        public void PruebaRegistrarInstitución()
        {
            Institución institución = new Institución(); 
            CoordinadorDAO metodo = new CoordinadorDAO();
            bool resultadoEsperado = true;
            bool resultadoObtenido = false;
            
           institucion.IdInstitucion = "001";
           institucion.NombreInstitucion = "CFE";
           institucion.Direccion = "Allende col. Centro";
           institucion.TelefonoInstitucion = "2288911180";
           institucion.TipoInstitucion = "Oficina de servicios";
        
            resultadoObtenido=metodo.registrarInstitución(institución);

            Assert.AreEqual(resultadoEsperado, resultadoObtenido, "Llave primaria repetida");

        }
        
        [TestMethod]
        public void PruebaRegistrarInstitución()
        {
            Institución institución = new Institución(); 
            CoordinadorDAO metodo = new CoordinadorDAO();
            bool resultadoEsperado = true;
            bool resultadoObtenido = false;
            
           institucion.IdInstitucion = "";
           institucion.NombreInstitucion = "Gobierno Municipal";
           institucion.Direccion = "Enriquez col. Centro";
           institucion.TelefonoInstitucion = "2288922180";
           institucion.TipoInstitucion = "Oficina de gobierno";
        
            resultadoObtenido=metodo.registrarInstitución(institución);

            Assert.AreEqual(resultadoEsperado, resultadoObtenido, "Llave primaria vacía");

        }
        
        [TestMethod]
        public void PruebaRegistrarTécnico()
        {
           Técnico tecnico = new Tecnico(); 
            CoordinadorDAO metodo = new CoordinadorDAO();
            bool resultadoEsperado = true;
            bool resultadoObtenido = false;
            
            tecnico.Nombre = "Martha ";
            tecnico.Apellido = "Cuevas";
            tecnico.CorreoElectronico = "martha@gmail.com";
            tecnico.Contraseña = "martha123";
            tecnico.FechaNacimiento = "1985-07-16";
            tecnico.Carrera = 0;
            tecnico.NumPersonal_Tecnico = "01";
           tecnico.Auxiliaa = "01"
            resultadoObtenido=metodo.registrarTecnico(tecnico);

            Assert.AreEqual(resultadoEsperado, resultadoObtenido, "Prueba agregar técnico válido");

        }
        
        [TestMethod]
        public void PruebaRegistrarTécnico()
        {
           Técnico tecnico = new Tecnico(); 
            CoordinadorDAO metodo = new CoordinadorDAO();
            bool resultadoEsperado = true;
            bool resultadoObtenido = false;
            tecnico.Nombre = "Mariana";
            tecnico.Apellido = "Gomez";
            tecnico.CorreoElectronico = "mariana@gmail.com";
            tecnico.Contraseña = "mariana123";
            tecnico.FechaNacimiento = "1987-04-26";
            tecnico.Carrera = 0;
            tecnico.NumPersonal_Tecnico = 01;
           tecnico.Auxiliaa = "01"
            resultadoObtenido=metodo.registrarTecnico(tecnico);

            Assert.AreEqual(resultadoEsperado, resultadoObtenido, "Prueba agregar técnico con llave primaria repetida");

        }
    }
}
