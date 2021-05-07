using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWFF.DALC;

namespace IWFF.negocio
{
    public class Ordendespacho
    {
        public decimal id_orden_despacho { get; set; }
        public DateTime fecha_orden_despacho { get; set; }
        public decimal id_despacho { get; set; }
        public Despacho despacho { get; set; }

        //DAO
        FermeEntities db = new FermeEntities();

        //Listado
        public List<Ordendespacho> ReadAll()
        {
            return this.db.ORDENDESPACHO.Select(O => new Ordendespacho()
            {
                id_orden_despacho = O.ID_ORDEN_DESPACHO,
                fecha_orden_despacho = O.FECHA_ORDEN_DESPACHO,
                id_despacho = O.DESPACHO_ID_DESPACHO,
                despacho = new Despacho() { 
                        
                    id_despaco = O.DESPACHO.ID_DESPACHO,
                    estado_despacho = O.DESPACHO.ESTADO_DESPACHO,
                    fecha_despacho = O.DESPACHO.FECHA_DESPACHO,
                    id_boleta = O.DESPACHO.BOLETA_ID_BOLETA,
                    id_factura = O.DESPACHO.FACTURA_ID_FACTURA

                }
                    
            }
            ).ToList();
        }
    }
}
