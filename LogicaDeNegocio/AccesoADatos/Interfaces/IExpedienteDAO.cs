using LogicaDeNegocio.Modelo;

namespace LogicaDeNegocio.AccesoADatos.Interfaces
{
    interface IExpedienteDAO
    {
        bool asignarFechaADocumento(Documento documento);

        bool editarFechaADocumento(Documento documento);


    }
}
