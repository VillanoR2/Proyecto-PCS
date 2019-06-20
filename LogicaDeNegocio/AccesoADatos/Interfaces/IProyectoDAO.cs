using LogicaDeNegocio.Modelo;
using System;
using System.Collections.Generic;

namespace LogicaDeNegocio.AccesoADatos.Interfaces
{
    interface IProyectoDAO
    {
        bool registrarProyeto(Proyecto proyecto);

        bool calcularVacanates(String proyecto);

        void cambiarEstadoProyecto(Proyecto EstadoProyecto);

        void calcularHoras(Proyecto Horas);

        List<Proyecto> mostrarProyectos();

        bool getIdProyecto(String proyecto);
    }
}
