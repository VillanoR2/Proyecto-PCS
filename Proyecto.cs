using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio
{
     public class Proyecto
    {
        private int MaxAlumno { get; set; }
        private int Vacantes { get; set; }
        private String Horario { get; set; } 
        private String NombreProyecto { get; set; }
        private EstadoProyecto EstadoP { get; set; }
        private Institucion Pertenecea { get; set; }

    }

    enum EstadoProyecto
    {
        Asignado = 1,
        EnEspera = 0
    }
}
