using LogicaDeNegocio.Modelo;
using System;
using System.Collections.Generic;

namespace LogicaDeNegocio.AccesoADatos.Interfaces
{
    interface ICoordinadorDAO
    {

        bool registrarCoordinador(Coordinador coordinador);

        bool darBajaCoordinador(String matricula);

        bool editarCoordinador(String matricula, String contraseña, String correo);

        List<Coordinador> mostrarCoordinadores();

        bool getIdCoordinador(String id);

    }
}
