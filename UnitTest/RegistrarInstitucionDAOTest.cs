using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicaDeNegocio.Modelo;
using LogicaDeNegocio.AccesoADatos;

namespace UnitTest
{
    [TestClass]
    public class RegistrarInstitucionDAOTest
    {
        [TestMethod]
        public void PruebaRegistrarInstitucionValida()
        {
            Institucion institucion = new Institucion();
            InstitucionDAO institucionDAO = new InstitucionDAO();
            bool resultadoEsperado = true;
            bool resultadoObtenido;

            institucion.NombreInstitucion = "Facultad de Economia";
            institucion.Direccion = "Avenida Xalapa esquina Avila Camacho";
            institucion.TelefonoInstitucion = "2288189870";
            institucion.TipoInstitucion = "Universidad";

            resultadoObtenido = institucionDAO.registrarInstitucion(institucion);

            Assert.AreEqual(resultadoEsperado, resultadoObtenido, "Prueba registrar institución válida");
        }

        [TestMethod]
        public void PruebaRegistrarInstitucionCamposVacios ()
        {
            Institucion institucion = new Institucion();
            InstitucionDAO institucionDAO = new InstitucionDAO();
            bool resultadoEsperado = true;
            bool resultadoObtenido;

            institucion.NombreInstitucion = null;
            institucion.Direccion = null;
            institucion.TelefonoInstitucion = null;
            institucion.TipoInstitucion = null;

            resultadoObtenido = institucionDAO.registrarInstitucion(institucion);

            Assert.AreEqual(resultadoEsperado, resultadoObtenido, "Prueba registrar institución con campos vacíos");
        }

        [TestMethod]
        public void PruebaRegistrarInstitucionRepetida()
        {
            Institucion institucion = new Institucion();
            InstitucionDAO institucionDAO = new InstitucionDAO();
            bool resultadoEsperado = true;
            bool resultadoObtenido;

            institucion.NombreInstitucion = "Facultad de estadística e informática";
            institucion.Direccion = "Avenida Xalapa esquina Avila Camacho";
            institucion.TelefonoInstitucion = "2288189870";
            institucion.TipoInstitucion = "Universidad";

            resultadoObtenido = institucionDAO.registrarInstitucion(institucion);

            Assert.AreEqual(resultadoEsperado, resultadoObtenido, "Prueba registrar institución repetida");
        }


    }
}
