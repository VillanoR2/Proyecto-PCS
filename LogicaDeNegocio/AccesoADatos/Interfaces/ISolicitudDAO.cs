using LogicaDeNegocio.Modelo;
using LogicaDeNegocio.Modelo.Emun;
using System;
using System.Collections.Generic;

namespace LogicaDeNegocio.AccesoADatos.Interfaces
{
    interface ISolicitudDAO
    {
        bool cambiarEstadoSolicitud(String matricula, EstadoSolicitud estado);

        bool realizarSolicitud(String Alumno);

        bool asignarProyectos(String proyecto1, String proyecto2, String proyecto3, String id);

        EstadoSolicitud obtenerEstado(String Alumno);

        EstadoSolicitud obtenerEstadoEspera();

        List<Solicitud> mostrarSolicitudes();
    }
}
