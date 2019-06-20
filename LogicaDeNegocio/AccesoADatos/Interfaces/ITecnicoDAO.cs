using LogicaDeNegocio.Modelo;
using System;

namespace LogicaDeNegocio.AccesoADatos.Interfaces
{
    interface ITecnicoDAO
    {
        bool registrarTecnico(TecnicoAcademico tecnico);

        bool darBajaTecnico(String matricula);

        bool editarTecnico(String matricula, String correo, String contraseña);
    }
}
