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
    }
}
