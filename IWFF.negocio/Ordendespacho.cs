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

        //DAO
        FermeEntities db = new FermeEntities();

        //Listado
        public List<Ordendespacho> ReadAll()
        {
            return this.db.ORDENDESPACHO.Select(O => new Ordendespacho()
            {
                id_orden_despacho = O.ID_ORDEN_DESPACHO,
                fecha_orden_despacho = O.FECHA_ORDEN_DESPACHO,
                id_despacho = O.DESPACHO_ID_DESPACHO
            }
            ).ToList();
        }
    }
}
