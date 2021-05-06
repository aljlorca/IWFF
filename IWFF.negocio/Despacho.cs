using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWFF.DALC;

namespace IWFF.negocio
{
    public class Despacho
    {
        public decimal id_despaco { get; set; }
        public DateTime fecha_despacho { get; set; }
        public String estado_despacho { get; set; }
        public decimal id_factura { get; set; }
        public decimal id_boleta { get; set; }

        //DAO
        FermeEntities db = new FermeEntities();

        //Listado
        public List<Despacho> ReadAll()
        {
            return this.db.DESPACHO.Select(d => new Despacho()
            {
                id_despaco = d.ID_DESPACHO,
                fecha_despacho = d.FECHA_DESPACHO,
                estado_despacho = d.ESTADO_DESPACHO,
                id_factura = d.FACTURA_ID_FACTURA,
                id_boleta = d.BOLETA_ID_BOLETA
            }
            ).ToList();

        }

    }

}
