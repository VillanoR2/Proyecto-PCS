using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio
{
    interface IAsignacionDAO
    {
        int actualizarHoras(Asignacion Horas);

        void cambiarEstadoServicio(Asignacion Estado);
    }
}
