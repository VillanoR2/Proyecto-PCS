﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio
{
    interface ISolicitudDAO
    {
        void cambiarEstadoSolicitud(Solicitud EstadoSolicitud);
    }
}
