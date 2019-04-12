using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio
{
    public class Encargado : Persona
    {
        private Institucion Pertenecea { get; set; }
        private Proyecto Dirigea { get; set; }
    }
}
