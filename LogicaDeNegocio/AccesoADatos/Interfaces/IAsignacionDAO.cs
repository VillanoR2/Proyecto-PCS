using LogicaDeNegocio.Modelo;
using LogicaDeNegocio.Modelo.Emun;
using System;

namespace LogicaDeNegocio.AccesoADatos.Interfaces
{
    interface IAsignacionDAO
    {
        int actualizarHoras(int Horas);

        bool cambiarEstadoBaja();

        bool realizarAsignacion(String id, String proyecto, EstadoServicio estado);

        EstadoServicio obtenerEstado(String Alumno);
    }
}
