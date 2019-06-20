using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaDeNegocio;
using LogicaDeNegocio.Modelo;
using LogicaDeNegocio.AccesoADatos;
namespace UnitTest
{
    [TestClass]
    public class RegistrarTecnicoDAOTest
    {
        [TestMethod]
        public void PruebaRegistrarTecnicoValido()
        {
            TecnicoAcademico tecnicoAcademico = new TecnicoAcademico();
            TecnicoDAO metodo = new TecnicoDAO();
            bool resultadoEsperado = true;
            bool resultadoObtenido;

            tecnicoAcademico.NumPersonal_Tecnico = "T123441";
            tecnicoAcademico.Nombre = "Martha";
            tecnicoAcademico.Apellidos = "Cuevas";
            tecnicoAcademico.ContraseñaTecnico = "Martha123";
            tecnicoAcademico.CorreoElectronico = "martha@gmail.com";
            tecnicoAcademico.AuxuliaA = "C13144";

            resultadoObtenido = metodo.registrarTecnico(tecnicoAcademico);

            Assert.AreEqual(resultadoEsperado, resultadoObtenido, "Prueba registrar técnico válido");

        }

        [TestMethod]
        public void PruebaRegistrarTecnicoNoValido()
        {
            TecnicoAcademico tecnicoAcademico = new TecnicoAcademico();
            TecnicoDAO metodo = new TecnicoDAO();
            bool resultadoEsperado = true;
            bool resultadoObtenido;

            tecnicoAcademico.NumPersonal_Tecnico = "";
            tecnicoAcademico.Nombre = "";
            tecnicoAcademico.Apellidos = "";
            tecnicoAcademico.ContraseñaTecnico = "";
            tecnicoAcademico.CorreoElectronico = "";
            tecnicoAcademico.AuxuliaA = "";

            resultadoObtenido = metodo.registrarTecnico(tecnicoAcademico);

            Assert.AreEqual(resultadoEsperado, resultadoObtenido, "Prueba registrar técnico con campos vacíos");

        }

        [TestMethod]
        public void PruebaRegistrarTecnicoLlaveRepetida()
        {
            TecnicoAcademico tecnicoAcademico = new TecnicoAcademico();
            TecnicoDAO metodo = new TecnicoDAO();
            bool resultadoEsperado = true;
            bool resultadoObtenido;

            tecnicoAcademico.NumPersonal_Tecnico = "T123455";
            tecnicoAcademico.Nombre = "Ana";
            tecnicoAcademico.Apellidos = "Perez";
            tecnicoAcademico.ContraseñaTecnico = "anaPR2";
            tecnicoAcademico.CorreoElectronico = "ana@uv.mx";
            tecnicoAcademico.AuxuliaA = "C13144";

            resultadoObtenido = metodo.registrarTecnico(tecnicoAcademico);

            Assert.AreEqual(resultadoEsperado, resultadoObtenido, "Prueba registrar técnico con llave repetida");

        }

        [TestMethod]
        public void PruebaRegistrarTecnicoCoordinadorNoExiste()
        {
            TecnicoAcademico tecnicoAcademico = new TecnicoAcademico();
            TecnicoDAO metodo = new TecnicoDAO();
            bool resultadoEsperado = true;
            bool resultadoObtenido;

            tecnicoAcademico.NumPersonal_Tecnico = "T123455";
            tecnicoAcademico.Nombre = "Ana";
            tecnicoAcademico.Apellidos = "Perez";
            tecnicoAcademico.ContraseñaTecnico = "anaPR2";
            tecnicoAcademico.CorreoElectronico = "ana@uv.mx";
            tecnicoAcademico.AuxuliaA = "C010000";

            resultadoObtenido = metodo.registrarTecnico(tecnicoAcademico);

            Assert.AreEqual(resultadoEsperado, resultadoObtenido, "Prueba registrar técnico con matricula de coordinador incorrecta");

        }
    }
}
