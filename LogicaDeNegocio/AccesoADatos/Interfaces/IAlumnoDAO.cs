using LogicaDeNegocio.Modelo;
using System.Collections.Generic;
using System;
using LogicaDeNegocio.Modelo.Emun;

namespace LogicaDeNegocio.AccesoADatos.Interfaces
{
    interface IAlumnoDAO
    {
        bool registrarAlumno(Alumno alumno);

        bool editarAlumno(String matricula, String contraseña, String correo);

        List<Alumno> mostrarAlumnosAvance(Carrera carrera);

        List<Alumno> mostrarAlumnosSolicitud();


    }
}
