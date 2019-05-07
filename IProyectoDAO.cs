using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio
{
    interface IProyectoDAO
    {
        void asignarAlumno(Alumno Alumno);

        void calcularVacanates();

        void cambiarEstadoProyecto(Proyecto EstadoProyecto);

        void darBajaAlumno(Alumno alumno);

        void calcularHoras(Proyecto Horas);
    }
}
