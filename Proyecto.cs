using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio
{
     public class Proyecto
    {
        public String IdProyecto { get; set; }
        public int MaxAlumno { get; set; }
        public int Vacantes { get; set; }
        public String Horario { get; set; } 
        public String NombreProyecto { get; set; }
        public EstadoProyecto EstadoP { get; set; }
        public String Pertenecea { get; set; }

    }

    public enum EstadoProyecto
    {
        Asignado = 1,
        EnEspera = 0
    }

}

