using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio
{
    public class Expediente
    {
        public Documento DocumentoExpediente { get; set; }
        public Reporte ReporteExpediente { get; set; }
    }

    public class Documento
    {
        public String NombreDocumento { get; set; }
        public int IdDocumento { get; set; }
        public String DescripcionDocumento { get; set; }
        public String FechaEntrega { get; set; }
    }
    
     public enum IdDocumento
    {
        CartaAsignacion = 1,
        CartaAceptacion = 2,
        FormatoRegistroYPlanActividades = 3,
        CartaLiberacion = 4,
        ReporteFinal = 5 

    }

    public class Reporte
    {
        public String Fecha { get; set; }
        public int HorasRegistradas { get; set; }
        public int IdReporte { get; set; }
    }
}
