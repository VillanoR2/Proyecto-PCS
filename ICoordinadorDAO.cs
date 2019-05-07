using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio
{
    interface ICoordinadorDAO
    {
        bool registrarTecnico(TecnicoAcademico tecnico);

        bool registrarProyeto(Proyecto proyecto);

        bool registrarInstitucion(Institucion institucion);

        bool registrarEncargado(Encargado encargado);

        bool asignarFechaADocumento(Documento documento);

    }
}
