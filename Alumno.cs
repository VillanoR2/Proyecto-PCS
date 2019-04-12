using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio
{
     public class Alumno : Persona
    {
      private String ContraseñaAlumno { get; set; }
      private String Matricula { get; set; }
      private int NumHoras { get; set; }
      private Carrera CarreraAlumno { get; set; }
      
    }

    enum Carrera
    {
        IngenieriaSoftware = 1,
        TecnologiasComputacionales = 2,
        RedesServiciosComputacionales = 3
    }
}
