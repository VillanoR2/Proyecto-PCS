using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio
{
    public class Expediente
    {
        private Documento DocumentoExpediente { get; set; }
        private Reporte ReporteExpediente { get; set; }
    }

    class Documento
    {
        private String NombreDocumento { get; set; }
        private int IdDocumento { get; set; }
        private String DescripcionDocumento { get; set; }
    }

    class Reporte
    {
        private String Fecha { get; set; }
        private int HorasRegistradas { get; set; }
        private int IdReporte { get; set; }
    }
}
