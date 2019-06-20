using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicaDeNegocio.Modelo.Emun;
using LogicaDeNegocio.Modelo;
using LogicaDeNegocio.AccesoADatos;


namespace UnitTest
{
    [TestClass]
    public class RegistrarCoordinadorDAOTest
    {

        [TestMethod]
        public void PruebaRegistrarCoordinadorValido()
        {
            Coordinador coordinador = new Coordinador();
            CoordinadorDAO metodo = new CoordinadorDAO();
            bool resultadoEsperado = true;
            bool resultadoObtenido;

            coordinador.NumPersonalCoordinador = "C19060910";
            coordinador.Nombre = "Alfredp";
            coordinador.Apellidos = "Hernandez Martinez";
            coordinador.CorreoElectronico = "alfehdz@uv.mx";
            coordinador.CarreraCoordinar = Carrera.TecnologiasComputacionales;
            coordinador.ContraseñaCoordinador = "alfedo12";

            resultadoObtenido = metodo.registrarCoordinador(coordinador);

            Assert.AreEqual(resultadoEsperado, resultadoObtenido, "Prueba registrar coordinador válido");

        }

        [TestMethod]
        public void PruebaRegistrarCoordinadorMatriculaErronea()
        {
            Coordinador coordinador = new Coordinador();
            CoordinadorDAO metodo = new CoordinadorDAO();
            bool resultadoEsperado = false;
            bool resultadoObtenido;

            coordinador.NumPersonalCoordinador = "C1906091245678987654";
            coordinador.Nombre = "Alfredp";
            coordinador.Apellidos = "Hernandez Martinez";
            coordinador.CorreoElectronico = "alfehdz@uv.mx";
            coordinador.CarreraCoordinar = Carrera.TecnologiasComputacionales;
            coordinador.ContraseñaCoordinador = "alfedo12";

            resultadoObtenido = metodo.registrarCoordinador(coordinador);

            Assert.AreEqual(resultadoEsperado, resultadoObtenido, "Prueba registrar coordinador válido");

        }

        [TestMethod]
        public void PruebaRegistrarCoordinadorMatriculaRepetida()
        {
            Coordinador coordinador = new Coordinador();
            CoordinadorDAO metodo = new CoordinadorDAO();
            bool resultadoEsperado = false;
            bool resultadoObtenido;

            coordinador.NumPersonalCoordinador = "C19060912";
            coordinador.Nombre = "Alfredo";
            coordinador.Apellidos = "Hernandez Martinez";
            coordinador.CorreoElectronico = "alfehdz@uv.mx";
            coordinador.CarreraCoordinar = Carrera.TecnologiasComputacionales;
            coordinador.ContraseñaCoordinador = "alfedo12";

            resultadoObtenido = metodo.registrarCoordinador(coordinador);

            Assert.AreEqual(resultadoEsperado, resultadoObtenido, "Prueba registrar coordinador válido");

        }

        [TestMethod]
        public void PruebaRegistrarCoordinadorVacio()
        {
            Coordinador coordinador = new Coordinador();
            CoordinadorDAO metodo = new CoordinadorDAO();
            bool resultadoEsperado = false;
            bool resultadoObtenido;

            coordinador.NumPersonalCoordinador = null;
            coordinador.Nombre = null;
            coordinador.Apellidos = null;
            coordinador.CorreoElectronico = null;
            coordinador.CarreraCoordinar = Carrera.TecnologiasComputacionales;
            coordinador.ContraseñaCoordinador = null;

            resultadoObtenido = metodo.registrarCoordinador(coordinador);

            Assert.AreEqual(resultadoEsperado, resultadoObtenido, "Prueba registrar coordinador campos vacíos");

        }

    }
}
