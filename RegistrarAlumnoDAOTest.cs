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
        
        
    }
}
