using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio
{
     public class TecnicoAcademico : Persona
    {
        public String ContraseñaTecnico { get; set; }
        public int NumPersonal_Tecnico {get; set;}
        public Coordinador Auxuliaa { get; set; }

    }
}
