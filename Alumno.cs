using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio
{
     public class Alumno : Persona
    {
      public String ContraseñaAlumno { get; set; }
      public String Matricula { get; set; }
      public int NumHoras { get; set; }
      public Carrera CarreraAlumno { get; set; }
      
    }

    public enum Carrera
    {
        IngenieriaSoftware = 0,
        TecnologiasComputacionales = 1,
        RedesServiciosComputacionales = 2
    }
}
