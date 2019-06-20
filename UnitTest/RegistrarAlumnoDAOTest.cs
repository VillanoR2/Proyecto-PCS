using System;
using LogicaDeNegocio.AccesoADatos;
using LogicaDeNegocio.Modelo;
using LogicaDeNegocio.Modelo.Emun;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class PruebaRegistrarInformacion

    {
        [TestMethod]
        public void PruebaRegistrarAlumnoValido()
        {
            Alumno alumno = new Alumno(); 
            AlumnoDAO metodo = new AlumnoDAO();
            bool resultadoEsperado = true;
            bool resultadoObtenido;

            alumno.Matricula = "S17012942";
            alumno.Nombre = "Franco";
            alumno.Apellidos = "Hernandez Martinez";
            alumno.CorreoElectronico = "zs170129@estudiantes.uv.mx";
            alumno.CarreraAlumno = Carrera.IngenieriaDeSoftware;
            alumno.ContraseñaAlumno = "Trigov2";
            
            resultadoObtenido=metodo.registrarAlumno(alumno);

            Assert.AreEqual(resultadoEsperado, resultadoObtenido, "Prueba agregar estudiante válido");

        }


        [TestMethod]
        public void PruebaRegistrarAlumnoValido2()
        {
            Alumno alumno = new Alumno();
            AlumnoDAO metodo = new AlumnoDAO();
            bool resultadoEsperado = true;
            bool resultadoObtenido;

            alumno.Matricula = "S17012941";
            alumno.Nombre = "Arturo";
            alumno.Apellidos = "Villa Hernández";
            alumno.CorreoElectronico = "zs17012946@estudiantes.uv.mx";
            alumno.CarreraAlumno = Carrera.IngenieriaDeSoftware;
            alumno.ContraseñaAlumno = "Trigoverde1";

            resultadoObtenido = metodo.registrarAlumno(alumno);

            Assert.AreEqual(resultadoEsperado, resultadoObtenido, "Prueba agregar estudiante válido");

        }

        [TestMethod]
        public void PruebaRegistrarAlumnoNoValido()
        {
            Alumno alumno = new Alumno();
            AlumnoDAO metodo = new AlumnoDAO();
            bool resultadoEsperado = false;
            bool resultadoObtenido = true;

            alumno.Matricula = "S17012900000";
            alumno.Nombre = "Regina";
            alumno.Apellidos = "Saavedra";
            alumno.CorreoElectronico = "zs17012923@estudiantes.uv.mx";
            alumno.CarreraAlumno = Carrera.IngenieriaDeSoftware;
            alumno.ContraseñaAlumno = "calitom";


            resultadoObtenido = metodo.registrarAlumno(alumno);

            Assert.AreEqual(resultadoEsperado, resultadoObtenido, "Matricula excede los valores permitidos");

        }

        [TestMethod]
        public void PruebaRegistrarAlumnoLlavePrimaria()
        {
            Alumno alumno = new Alumno();
            AlumnoDAO metodo = new AlumnoDAO();
            bool resultadoEsperado = false;
            bool resultadoObtenido;

            alumno.Matricula = "S17012946";
            alumno.Nombre = "Juan";
            alumno.Apellidos = "Hernandez";
            alumno.CorreoElectronico = "zs17012943@estudiantes.uv.mx";
            alumno.CarreraAlumno = Carrera.IngenieriaDeSoftware;
            alumno.ContraseñaAlumno = "juan123";

            resultadoObtenido = metodo.registrarAlumno(alumno);

            Assert.AreEqual(resultadoEsperado, resultadoObtenido, "Llave primaria repetida");

        }

        [TestMethod]
        public void PruebaRegistrarAlumnoLlavePrimariaVacia()
        {
            Alumno alumno = new Alumno();
            AlumnoDAO metodo = new AlumnoDAO();
            bool resultadoEsperado = false;
            bool resultadoObtenido;

            alumno.Matricula = null;
            alumno.Nombre = "Ana";
            alumno.Apellidos = "Hernandez";
            alumno.CorreoElectronico = "zs17012930@estudiantes.uv.mx";
            alumno.CarreraAlumno = Carrera.IngenieriaDeSoftware;
            alumno.ContraseñaAlumno = "ana123";

            resultadoObtenido = metodo.registrarAlumno(alumno);

            Assert.AreEqual(resultadoEsperado, resultadoObtenido, "Llave primaria vacía");

        }


    }
}
