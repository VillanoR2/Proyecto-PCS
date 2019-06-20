using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.AccesoADatos.Interfaces
{
    interface IDocumentoDAO
    {
        bool calendarizarDocumento(String ID, DateTime Fecha);

        bool getIdDocumento(String id);
    }
}
