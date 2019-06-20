using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicaDeNegocio.Modelo;
using LogicaDeNegocio.AccesoADatos;

namespace UnitTest
{
    [TestClass]
    public class RegistrarEncargadoDAOTest
    {
        [TestMethod]
        public void RegistrarEncargadoValido()
        {
            Encargado encargado = new Encargado();
            EncargadoDAO encargadoDAO = new EncargadoDAO();
            bool resultadoEsperado = true;
            bool resultadoObtenido;

            encargado.Nombre = "Juan Carlos";
            encargado.Apellidos = "Perez Arriaga";
            encargado.IdEncargado = "E0001";
            encargado.CorreoElectronico = "elrevo@gmail.com";
            encargado.Pertenecea = "FEI";

            resultadoObtenido = encargadoDAO.registrarEncargado(encargado);

            Assert.AreEqual(resultadoEsperado, resultadoObtenido, "Prueba registrar encargado válido");
        }

        [TestMethod]
        public void RegistrarEncargadoRepetido()
        {
            Encargado encargado = new Encargado();
            EncargadoDAO encargadoDAO = new EncargadoDAO();
            bool resultadoEsperado = true;
            bool resultadoObtenido;

            encargado.Nombre = "Xavier";
            encargado.Apellidos = "Limón";
            encargado.IdEncargado = "E0001";
            encargado.CorreoElectronico = "xavier@gmail.com";
            encargado.Pertenecea = "Facultad de estadistica e informatica";

            resultadoObtenido = encargadoDAO.registrarEncargado(encargado);

            Assert.AreEqual(resultadoEsperado, resultadoObtenido, "Prueba registrar encargado repetido");
        }

        [TestMethod]
        public void RegistrarEncargadoCamposVacios()
        {
            Encargado encargado = new Encargado();
            EncargadoDAO encargadoDAO = new EncargadoDAO();
            bool resultadoEsperado = true;
            bool resultadoObtenido;

            encargado.Nombre = null;
            encargado.Apellidos = null;
            encargado.IdEncargado = null;
            encargado.CorreoElectronico = null;
            encargado.Pertenecea = null;

            resultadoObtenido = encargadoDAO.registrarEncargado(encargado);

            Assert.AreEqual(resultadoEsperado, resultadoObtenido, "Prueba registrar encargado válido");
        }
    }
}
