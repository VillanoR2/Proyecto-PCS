using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio
{
    public class Asignacion
    {
        public int Horas { get; set; }
        public EstadoServicio EstadoAsignado {get; set;}
        public Alumno AlumnoAsignado { get; set; }
        public Proyecto ProyctoAsignado { get; set; }
    }

    public enum EstadoServicio
    {
        Aprovado = 1,
        Rechazado = 0
    }
}
