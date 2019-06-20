using LogicaDeNegocio.Modelo;
using System;

namespace LogicaDeNegocio.AccesoADatos.Interfaces
{
    interface IEncargadoDAO
    {
        bool registrarEncargado(Encargado encargado);

        bool getIdEncargado(String encargado);
    }
}
