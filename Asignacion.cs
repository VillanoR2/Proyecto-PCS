using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio
{
    public class Asignacion
    {
        private int Horas { get; set; }
        private EstadoServicio EstadoAsignado {get; set;}
        private Alumno AlumnoAsignado { get; set; }
        private Proyecto ProyctoAsignado { get; set; }
    }

    enum EstadoServicio
    {
        Aprovado = 1,
        Rechazado = 0
    }
}
