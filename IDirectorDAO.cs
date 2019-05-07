using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio
{
    interface IDirectorDAO
    {
        bool registrarCoordinador(Coordinador coordinador);

        bool darBajaCoordinador(Coordinador coordinador);
    }
}
