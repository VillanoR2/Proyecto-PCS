using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio
{
     public class Solicitud
    {
        private EstadoSolicitud EstadoDeSolicitud { get; set; }
        private Proyecto ProyectoSolicitado { get; set; }
        private Alumno SolicitadoPor { get; set; }


    }

    enum EstadoSolicitud
    {
        Aceptada = 1,
        Rechazada = 0
    }
}
