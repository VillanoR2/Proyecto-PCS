using LogicaDeNegocio.Modelo;
using System;

namespace LogicaDeNegocio.AccesoADatos.Interfaces
{
    interface IInstitucionDAO
    {
        bool registrarInstitucion(Institucion institucion);

        bool getNombreInsitucion(String nombre);
    }
}
